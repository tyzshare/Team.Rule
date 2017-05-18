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
    public class UserController : ApiController
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="dto">创建用户传输模型</param>
        /// <returns></returns>
        [HttpPost]
        public bool CreateUser(CreateUserInputDto dto)
        {
            return true;
        }


        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}