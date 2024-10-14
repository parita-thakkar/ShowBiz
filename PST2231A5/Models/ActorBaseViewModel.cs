using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class ActorBaseViewModel
    {
        [Key]
        public int ActorId { get; set; }

        [Required]
        [StringLength(150)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        [DisplayName("Alternate Name")]
        public string AlternateName { get; set; }

        [DisplayName("Birth Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Height (m)")]
        public double Height { get; set; }

        [Required]
        [StringLength(250)]
        [DataType(DataType.ImageUrl)]
        [DisplayName("Image")]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(250)]
        public string Executive { get; set; }
    }
}