using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Rule.Business
{
    /// <summary>
    /// 检索用户集合的输入模型
    /// </summary>
    public class QueryUsersInputDto
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Key
        {
            get;set;
        }
        /// <summary>
        /// 当前页码值
        /// </summary>
        public int PageIndex
        {
            get;set;
        }
        /// <summary>
        /// 每页多少条数据
        /// </summary>
        public int PageSize
        {
            get;set;
        }
    }
}
