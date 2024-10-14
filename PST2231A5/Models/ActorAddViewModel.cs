using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class ActorAddViewModel
    {
        public ActorAddViewModel()
        {
            BirthDate = DateTime.Now.AddYears(-15);
        }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [DisplayName("Alternate Name")]
        [Required]
        [StringLength(150)]
        public string AlternateName { get; set; }

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Height (m)")]
        public double Height { get; set; }

        [DisplayName("Image")]
        [Required]
        [StringLength(250)]
        public string ImageUrl { get; set; }

        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Biography { get; set; }

        [Required]
        [StringLength(250)]
        public string Executive { get; set; }
    }
}