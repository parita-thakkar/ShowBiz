using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class ActorMediaItemAddViewModel
    {
        public int ActorId { get; set; }

        [Required]
        [StringLength(150)]
        public string Caption { get; set; }

        [Required]
        public HttpPostedFileBase ContentUpload { get; set; }
    }
}