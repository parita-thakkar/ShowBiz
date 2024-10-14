using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class ActorMediaItemContentViewModel
    {
        [Key]
        public int Id { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}