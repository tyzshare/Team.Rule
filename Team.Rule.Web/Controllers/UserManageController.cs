using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Team.Rule.Business;
using Team.Rule.Dto;
using Team.Rule.Web.Models.UserManange;

namespace Team.Rule.Web.Controllers
{
    public class UserManageController : BaseController
    {
        // GET: UserManage
        public ActionResult Index()
        {
            //throw new Exception("程序出现错误！！！");
            return View();
        }

        public PartialViewResult LoadUserInfoList(int pageIndex)
        {
            var result = new UserService().QueryUsers(new QueryUsersInputDto() { PageIndex = pageIndex, PageSize = Config.PageSize });
            return PartialView("_UserInfoListControl", result);
        }

        #region 插入用户
        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public JsonResult InsertUserInfo(CreateUserInputDto user)
        {
            new UserService().CreateUser(user);
            return Success();
        }
        #endregion

        #region 删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteUserInfo(long id)
        {
            new UserService().DeleteUser(new DeleteUserInputDto() { Id = id });
            return Success();
        }
        #endregion

    }
}