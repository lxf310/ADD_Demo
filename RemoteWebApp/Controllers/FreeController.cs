using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RemoteWebApp.Controllers
{
    public class FreeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("This is a free service.");
        }
    }
}
