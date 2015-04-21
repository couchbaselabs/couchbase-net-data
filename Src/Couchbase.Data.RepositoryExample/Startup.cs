using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Couchbase.Data.RepositoryExample.Startup))]
namespace Couchbase.Data.RepositoryExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
