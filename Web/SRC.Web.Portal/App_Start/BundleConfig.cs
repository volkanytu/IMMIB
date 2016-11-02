using System.Web;
using System.Web.Optimization;

namespace SRC.Web.Portal
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                          "~/css/bootstrap.min.css",
                          "~/css/bootstrap-reset.css",
                          "~/assets/font-awesome/css/font-awesome.css"));

            bundles.Add(new StyleBundle("~/css/style").Include(
                          "~/css/style.css",
                          "~/css/style-responsive.css",
                          "~/css/jquery.vegas.css"));

            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                        "~/js/jquery.js",
                        "~/js/jquery.scrollTo.min.js",
                        "~/js/jquery.nicescroll.js",
                        "~/js/jquery.dcjqaccordion.2.7.js"));

            bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include(
                        "~/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/general").Include(
                        "~/js/hover-dropdown.js",
                        "~/js/respond.min.js",
                        "~/js/slidebars.min.js",
                        "~/js/common-scripts.js",
                        "~/js/jquery.vegas.js"));
        }
    }
}
