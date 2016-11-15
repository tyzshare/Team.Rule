using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Team.Rule.Web.Controllers.Api
{
    public class TestApiController : ApiController
    {
       // [HttpGet]
        public object Get()
        {
            return "Get请求";
        }

       // [HttpPost]
        public object Post()
        {
            return "Post请求";
        }
    }
}
