using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Team.Rule.Web.Controllers
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 返回给前台Json格式的正确信息
        /// </summary>
        /// <param name="result">结果</param>
        /// <param name="message">信息</param>
        /// <returns></returns>
        public JsonResult Success(object result = null, string message = null)
        {
            return new JsonResult() { Data = new { success = true, result = result, message = message == null ? "成功" : message }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}