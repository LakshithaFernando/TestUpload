using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecruitmentProcessApi.Controllers
{
    [Route("api/service")]
    public class ServiceController : Controller
    {

        // GET api/service
        [HttpGet]
        public string Get()
        {
            return "Service has started !!";
        }
    }
}
