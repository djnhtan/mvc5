﻿using System.Web;
using System.Web.Optimization;

namespace BasicWebsite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/cazary.js",
                      "~/Scripts/cazary-legacy.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                      "~/Scripts/fullcalendar.js"));

            bundles.Add(new ScriptBundle("~/bundles/jtable").Include(
                      "~/Scripts/jtable/jquery.jtable.min.js",
                      "~/Scripts/jquery.jTableScroll-1.5.2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/font-awesome.css",
                      "~/Content/themes/flat/style.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/calendar").Include(
                      "~/Content/fullcalendar.css"));

            bundles.Add(new StyleBundle("~/Content/jtable").Include(
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Scripts/jtable/themes/metro/darkorange/jtable.css"));
        }
    }
}
