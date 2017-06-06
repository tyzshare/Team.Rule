using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace Team.Rule.WebApi.Controllers
{
    /// <summary>
    /// Api基础类
    /// </summary>
    public class ApiBaseController : ApiController
    {
        /// <summary>
        /// 成功响应数据
        /// </summary>
        /// <param name="data">响应数据</param>
        /// <returns></returns>
        public Response<T> Success<T>(T data)
        {
            return new Response<T>() { IsSuccess = true, Data = data };
        }
    }
}