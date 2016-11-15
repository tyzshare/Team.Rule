using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Rule
{
    /// <summary>
    /// 任务状态
    /// </summary>
    public enum EnumTaskState
    {
        [EnumDescription(DefaultDescription = "未完成")]
        Unfinished = 1,
        [EnumDescription(DefaultDescription = "已完成")]
        Finished = 2,
        [EnumDescription(DefaultDescription = "已启用")]
        Enabled = 3
    }
}
