using System.Web;
using System.Web.Mvc;
using Team.Rule.Web.Filters;

namespace Team.Rule.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //全局异常处理
            filters.Add(new Filters.HandleErrorAttribute());
        }
    }
}
