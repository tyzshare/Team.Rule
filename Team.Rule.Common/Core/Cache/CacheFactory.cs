using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System
{

    public interface ICacheFactory
    {
    }

    /// <summary>
    /// 缓存工厂
    /// </summary>
    public class CacheFactory : ICacheFactory
    {

        public static readonly ICacheFactory Instance = new CacheFactory();

        internal static readonly List<Action> _actions;

        internal static readonly Timer _timer;

        static CacheFactory()
        {
            _expireTime = 60;
            _actions = new List<Action>();
            _timer = new Timer(o =>
            {
                var actions = o as IEnumerable<Action>;

                object lockObj = new object();

                lock (lockObj)
                {
                    foreach (var item in actions)
                    {
                        try
                        {
                            item();
                        }
                        catch
                        {
                        }
                    }
                }
            }, _actions, Timeout.Infinite, Timeout.Infinite);

            int time = 1000 * 60 * _expireTime;
            _timer.Change(time, time);
        }

        static int _expireTime;
        /// <summary>
        /// 获取或设置过期时间
        /// </summary>
        public static int ExpireTime
        {
            get { return _expireTime; }
            set
            {
                _expireTime = value;
                int time = 1000 * 60 * _expireTime;
                _timer.Change(time, time);
            }
        }

        /// <summary>
        /// 创建一个缓存
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static ICache<TKey, TValue> CreateCache<TKey, TValue>()
        {
            return new Cache<TKey, TValue>();
        }

        /// <summary>
        /// 创建一个过期缓存
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static IExpireCache<TKey, TValue> CreateExpireCache<TKey, TValue>()
        {
            return new ExpireCache<TKey, TValue>();
        }

        /// <summary>
        /// 创建一个过期缓存,并指定过期时间
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static IExpireCache<TKey, TValue> CreateExpireCache<TKey, TValue>(TimeSpan expireTime)
        {
            var cache = CreateExpireCache<TKey, TValue>();
            cache.ExpireTime = expireTime;
            return cache;
        }

    }
}
