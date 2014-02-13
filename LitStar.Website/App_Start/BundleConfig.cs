using System.Web;
using System.Web.Optimization;
using System;

namespace LitStar.Website
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
                throw new ArgumentNullException("ignoreList");
            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/litstar").Include(
                        "~/Scripts/jquery_ui_custom.js",
                        "~/Scripts/plugins/charts/excanvas.min.js",
                        "~/Scripts/plugins/charts/jquery.flot.js",
                        "~/Scripts/plugins/charts/jquery.flot.resize.js",
                        "~/Scripts/plugins/charts/jquery.sparkline.min.js",
                        "~/Scripts/plugins/forms/jquery.tagsinput.min.js",
                        "~/Scripts/plugins/forms/jquery.inputlimiter.min.js",
                        "~/Scripts/plugins/forms/jquery.maskedinput.min.js",
                        "~/Scripts/plugins/forms/jquery.autosize.js",
                        "~/Scripts/plugins/forms/jquery.ibutton.js",
                        "~/Scripts/plugins/forms/jquery.dualListBox.js",
                        "~/Scripts/plugins/forms/jquery.uniform.min.js",
                        "~/Scripts/plugins/forms/jquery.select2.min.js",
                        "~/Scripts/plugins/forms/jquery.cleditor.js",
                        "~/Scripts/plugins/uploader/plupload.js",
                        "~/Scripts/plugins/uploader/plupload.html4.js",
                        "~/Scripts/plugins/uploader/plupload.html5.js",
                        "~/Scripts/plugins/uploader/jquery.plupload.queue.js",
                        "~/Scripts/plugins/wizard/jquery.form.wizard.js",
                        "~/Scripts/plugins/wizard/jquery.form.js"));

            bundles.Add(new ScriptBundle("~/bundles/litstar2").Include(
                        "~/Scripts/plugins/ui/jquery.collapsible.min.js",
                        "~/Scripts/plugins/ui/jquery.elfinder.js",
                        "~/Scripts/plugins/ui/jquery.fancybox.js",
                        "~/Scripts/plugins/ui/jquery.fullcalendar.min.js",
                        "~/Scripts/plugins/ui/jquery.jgrowl.min.js",
                        "~/Scripts/plugins/ui/jquery.mousewheel.js",
                        "~/Scripts/plugins/ui/jquery.pie.chart.js",
                        "~/Scripts/plugins/ui/jquery.timepicker.min.js",
                        "~/Scripts/plugins/ui/prettify.js",
                        "~/Scripts/plugins/tables/jquery.dataTables.min.js",
                        "~/Scripts/plugins/bootstrap/bootstrap.min.js",
                        "~/Scripts/plugins/bootstrap/bootstrap-bootbox.min.js",
                        "~/Scripts/plugins/bootstrap/bootstrap-progressbar.js",
                        "~/Scripts/plugins/bootstrap/bootstrap-colorpicker.js",
                        "~/Scripts/functions/custom.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css",
                "~/Content/bootstrap.css",
                "~/Content/elfinder.css",
                "~/Content/fancybox.css",
                "~/Content/font.css",
                "~/Content/ie.css",
                "~/Content/plugins.css",
                "~/Content/ui_custom.css"));

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