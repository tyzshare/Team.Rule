using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Rule.Dto;
using Team.Rule.Entity.Team_Rule;

namespace Team.Rule.Business
{
    public class RuleService:BaseService
    {
        #region 创建规则（异步）
        /// <summary>
        /// 创建规则（异步）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task CreateRuleAsync(RuleDto dto)
        {
            //dto.Validate();tdfrg
            var rule = AutoMapperHelper.MapTo<RuleInfo>(dto);
            rule.CreatTime = DateTime.Now;
            ThreadCache.dbContext_Test_Rule.RuleInfo.Add(rule);
            await ThreadCache.dbContext_Test_Rule.SaveChangesAsync();
        }
        #endregion
        #region 获取规则（同步）

        public IPageResult<RuleDto> QueryRuleList(int pageIndex = 1, int pageSize = Config.PageSize)
        {

            var result = ThreadCache.dbContext_Test_Rule.RuleInfo.OrderByDescending(o => o.CreatTime).Select(o =>
               new RuleDto()
               {
                   Id = o.Id,
                   RuleName = o.RuleName,
                   RuleDetail = o.RuleDetail
               }).ToPage(pageIndex, pageSize);

            return result;
        }
        #endregion
        #region 删除规则（异步）
        public async Task DeleteRuleAsync(int id)
        {
            if (id <= 0)
            {
                Throw();
            }
            await ThreadCache.dbContext_Test_Rule.Database.ExecuteSqlCommandAsync("delete from ruleinfo where id=@p0", id);
        }
        #endregion
    }
}
