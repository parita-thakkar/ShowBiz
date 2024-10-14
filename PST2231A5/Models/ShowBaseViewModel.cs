using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class ShowBaseViewModel
    {
        [Key]
        public int ShowId { get; set; }

        [Required]
        [StringLength(250)]
        public string Coordinator { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }

        [Required]
        [StringLength(250)]
        [DisplayName("Image")]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Release Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}")]
        public DateTime ReleaseDate { get; set; }
    }
}