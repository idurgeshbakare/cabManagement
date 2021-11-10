using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabManagement.Domain;
using CabManagement.Exceptions;
using CabManagement.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CabManagement.Controllers
{
    [Route("rider")]
    [ApiController]
    public class RiderController : ControllerBase
    {
        private readonly IRiderManager riderManager;

        public RiderController(IRiderManager riderManager)
        {
            this.riderManager = riderManager;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] Rider rider)
        {
            try
            {
                riderManager.Register(rider);
                return new OkResult();
            }
            catch (RiderAlreadyExists ex)
            {
                var output = new BadRequestObjectResult(ex.Message);
                return output;
            }
            catch (Exception ex)
            {
                var output = new BadRequestObjectResult("Internal Server Error: " + ex.Message);
                return output;
            }
        }
    }
}