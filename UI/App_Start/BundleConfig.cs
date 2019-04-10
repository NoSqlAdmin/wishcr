using System.Web;
using System.Web.Optimization;

namespace UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/greensock").Include("~/Scripts/TweenMax.min.js","~/Scripts/TimelineMax.min.js","~/Scripts/animation.gsap.min.js","~/Scripts/ScrollToPlugin.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scrollmagic").Include(
                      "~/Scripts/ScrollMagic.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/OwlCarousel2").Include(
                      "~/Scripts/owl.carousel.js"));

            bundles.Add(new ScriptBundle("~/bundles/slick").Include(
                      "~/Scripts/slick.js"));

            bundles.Add(new ScriptBundle("~/bundles/easing").Include(
                      "~/Scripts/easing.js"));

            bundles.Add(new StyleBundle("~/Content/OwlCarousel2css").Include(
                      "~/Content/owl.carousel.css",
                      "~/Content/owl.theme.default.css",
                      "~/Content/animate.css"));

            bundles.Add(new StyleBundle("~/Content/slickcss").Include(
                      "~/Content/slick.css"));
        }
    }
}
