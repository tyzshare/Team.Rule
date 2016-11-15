using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Rule.Dto
{
    public partial class RuleDto
    {
        public int Id { get; set; }
        public string RuleName { get; set; }
        public string RuleDetail { get; set; }
        public string Creator { get; set; }
        public System.DateTime CreatTime { get; set; }
    }
}
