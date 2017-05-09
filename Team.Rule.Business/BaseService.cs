using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Rule.Entity.Team_Rule;

namespace Team.Rule.Business
{
    /// <summary>
    /// 基础业务服务
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// 实体上下文
        /// </summary>
        protected Test_Rule dbContent = ThreadCache.dbContext_Test_Rule;


        /// <summary>
        /// 抛出业务异常信息
        /// </summary>
        /// <param name="message">异常信息</param>
        public void Throw(string message = null)
        {
            throw new BusinessException(message == null ? "异常" : message);
        }
    }
}