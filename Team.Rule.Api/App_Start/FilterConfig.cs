using System.Web;
using System.Web.Mvc;

namespace Team.Rule.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //添加全局异常处理
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
