using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team.Rule.Web.Filters
{
    public class HandleErrorAttribute : System.Web.Mvc.HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            string message = filterContext.Exception.Message;

            var logger = LogManager.GetLogger("log");

            logger.Error(message, filterContext.Exception);

            //如果是业务异常
            if (filterContext.Exception is BusinessException)
            {

            }

            //else if (filterContext.Exception is ValidationException)
            //{
            //}

            //如果是Ajax请求发生的异常，返回json格式的信息
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult()
                {
                    Data = new { success = false, message = message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                //跳转到错误页
                filterContext.HttpContext.Response.Redirect("/error.html?msg=" + filterContext.Exception.Message);
            }

            filterContext.ExceptionHandled = true;
            return;
        }
    }
}