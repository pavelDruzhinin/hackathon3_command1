﻿using System.Web;
using System.Web.Optimization;

namespace RosBets
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js",
                        "~/Scripts/datepicker-ru.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/_ros.bets.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/_readjustment_bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/_footer.css",
                      "~/Content/_left_column.css",
                      "~/Content/_right_column.css",
                      "~/Content/_line.css",
                      "~/Content/font-awesome-4.7.0/css/font-awesome.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/owl.carousel").Include(
                        "~/Scripts/owl.carousel.js"));
            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                "~/Scripts/Inputmask/inputmask.js",
                "~/Scripts/Inputmask/jquery.inputmask.js",
                "~/Scripts/Inputmask/inputmask.extensions.js",
                "~/Scripts/Inputmask/inputmask.date.extensions.js",
                "~/Scripts/Inputmask/inputmask.numeric.extensions.js"));
        }

    }
}
