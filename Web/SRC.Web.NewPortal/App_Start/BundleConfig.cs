using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Optimization;

namespace SRC.Web.NewPortal
{
    public class BundleConfig
    {
        public const string BundleStyleMain = "~/content/style/main";
        public const string BundleJsMain = "~/bundles/js/main";

        public const string BundleStyleAngular = "~/bundles/style/angular";
        public const string BundleJsAngular = "~/bundles/js/angular";

        public const string BundleStyleAngularUi = "~/content/style/angular-ui";
        public const string BundleJsAngularUi = "~/bundles/js/angular-ui";

        public const string BundleJsAngularHome = "~/bundles/js/angular-app-calculator";

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            RegisterMainBundles(bundles);
            RegisterAngularBundles(bundles);
        }

        #region | PRIVATE METHODS |
        private static void RegisterMainBundles(BundleCollection bundles)
        {
            bundles.Add(CreateStyleBundle(BundleStyleMain, new[]
                {
                    "~/css/bootstrap.min.css",
                    "~/css/bootstrap-reset.css",
                    "~/assets/font-awesome/css/font-awesome.css",
                    "~/css/style.css",
                    "~/css/style-responsive.css",
                    "~/css/jquery.vegas.css",
                    "~/css/flexslider.css",
                    "~/css/site.css"
                }));

            bundles.Add(CreateScriptBundle(BundleJsMain, new[]
                {
                    "~/js/jquery.js",
                    "~/js/jquery.scrollTo.min.js",
                    "~/js/jquery.nicescroll.js",
                    "~/js/jquery.dcjqaccordion.2.7.js",
                    "~/js/bootstrap.min.js",
                    "~/js/hover-dropdown.js",
                    "~/js/respond.min.js",
                    "~/js/slidebars.min.js",
                    "~/js/common-scripts.js",
                    "~/js/jquery.vegas.js",
                    "~/js/jquery.flexslider.js",
                    "~/assets/jquery-knob/js/jquery.knob.js",
                    "~/js/custom/common.document.ready.js"
                }));
        }

        private static void RegisterAngularBundles(BundleCollection bundles)
        {
            bundles.Add(CreateScriptBundle(BundleJsAngular, new[]
                {
                    "~/js/angular/angular.js",
                    "~/js/angular/ng-grid.js",
                    "~/js/angular/angular-resource.js",
                    "~/js/angular/angular-route.js",
                    "~/js/angular/angular-locale_tr-tr.js",
                }));

            bundles.Add(CreateScriptBundle(BundleJsAngularUi, new[]
                {
                    "~/js/angular-ui/ui-bootstrap-tpls.min.js",
                    "~/js/angular-ui/ui-grid.min.js",
                }));

            bundles.Add(CreateScriptBundle(BundleJsAngularHome, new[]
                {
                    "~/app/common/app.js",
                    "~/app/home/app-route.js",
                    "~/app/home/controllers/*.js",
                }));
        }


        private static Bundle CreateScriptBundle(string bundleUrl, params string[] scriptFiles)
        {
            if (scriptFiles == null)
                return null;

            var bundle = new ScriptBundle(bundleUrl);

            foreach (var scriptFile in scriptFiles)
            {
                bundle.Include(scriptFile);
            }

            bundle.Orderer = new NullOrderer();

            return bundle;
        }

        private static Bundle CreateStyleBundle(string bundleUrl, params string[] cssFiles)
        {
            if (cssFiles == null)
                return null;

            var bundle = new StyleBundle(bundleUrl);

            foreach (var lessFile in cssFiles)
            {
                bundle.Include(lessFile);
            }

            bundle.Orderer = new NullOrderer();

            return bundle;
        }
        #endregion

        public class NullOrderer : IBundleOrderer
        {
            public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
            {
                return files;
            }
        }
    }
}
