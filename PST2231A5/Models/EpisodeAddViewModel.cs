using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class EpisodeAddViewModel
    {
        public EpisodeAddViewModel()
        {
            SeasonNumber = 1;
            EpisodeNumber = 1;
        }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

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

        public string Clerk { get; set; }

        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Premise { get; set; }

        [Required]
        public HttpPostedFileBase VideoUpload { get; set; }

        [Required]
        [DisplayName("Genre")]
        public int GenreId { get; set; }

        [Required]
        public int ShowShowId { get; set; }

        [Required]
        public string ShowName { get; set; }
    }
}