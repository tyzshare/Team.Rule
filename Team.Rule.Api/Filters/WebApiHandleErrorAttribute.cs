using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Team.Rule.Api.Filters
{
    /// <summary>
    /// WebApi异常处理
    /// </summary>
    public class WebApiHandleErrorAttribute : System.Web.Http.Filters.ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            string message = actionExecutedContext.Exception.Message;

            if (actionExecutedContext.Exception is BusinessException)
            {
                //业务异常
            }
            else if (actionExecutedContext.Exception is ValidationException)
            {
                //校验异常
            }
            else
            {
                //其他异常,记录错误日志
                var logger = LogManager.GetLogger("log");
                logger.Error(message, actionExecutedContext.Exception);
            }
            //创建响应
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(new Response<string>() { IsSuccess = false, ErrorMessage = message });
        }
    }
}