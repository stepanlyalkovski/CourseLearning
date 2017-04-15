using System.Web;
using System.Web.Optimization;

namespace CourseLearning.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular.route").Include(
                        "~/Scripts/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular.ui-router").Include(
                        "~/Scripts/angular-ui-router.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular.resource").Include(
                        "~/Scripts/angular-resource.js"));

            bundles.Add(new ScriptBundle("~/bundles/sharedApp")
                .IncludeDirectory("~/App/config", "*.js", true)
                .IncludeDirectory("~/App/shared", "*.js", true)
                .IncludeDirectory("~/App/test", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/clientApp")
                .Include("~/App/appClient.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminApp")
                .Include("~/App/appAdmin.js")
                .IncludeDirectory("~/App/admin", "*.js", true));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
