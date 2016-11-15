using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Rule.Dto
{
    public class RoleDto:IValidate
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "权限名称不能为空")]
        public string Name { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}
