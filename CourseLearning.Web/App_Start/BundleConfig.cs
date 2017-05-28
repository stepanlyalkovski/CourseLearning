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

            bundles.Add(new ScriptBundle("~/bundles/angular.ui")
                .Include("~/Scripts/angular-ui/ui-bootstrap.js")
                .Include("~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new ScriptBundle("~/bundles/lodash")
                .Include("~/Scripts/lodash.js"));

            bundles.Add(new ScriptBundle("~/bundles/fileUpload")
                .Include("~/bower_components/ng-file-upload/ng-file-upload-shim.js")
                .Include("~/bower_components/ng-file-upload/ng-file-upload.js"));

            bundles.Add(new ScriptBundle("~/bundles/localStorage")
                .Include("~/bower_components/angular-local-storage/dist/angular-local-storage.js"));

            bundles.Add(new ScriptBundle("~/bundles/tinymce")
                .Include("~/bower_components/tinymce/tinymce.js")
                .Include("~/bower_components/angular-ui-tinymce/src/tinymce.js"));

            bundles.Add(new ScriptBundle("~/bundles/sharedApp")
                .IncludeDirectory("~/App/config", "*.js", true)
                .IncludeDirectory("~/App/shared", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/clientApp")
                .Include("~/App/appClient.js")
                .IncludeDirectory("~/App/client", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/adminApp")
                .Include("~/App/appAdmin.js")
                .IncludeDirectory("~/App/admin", "*.js", true));


            //bundles.Add(new ScriptBundle("~/bundles/gentelella")
            //    .Include("~/bower_components/gentelella/vendors/jquery/dist/jquery.min.js")
            //    .Include("~/bower_components/gentelella/vendors/bootstrap/dist/js/bootstrap.min.js")
            //    .Include("~/bower_components/gentelella/vendors/fastclick/lib/fastclick.js")
            //    .Include("~/bower_components/gentelella/vendors/vendors/nprogress/nprogress.js")
            //    .Include("~/bower_components/gentelella/vendors/Chart.js/dist/Chart.min.js")
            //    .Include("~/bower_components/gentelella/vendors/gauge.js/dist/gauge.min.js")
            //    .Include("~/bower_components/gentelella/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js")
            //    .Include("~/bower_components/gentelella/vendors/iCheck/icheck.min.js")
            //    .Include("~/bower_components/gentelella/vendors/skycons/skycons.js")
            //    .Include("~/bower_components/gentelella/vendors/Flot/jquery.flot.js")
            //    .Include("~/bower_components/gentelella/vendors/Flot/jquery.flot.pie.js")
            //    .Include("~/bower_components/gentelella/vendors/jquery/dist/jquery.min.js")
            //    .Include("~/bower_components/gentelella/vendors/jquery/dist/jquery.min.js")
            //    .Include("~/bower_components/gentelella/vendors/jquery/dist/jquery.min.js")
            //    .Include("~/bower_components/gentelella/vendors/jquery/dist/jquery.min.js")
            //    .Include("~/bower_components/gentelella/vendors/jquery/dist/jquery.min.js")
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

            bundles.Add(new StyleBundle("~/Content/tinymceSkin")
                .Include("~/bower_components/tinymce/skins/lightgray/skin.min.css"));
        }
    }
}
