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
        public string Get(string number)
        {
            return ExternalRequests.ExternalRequests.GetValidPhone(number);
        }
    }
}
