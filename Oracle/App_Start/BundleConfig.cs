using System.Web;
using System.Web.Optimization;

namespace Oracle
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-{version}.js").IncludeDirectory(
                        "~/Scripts/plugin", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jqueryui/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jqueryval/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angularsrc").Include(
                  "~/Scripts/angularSrc/angular.js",
                  "~/Scripts/angularSrc/angular.min.js",
                  "~/Scripts/angularSrc/angular-animate*",
                  "~/Scripts/angularSrc/angular-route*"                  
                ));

            bundles.Add(new ScriptBundle("~/bundles/angularModules").IncludeDirectory(
                "~/Scripts/angularModules", "*.js").IncludeDirectory(
                "~/Scripts/angularModules/factories", "*.js").IncludeDirectory(
                "~/Scripts/angularModules/controllers", "*.js").IncludeDirectory(
                "~/Scripts/angularModules/directives", "*.js").IncludeDirectory(
                "~/Scripts/angularModules/filters", "*.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}