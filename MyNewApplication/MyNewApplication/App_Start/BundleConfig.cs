using System.Web;
using System.Web.Optimization;

namespace MyNewApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js/jquery").Include(
                        "~/Scripts/Jquery/jquery-3.4.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/Bootstrap").Include(
                        "~/Scripts/Bootstrap/bootstrap.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/js/modernizr").Include(
                        "~/Scripts/modernizer/modernizr-2.8.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/Js/UserRecord").Include(
                        "~/Scripts/UserRecord/UserRecord.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/CreatNewAccount").Include(
                     "~/Scripts/CreatNewAccount/CreateNewAccount.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/Managpager").Include(
                     "~/Scripts/UserRecord/ManagPager.js"));


            bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include(
                      "~/Content/Bootstrsp/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css/site").Include(
                     "~/Content/Site/Site.css"));

            bundles.Add(new StyleBundle("~/Content/css/creatnewaccount").Include(
                     "~/Content/CreatNewAccount/CreatNewAccount.css"));

            bundles.Add(new ScriptBundle("~/bundles/Chart").Include(
                        "~/Scripts/Themes/fusioncharts.charts.js",
                        "~/Scripts/Themes/fusioncharts.js",
                        "~/Scripts/Themes/fusioncharts.theme.carbon.js",
                        "~/Scripts/Themes/Chart.js"
                        ));



        }
    }
}
