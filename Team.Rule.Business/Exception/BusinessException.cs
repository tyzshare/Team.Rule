using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 业务层异常类
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }
        ///// <summary>
        ///// 抛出业务异常信息
        ///// </summary>
        ///// <param name="message"></param>
        //public static void Throw(string message)
        //{
        //    throw new BusinessException(message);
        //}
    }
}
