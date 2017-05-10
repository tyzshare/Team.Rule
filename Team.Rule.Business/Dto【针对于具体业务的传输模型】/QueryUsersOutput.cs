using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Rule.Business
{
    /// <summary>
    /// 检索用户列表输出模型
    /// </summary>
    public class QueryUsersOutput
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long Id
        {
            get;
            set;
        }
        /// <summary>
        /// 登录邮箱
        /// </summary>
        public string LoginEmail
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime
        {
            get;
            set;
        }
    }
}
