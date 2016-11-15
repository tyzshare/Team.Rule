using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Team.Rule.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 返回给前台的正确信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public JsonResult Success(object result = null, string message = null)
        {
            return new JsonResult() { Data = new { success = true, result = result, message = message == null ? "成功" : message }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}