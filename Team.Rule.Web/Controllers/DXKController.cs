using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Team.Rule.Web.Controllers
{
    public class DXKController : Controller
    {
        // GET: DXK
        public async Task<ActionResult> Index()
        {

            var callContext = CallContext.HostContext;
            System.Web.HttpContext httpContext = System.Web.HttpContext.Current;
            SynchronizationContext synchronizationContext = SynchronizationContext.Current;
            ExecutionContext executionContext = ExecutionContext.Capture();
            var threadContext = Thread.CurrentContext;


            await Task.Factory.StartNew(delegate
            {
                callContext = CallContext.HostContext;
                httpContext = System.Web.HttpContext.Current;
                synchronizationContext = SynchronizationContext.Current;
                executionContext = ExecutionContext.Capture();
                threadContext = Thread.CurrentContext;
            });

            return Content("ok");
        }


        static HttpContext TestContext
        {
            get
            {
                return System.Web.HttpContext.Current.Check();
            }
        }
    }
}