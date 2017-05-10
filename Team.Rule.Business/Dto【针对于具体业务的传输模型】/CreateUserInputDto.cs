using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Rule.Business
{
    /// <summary>
    /// 创建用户输入模型
    /// </summary>
    public class CreateUserInputDto : IValidate
    {
        /// <summary>
        /// 登陆邮箱
        /// </summary>
        [EmailAddress(ErrorMessage = "登录邮箱不合法")]
        public string LoginEmail
        {
            get;
            set;
        }
        /// <summary>
        /// 登陆密码
        /// </summary>
        [StringLength(16, ErrorMessage = "密码长度应在8到16位", MinimumLength = 8)]
        public string LoginPwd
        {
            get;
            set;
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public long CreatorId
        {
            get;
            set;
        }
    }
}
