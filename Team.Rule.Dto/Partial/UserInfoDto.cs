using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Rule.Dto
{
    partial class UserInfoDto
    {
        public EnumTaskState EnumCreatorId
        {
            get
            {
                return (EnumTaskState)CreatorId;
            }
        }


        public object Test(object value)
        {
            return value;
        }
    }
}
