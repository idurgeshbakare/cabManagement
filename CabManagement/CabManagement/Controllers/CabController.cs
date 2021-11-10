using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CabManagement.Domain;
using CabManagement.Exceptions;
using CabManagement.Managers;
using CabManagement.Managers.Impl;
using Microsoft.AspNetCore.Mvc;

namespace CabManagement.Controllers
{
    [Route("cab")]
    [ApiController]
    public class CabController : ControllerBase
    {
        private readonly ICabManager cabManager;

        public CabController(ICabManager cabManager)
        {
            this.cabManager = cabManager;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] Cab cab)
        {
            try
            {
                cabManager.RegisterCab(cab);
            }
            catch (CabAlreadyRegistered ex)
            {
                var output = new BadRequestObjectResult(ex.Message);
                return output;
            }
            catch (Exception ex)
            {
                var output = new BadRequestObjectResult("Internal Server Error: " + ex.Message);
                return output;
            }
            return new OkResult();
        }

        [HttpGet("getCab/{cabId}")]
        public ActionResult<IEnumerable<string>> ListCabs([FromRoute]string cabId)
        {
            try
            {
                var cabs = cabManager.GetCab(cabId);
                return new OkObjectResult(cabs);
            }
            catch (CabDoesNotExist ex)
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

        [HttpGet("listCabs")]
        public ActionResult<IEnumerable<string>> ListCabs()
        {
            var cabs = cabManager.ListCabs("IDLE");
            return new OkObjectResult(cabs);
        }

        [HttpPost("update/location/{cabId}")]
        public ActionResult UpdateCabLocation([Required]string cabId, [Required]string location)
        {
            try
            {
                cabManager.UpdateCabLocation(cabId, location);
                return new OkResult();
            }
            catch (CabDoesNotExist ex)
            {
                var output = new BadRequestObjectResult(ex.Message);
                return output;
            }
        }

        [HttpPost("update/state/{cabId}")]
        public ActionResult UpdateCabState([Required]string cabId)
        {
            cabManager.UpdateCabState(cabId);

            return new OkResult();
        }
    }
}
