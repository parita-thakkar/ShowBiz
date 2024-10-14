using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Data
{
    public class Actor
    {
        public Actor()
        {
            Shows = new HashSet<Show>();
            ActorMediaItems = new List<ActorMediaItem>();
        }

        [Key]
        public int ActorId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string AlternateName { get; set; }

        public DateTime BirthDate { get; set; }

        public double Height { get; set; }

        [Required]
        [StringLength(250)]
        public string ImageUrl { get; set; }

        [StringLength(250)]
        public string Biography { get; set; }

        [Required]
        [StringLength(250)]
        public string Executive { get; set; }

        public ICollection<Show> Shows { get; set; }

        public ICollection<ActorMediaItem> ActorMediaItems { get; set; }
    }
}