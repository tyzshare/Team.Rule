using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team.Rule.Business;
using Team.Rule.Dto;

namespace Team.Rule.Web.Controllers
{
    public class RoleController : BaseController
    {
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }


       /// <summary>
       /// 加载权限
       /// </summary>
       /// <param name="pageIndex"></param>
       /// <returns></returns>
        public PartialViewResult LoadRoleList(int pageIndex)
        {
            var result = new RoleService().QueryRoleList(pageIndex);        
            return PartialView("_RoleListControl", result);
        }

        #region 插入权限
        /// <summary>
        /// 插入权限
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public JsonResult InsertRole(RoleDto role)
        {
            new RoleService().CreateRole(role);
            return Success();
        }
        #endregion


        #region 删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteRole(long id)
        {
            new RoleService().DeleteRole(id);
            return Success();
        }
        #endregion
    }
}