using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Team.Rule.WebApi.Filters
{
    public class WebApiHandleErrorAttribute : System.Web.Http.Filters.ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //异常信息
            string message = actionExecutedContext.Exception.Message;

            if (actionExecutedContext.Exception is BusinessException)
            {

            }
            else if (actionExecutedContext.Exception is ValidationException)
            {

            }
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(System.Net.HttpStatusCode.OK, message);
        }
    }
}