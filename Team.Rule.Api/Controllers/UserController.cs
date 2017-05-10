using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Team.Rule.Business;

namespace Team.Rule.Api.Controllers
{
    /// <summary>
    /// 用户相关Api
    /// </summary>
    public class UserController : ApiBaseController
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="dto">创建用户传输模型</param>
        /// <returns></returns>
        [HttpPost]
        public Response<bool> CreateUser(CreateUserInputDto dto)
        {
            return Success(new UserService().CreateUser(dto));
        }
    }
}