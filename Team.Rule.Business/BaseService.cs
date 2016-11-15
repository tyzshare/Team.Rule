using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Rule.Business
{
    public class BaseService
    {
        /// <summary>
        /// 抛出异常
        /// </summary>
        /// <param name="message">异常信息</param>
        public void Throw(string message = null)
        {
            throw new BusinessException(message == null ? "参数异常" : message); 
        }
    }
}