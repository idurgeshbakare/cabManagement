using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CabManagement.CabLocator;
using CabManagement.Domain;
using CabManagement.Exceptions;
using CabManagement.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CabManagement.Controllers
{
    [Route("trip")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager bookingManager;

        public BookingController(IBookingManager bookingManager)
        {
            this.bookingManager = bookingManager;
        }

        // POST : To register the CAB
        [HttpPost("book/{riderId}")]
        public ActionResult BookCab([Required]string riderId, [FromBody]Trip trip)
        {
            try
            {
                bookingManager.BookCab(riderId, trip);
                return new OkResult();
            }
            catch (CabNotAvailableException ex)
            {
                var output = new NotFoundObjectResult(ex.Message);
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