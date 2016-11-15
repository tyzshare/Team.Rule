using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team.Rule.Dto;
using Team.Rule.Business;
using System.Threading.Tasks;

namespace Team.Rule.Web.Controllers
{
    public class RuleController : BaseController
    {
        // GET: Rule
        public ActionResult Index()
        {
            return View();
        }
        #region 插入规则
        /// <summary>
        /// 插入规则
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public async Task<JsonResult> CreateRuleAsync(RuleDto rule)
        {
            await new RuleService().CreateRuleAsync(rule);
            return Success();
        }
        #endregion

        public PartialViewResult LoadRuleList(int pageIndex)
        {
            var result = new RuleService().QueryRuleList(pageIndex);
            return PartialView("_RulePagePartial", result);
        }
        #region 删除规则
        /// <summary>
        /// 删除规则
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteRule(int id)
        {
            await new RuleService().DeleteRuleAsync(id);
            return Success();
        }
        #endregion
    }
}