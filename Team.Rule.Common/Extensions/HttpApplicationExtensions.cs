using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Web
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public static class HttpApplicationExtensions
    {
        static Func<SynchronizationContext, HttpApplication> _findApplicationDelegate;


        static Func<SynchronizationContext, HttpApplication> GetFindApplicationDelegate(SynchronizationContext context)
        {
            if (_findApplicationDelegate != null)
            {
                return _findApplicationDelegate;
            }


            if (context.GetType().FullName.Equals("System.Web.LegacyAspNetSynchronizationContext"))
            {
                _findApplicationDelegate = CreateFindApplicationDelegate(context.GetType());
            }

            return _findApplicationDelegate;
        }

        /// <summary>
        /// 在同步上下文中查找当前会话<see cref="System.Web.HttpApplication" />对象
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static HttpApplication FindHttpApplication(this SynchronizationContext context)
        {
            if (context == null)
            {
                return null;
            }
            var factory = GetFindApplicationDelegate(context);
            if (factory == null)
            {
                return null;
            }
            return factory(context);
        }
        /// <summary>
        /// 在同步上下文中查找当前会话<see cref="System.Web.HttpContext" />对象
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static HttpContext FindHttpContext(this SynchronizationContext context)
        {
            if (context == null)
            {
                return null;
            }
            var factory = GetFindApplicationDelegate(context);
            if (factory == null)
            {
                return null;
            }
            return factory(context).Context;
        }

        /// <summary>
        /// 确定异步状态的上下文可用
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static HttpContext Check(this HttpContext context)
        {
            if (context == null)
            {
                context = SynchronizationContext.Current.FindHttpContext();
            }
            return context;
        }
        /// <summary>
        /// 获取 HTTP 请求过程中在 System.Web.IHttpModule 接口和 System.Web.IHttpHandler 接口之间组织和共享数据的键对应的值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="keyName"></param>
        /// <param name="keyValueCreator"></param>
        /// <param name="getDefault">HttpContext为null的时候是否返回默认值 默认:false</param>
        /// <returns></returns>
        public static object GetItem(this HttpContext context, string keyName, Func<object> keyValueCreator, bool getDefault)
        {
            var httpContext = context.Check();
            if (httpContext == null)
            {
                if (getDefault)
                {
                    return null;
                }
                return keyValueCreator();
            }
            var value = httpContext.Items[keyName];
            if (value == null)
            {
                value = keyValueCreator();
                if (value == null)
                {
                    throw new ArgumentException("返回数据为null", "keyValueCreator");
                }
                httpContext.Items[keyName] = value;
            }
            return value;
        }

        /// <summary>
        /// 获取 HTTP 请求过程中在 System.Web.IHttpModule 接口和 System.Web.IHttpHandler 接口之间组织和共享数据的键对应的值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="keyName"></param>
        /// <param name="keyValueCreator"></param>
        /// <returns></returns>
        public static object GetItem(this HttpContext context, string keyName, Func<object> keyValueCreator)
        {
            return context.GetItem(keyName, keyValueCreator, false);
        }

        /// <summary>
        /// 获取 HTTP 请求过程中在 System.Web.IHttpModule 接口和 System.Web.IHttpHandler 接口之间组织和共享数据的键对应的值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static object GetItem(this HttpContext context, string keyName)
        {
            var httpContext = context.Check();
            if (httpContext == null)
            {
                return null;
            }
            var value = httpContext.Items[keyName];
            return value;
        }


        /// <summary>
        /// 获取 HTTP 请求过程中在 System.Web.IHttpModule 接口和 System.Web.IHttpHandler 接口之间组织和共享数据的键对应的值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="keyName"></param>
        /// <param name="keyValueCreator"></param>
        /// <param name="getDefault">HttpContext为null的时候是否返回默认值 默认:false</param>
        /// <returns></returns>
        public static T GetItem<T>(this HttpContext context, string keyName, Func<T> keyValueCreator, bool getDefault) where T : class
        {
            var httpContext = context.Check();
            if (httpContext == null)
            {
                if (getDefault)
                {
                    return default(T);
                }
                return keyValueCreator();
            }
            var value = httpContext.Items[keyName] as T;
            if (value == null)
            {
                value = keyValueCreator();
                if (value == null)
                {
                    throw new ArgumentException("返回数据为null", "keyValueCreator");
                }
                httpContext.Items[keyName] = value;
            }
            return value;
        }

        /// <summary>
        /// 获取 HTTP 请求过程中在 System.Web.IHttpModule 接口和 System.Web.IHttpHandler 接口之间组织和共享数据的键对应的值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="keyName"></param>
        /// <param name="keyValueCreator"></param>
        /// <returns></returns>
        public static T GetItem<T>(this HttpContext context, string keyName, Func<T> keyValueCreator) where T : class
        {
            return context.GetItem<T>(keyName, keyValueCreator, false);
        }

        /// <summary>
        /// 获取 HTTP 请求过程中在 System.Web.IHttpModule 接口和 System.Web.IHttpHandler 接口之间组织和共享数据的键对应的值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static object GetItem<T>(this HttpContext context, string keyName) where T : class
        {
            var httpContext = context.Check();
            if (httpContext == null)
            {
                return null;
            }
            var value = httpContext.Items[keyName] as T;
            return value;
        }


        static Func<System.Threading.SynchronizationContext, System.Web.HttpApplication> CreateFindApplicationDelegate(Type type)
        {
            ParameterExpression sourceExpression = Expression.Parameter(typeof(System.Threading.SynchronizationContext), "context");
            //目前支持 System.Web.LegacyAspNetSynchronizationContext 内部类
            if (type.FullName.Equals("System.Web.LegacyAspNetSynchronizationContext"))
            {
                //查找		private HttpApplication _application 字段 
                Expression sourceInstance = Expression.Convert(sourceExpression, type);
                FieldInfo applicationFieldInfo = type.GetField("_application", Reflection.BindingFlags.NonPublic | Reflection.BindingFlags.Instance);
                if (applicationFieldInfo == null)
                {
                    return null;
                }
                Expression fieldExpression = Expression.Field(sourceInstance, applicationFieldInfo);
                return Expression.Lambda<Func<System.Threading.SynchronizationContext, System.Web.HttpApplication>>(fieldExpression, sourceExpression).Compile();
            }
            return null;
        }

    }
}
