using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Rule.Entity.Team_Rule;
using System.Web;

namespace Team.Rule
{
    /// <summary>
    /// 线程缓存
    /// </summary>
    public static class ThreadCache
    {
        /// <summary>
        /// 每一次回话创建一个DB上下文
        /// </summary>
        public static Test_Rule dbContext_Test_Rule
        {
            get
            {
                if (HttpContext.Current.Items["Test_Rule"] == null)
                {
                    HttpContext.Current.Items["Test_Rule"] = new Test_Rule();
                }
                return HttpContext.Current.Items["Test_Rule"] as Test_Rule;
            }
        }
    }
}
