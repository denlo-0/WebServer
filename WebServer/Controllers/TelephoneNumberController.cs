using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.ExternalRequests;

namespace WebServer.Controllers
{
    //api/TelephoneNumber
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneNumberController : ControllerBase
    {

        //вместо + использовать %2B 
        [HttpGet]
        public ActionResult<string> Get(string number)
        {
            var a = ExternalRequests.ExternalRequests.GetValidPhone(number);
            if (a == "Server error (exhausted number of requests)")
                return StatusCode(405);
            else
                return Ok(a);

        }
    }
}
