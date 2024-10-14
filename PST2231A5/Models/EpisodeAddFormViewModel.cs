using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PST2231A5.Models
{
    public class EpisodeAddFormViewModel
    {
        public EpisodeAddFormViewModel()
        {
            SeasonNumber = 1;
            EpisodeNumber = 1;
        }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public int ShowShowId { get; set; }

        [Required]
        public string ShowName { get; set; }

        [DisplayName("Season")]
        public int SeasonNumber { get; set; }

        [DisplayName("Episode")]
        public int EpisodeNumber { get; set; }

        [Required]
        [DisplayName("Date Aired")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}")]
        public DateTime AirDate { get; set; }

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

        [Required]
        [Display(Name = "Video Attachment")]
        [DataType(DataType.Upload)]
        public string VideoUpload { get; set; }
    }
}