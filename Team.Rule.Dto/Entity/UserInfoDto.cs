using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Rule.Dto
{
    public partial class UserInfoDto //: IValidate
    {

        public long Id { get; set; }

        [EmailAddress(ErrorMessage = "登录邮箱不合法")]
        public string LoginEmail { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public string LoginPwd { get; set; }
        public long CreatorId { get; set; }
        public System.DateTime CreateTime { get; set; }
    }

}
