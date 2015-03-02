using System.Web.Optimization;

namespace Registration
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryUI").Include(
                 "~/Scripts/jquery-ui-{version}.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryBlockUI").Include(
                "~/Scripts/jquery.blockUI.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));


            bundles.Add(new ScriptBundle("~/bundles/DataTables").Include(
                "~/Scripts/DataTables-1.10.2/jquery.dataTables.js",
                "~/Scripts/DatatableDateSort.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                "~/Scripts/chosen.jquery.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/Content/DataTables-1.10.2/css/jquery.dataTables.css",
                "~/Content/DataTables-1.10.2/css/jquery.dataTables_themeroller.css",
                "~/Content/themes/custom-theme/jquery-ui-1.10.3.custom.css",
                "~/Content/themes/custom-theme/jquery-ui-1.10.3.theme.css"
                ));

             bundles.Add(new StyleBundle("~/Content/Responsive").Include(
                "~/Content/chosen.css",
                "~/Content/style.default.css",
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-override.css"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}