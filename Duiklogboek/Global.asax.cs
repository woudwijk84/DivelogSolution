using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Duiklogboek
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            //Database.SetInitializer(new InitDB());
            //WebSecurity.InitializeDatabaseConnection("DefaultConnection", 
            //                                         "AspNetUsers", 
            //                                         "Id", 
            //                                         "UserName", 
            //                                         autoCreateTables: true);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
