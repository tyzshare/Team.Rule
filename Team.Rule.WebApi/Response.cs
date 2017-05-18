using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team.Rule.WebApi
{
    /// <summary>
    /// Api响应接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess
        {
            get; set;
        }
        /// <summary>
        /// 数据
        /// </summary>
        public T Data
        {
            get; set;
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage
        {
            get; set;
        }
    }
}