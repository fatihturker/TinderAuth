using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TinderAuth.Helpers;
using TinderAuth.Models;

namespace TinderAuth.Controllers
{
    [RoutePrefix("api/Token")]
    public class TokenController : ApiController
    {
        [Route("GetToken")]
        [HttpPost]
        public string GetToken([FromBody]FacebookAccount account)
        {
            var token = FacebookHelper.GetAccessToken(account.Email, account.Password);
            return token; 
        }
    }
}
