using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace RemoteWebApp.Controllers
{
    [Authorize]
    public class ChargedController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ChargedController));

        [HttpGet]
        public IHttpActionResult Get(string text)
        {
            var tmp = ClaimsPrincipal.Current.Claims.Select(c => $"{c.Type} = {c.Value}.\n").ToList();
            Log.Info(JsonConvert.SerializeObject((tmp)));
            return Ok($"Input: {text}.");
        }
    }
}
