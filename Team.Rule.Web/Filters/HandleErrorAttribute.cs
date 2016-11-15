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
            //if (filterContext.ExceptionHandled)
            //{
            //    return;
            //}

            string message = filterContext.Exception.Message;

            if (filterContext.Exception is BusinessException)
            {

            }
            else if (filterContext.Exception is ValidationException)
            {

            }


            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult()
                {
                    Data = new { success = false, message = message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                filterContext.ExceptionHandled = true;
                return;
            }

        }
    }
}