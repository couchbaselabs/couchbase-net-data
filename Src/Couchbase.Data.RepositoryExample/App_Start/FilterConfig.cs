using System.Web;
using System.Web.Mvc;

namespace Couchbase.Data.RepositoryExample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
