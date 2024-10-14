using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Data
{
    public class ActorMediaItem
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        [StringLength(200)]
        public string ContentType { get; set; }

        [Required]
        [StringLength(150)]
        public string Caption { get; set; }

        [Required]
        public Actor Actor { get; set; }

        [Required]
        [StringLength(150)]
        public string StringId { get; set; }
    }
}