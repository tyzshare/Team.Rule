using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 一个接口,支持过期缓存
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface IExpireCache<TKey, TValue> : ICache<TKey, TValue>, IDisposable
    {
        /// <summary>
        /// 获取或设置过期时间
        /// </summary>
        TimeSpan ExpireTime { get; set; }

        /// <summary>
        /// 当数据过期的时候触发
        /// </summary>
        event EventHandler<ExpireEventArgs<TValue>> OnExpire;
        /// <summary>
        /// 获取或设置一个值,指示当数据过期的时候是否使用异步处理数据
        /// </summary>
        bool Async { get; set; }

    }
}
