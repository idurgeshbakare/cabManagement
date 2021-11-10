using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Domain
{
    public class Rider
    {
        /// <summary>
        /// Unique Id for Rider
        /// </summary>
        [Required]
        public string  RiderId { get; set; }

        /// <summary>
        /// Name of Rider
        /// </summary>
        [Required]
        public string RiderName { get; set; }
    }
}
