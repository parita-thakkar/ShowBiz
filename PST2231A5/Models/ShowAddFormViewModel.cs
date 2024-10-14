using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PST2231A5.Models
{
    public class ShowAddFormViewModel
    {
        public ShowAddFormViewModel()
        {
            ReleaseDate = DateTime.Now.AddYears(-15);
        }

        [Required]
        [StringLength(160)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}")]
        [Required]
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(250)]
        [DisplayName("Image")]
        public string ImageUrl { get; set; }

        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Premise { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Genre")]
        public SelectList GenreList { get; set; }

        [StringLength(50)]
        public string ActorName { get; set; }

        [DisplayName("Actors")]
        public MultiSelectList ActorList { get; set; }

    }
}