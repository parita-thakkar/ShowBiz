using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class ShowAddViewModel
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Release Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(250)]
        [DisplayName("Image")]
        public string ImageUrl { get; set; }

        [Required]
        [DisplayName("Genre")]
        public int GenreId { get; set; }

        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Premise { get; set; }

        [Required]
        public IEnumerable<int> ActorId { get; set; }

        public IEnumerable<int> EpisodeId { get; set; }
    }
}