using System.Web;
using System.Web.Optimization;

namespace QueueSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/cssview").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/siteview.css",
                      "~/Content/font-awesome.css"));
            bundles.Add(new StyleBundle("~/Content/AnimatedBorderMenuscss").Include(
                      "~/Content/AnimatedBorderMenus/css/icons.css",
                      "~/Content/AnimatedBorderMenus/css/normalize.css",
                      "~/Content/AnimatedBorderMenus/css/style5.css"));
            bundles.Add(new StyleBundle("~/Content/SidebarTransitionscss").Include(
                      "~/Content/SidebarTransitions/css/component.css",
                      "~/Content/SidebarTransitions/css/components-right.css",
                      "~/Content/SidebarTransitions/css/normalize.css",
                      "~/Content/SidebarTransitions/css/icons.css",
                      "~/Content/SidebarTransitions/css/demo.css"));
            bundles.Add(new ScriptBundle("~/bundles/AnimatedBorderMenusjs").Include(
                      "~/Scripts/borderMenu.js",
                      "~/Scripts/classie.js",
                      "~/Scripts/sidebarEffects.js",
                      "~/Scripts/modernizr.custom.js"));
            //bundles.Add(new ScriptBundle("~/bundles/SignalR").Include(
            //          "~/jquery-1.10.2.min.js",
            //          "~/jquery.color-2.1.2.min.js",
            //          "~/Scripts/jquery.signalR-2.2.1.js",
            //          "~/signalr/hubs",
            //          "~/jquery-1.10.2.min.js",
            //          //"~/SignalR.Sample/HeThongSoSignalr.js",
            //          "~/SignalR.Sample/SignalR.StockTicker.js"
            //          ));

        }
    }
}
