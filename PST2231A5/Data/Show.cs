using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Data
{
    public class Show
    {
        public Show()
        {
            Actors = new HashSet<Actor>();
            Episodes = new HashSet<Episode>();
        }

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
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Premise { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public ICollection<Actor> Actors { get; set; }

        public ICollection<Episode> Episodes { get; set; }
    }
}