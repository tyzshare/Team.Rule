using System.Web;
using System.Web.Optimization;

namespace Team.Rule.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //公用样式
            bundles.Add(new StyleBundle("~/Styles/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/site.css",
                       "~/Content/overwrite.css"
                      ));
            //公用脚本
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/modernizr-*",
                         "~/Scripts/bootstrap.js",
                         "~/Scripts/jquery.validate.js",
                         "~/Scripts/tool.js"
                        ));

        }
    }
}
