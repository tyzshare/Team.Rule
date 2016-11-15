using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Team.Rule.Business;
using Team.Rule.Dto;

namespace Team.Rule.Web.Controllers.Api
{
    public class UserApiController : ApiController
    {
        /// <summary>
        /// 获取用户的数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult<IPageResult<UserInfoDto>> QueryUserInfoList(int pageIndex = 1, int pageSize = Config.PageSize)
        {
            var result = new UserInfoService().QueryUserInfoList(pageIndex, pageSize);
            return Json(result);
        }
    }
}
