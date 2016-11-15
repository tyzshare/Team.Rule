using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Team.Rule.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public async Task<ActionResult> Index()
        {

            //return Content(System.Web.HttpContext.Current.Request.Url.ToString());

            return Content(await TestAsync());

        }


        async Task<string> TestAsync()
        {
  
           return await Task.Run(()=> {

               var context = SynchronizationContext.Current;
               //return System.Web.HttpContext.Current.Request.Url.ToString();
               return System.Web.HttpContext.Current.Check().Request.Url.ToString();

           });
        }
    }
}