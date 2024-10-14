using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class ActorMediaItemBaseViewModel
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string ContentType { get; set; }

        [Required]
        [StringLength(150)]
        public string Caption { get; set; }

        [Required]
        [StringLength(150)]
        public string StringId { get; set; }
    }
}