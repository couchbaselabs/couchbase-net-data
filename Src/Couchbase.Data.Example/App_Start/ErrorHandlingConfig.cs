namespace Couchbase.Data.Example
{
	using System.Net;
	using System.Web.Mvc;
	using System.Web.Routing;
	using EasyErrorHandlingMvc;
	using EasyErrorHandlingMvc.Handlers;

	public static class ErrorHandlingConfig
	{
		public static void ConfigureErrorHandling()
		{
			// Wrap the ControllerFactory
			// This factory wraps created Controllers with custom ActionInvokers
			// Handles errors when the Controller could not be created (e.g. Controller not found) or when the invoking of the Action (e.g. Action not found) fails
			WrapControllerFactory();

			// Registers the EasyErrorHandling ExceptionFilter
			// Handles errors during executing actions
			RegisterExceptionFilter(GlobalFilters.Filters);

			// All other errors are handled by the ErrorHandlingHttpModule or by the IIS Runtime (e.g. RequestFiltering)

			// Configures which error pages should be rendered for each case
			SetRenderingConfiguration();
		}

		public static void RegisterCatchAllErrorHandlingRoute(this RouteCollection routes)
		{
			// TODO: Call this method at the bottom of RouteConfig
			// Register catch all default route
			routes.RegisterErrorHandlingRoute("Any", "{*any}", HttpStatusCode.NotFound);
		}

		public static void RegisterSpecificErrorHandlingRoutes(this RouteCollection routes)
		{
			// TODO: Call this method at the top of RouteConfig
			// Register specific Error Routes, called by IIS Runtime (must match with registered urls in web.config httpErrors section)
			routes.RegisterErrorHandlingRoute("InternalServerError", "InternalServerError/", HttpStatusCode.InternalServerError);
			routes.RegisterErrorHandlingRoute("Unauthorized", "Unauthorized/", HttpStatusCode.Unauthorized);
			routes.RegisterErrorHandlingRoute("NotFound", "NotFound/", HttpStatusCode.NotFound);
		}

		private static void RegisterErrorHandlingRoute(this RouteCollection routes, string name, string url,
			HttpStatusCode action)
		{
			routes.MapRoute(name, url, new { controller = Configuration.ErrorHandlingControllerName, action = action.ToString() });
		}

		private static void RegisterExceptionFilter(GlobalFilterCollection filters)
		{
			filters.Add(new ExceptionFilterAttribute());
		}

		private static void SetRenderingConfiguration()
		{
			// Define which HttpStatusCode should be rendered for which type of error, from most to less specific
			// For defining individual rules, add them to CorrespondingRenderingHttpStatusCode directly
			Configuration.RenderGetDangerousParametersAs(HttpStatusCode.NotFound);
			Configuration.RenderGetInvalidParametersAs(HttpStatusCode.NotFound);
			Configuration.RenderHttpExceptionAs(HttpStatusCode.Forbidden, HttpStatusCode.NotFound);
			Configuration.RenderHttpExceptionAs(HttpStatusCode.NotFound, HttpStatusCode.NotFound);

			Configuration.RenderHttpExceptionAs(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError);
			Configuration.RenderHttpExceptionAs(HttpStatusCode.Unauthorized, HttpStatusCode.Unauthorized);

			Configuration.RenderEverythingElseAs(HttpStatusCode.InternalServerError);

			Configuration.SetErrorViewPath(HttpStatusCode.InternalServerError, "~/Views/ErrorHandling/InternalServerError.cshtml");
			Configuration.SetErrorViewPath(HttpStatusCode.Unauthorized, "~/Views/ErrorHandling/Unauthorized.cshtml");
			Configuration.SetErrorViewPath(HttpStatusCode.NotFound, "~/Views/ErrorHandling/NotFound.cshtml");

			Configuration.FatalErrorFilePath = "~/Views/ErrorHandling/FatalError.htm";
		}

		private static void WrapControllerFactory()
		{
			ControllerBuilder.Current.SetControllerFactory(
				new ControllerFactoryWrapper(ControllerBuilder.Current.GetControllerFactory()));
		}
	}
}