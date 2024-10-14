using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Data
{
    public class Episode
    {
        public Episode()
        {
            Shows = new HashSet<Show>();
        }

        [Key]
        public int EpisodeId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(160)]
        public string Genre { get; set; }

        [Required]
        public DateTime AirDate { get; set; }

        public string Clerk { get; set; }

        public int EpisodeNumber { get; set; }

        [Required]
        [StringLength(250)]
        public string ImageUrl { get; set; }

        public int SeasonNumber { get; set; }

        [StringLength(250)]
        public string Premise { get; set; }

        [StringLength(200)]
        public string VideoContentType { get; set; }
        public byte[] Video { get; set; }

        [Required]
        public int ShowId { get; set; }

        public string ShowName { get; set; }

        public ICollection<Show> Shows { get; set; }
    }
}