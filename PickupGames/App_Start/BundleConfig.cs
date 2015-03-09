using System.Web.Optimization;

namespace PickupGames
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/angular-route.js"));

            var jqueryBundle = new ScriptBundle("~/bundles/google-maps","https://maps.googleapis.com/maps/api/js?v=3.exp&libraries=places");
            bundles.Add(jqueryBundle);

            //jqueryBundle = new ScriptBundle("~/bundles/angular-google-maps","https://cdnjs.cloudflare.com/ajax/libs/angular-google-maps/2.0.12/angular-google-maps_dev_mapped.min.js");
            //bundles.Add(jqueryBundle);

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/app/app.js",
                      "~/Scripts/app/controllers/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-theme.css",
                      "~/Content/site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
