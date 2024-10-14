using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class EpisodeVideoViewModel
    {
        [Key]
        public int Id { get; set; }

        public string VideoContentType { get; set; }

        public byte[] Video { get; set; }
    }
}