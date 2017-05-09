using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Team.Rule.Business;
using Team.Rule.Dto;

namespace Team.Rule.WebApi.Controllers
{
    public class UserController : ApiController
    {


        // GET api/user

        // GET api/user/5
        //public IPageResult<UserInfoDto> Get(int id)
        //{
        //    return new UserInfoService().QueryUserInfoList();
        //}

        //public JsonResult<IPageResult<UserInfoDto>> Get(int pageIndex, int pageSize)
        //{
        //    var result = new UserInfoService().QueryUserInfoList(pageIndex, pageSize);
        //    return Json(result);
        //}

        //[HttpGet]
        public IPageResult<UserInfoDto> Get(int pageIndex, int pageSize)
        {
            var result = new UserInfoService().QueryUserInfoList(pageIndex, pageSize);
            return result;
        }

        //[HttpPost]
        // POST api/user
        [HttpGet]
        public void Post()
        {
            new UserInfoService().CreateUserInfo(new CreateUserInfoDto()
            {
                CreatorId = 1,
                LoginEmail = "",
                LoginPwd = string.Empty
            });
        }

        //[HttpPut]
        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        //[HttpDelete]
        public void Delete([FromBody]TestModel model)
        {
            new UserInfoService().DeleteUserInfo(model.Id);
        }


        // DELETE api/user/5
        //[HttpDelete]
        public void Delete(int id)
        {
            new UserInfoService().DeleteUserInfo(id);
        }

        public class TestModel
        {
            public int Id { get; set; }
        }
    }
}
