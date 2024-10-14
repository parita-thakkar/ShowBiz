using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class ActorAddFormViewModel
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string AlternateName { get; set; }

        [DisplayName("Release Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}")]
        public DateTime BirthDate { get; set; }

        public double Height { get; set; }

        [Required]
        [StringLength(250)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(250)]
        public string Executive { get; set; }
    }
}