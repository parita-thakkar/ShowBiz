using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class EpisodeBaseViewModel
    {
        public EpisodeBaseViewModel()
        {
            Shows = new List<ShowBaseViewModel>();
        }

        [Key]
        public int EpisodeId { get; set; }

        [Required]
        [StringLength(150)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(160)]
        [DisplayName("Genre")]
        public string Genre { get; set; }

        [Required]
        [DisplayName("Date Aired")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}")]
        public DateTime AirDate { get; set; }

        public string Clerk { get; set; }

        [DisplayName("Episode")]
        public int EpisodeNumber { get; set; }

        [Required]
        [StringLength(250)]
        [DisplayName("Image")]
        public string ImageUrl { get; set; }

        [DisplayName("Season")]
        public int SeasonNumber { get; set; }

        public IEnumerable<ShowBaseViewModel> Shows { get; set; }

    }
}