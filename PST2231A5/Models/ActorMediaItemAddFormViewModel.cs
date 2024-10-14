using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class ActorMediaItemAddFormViewModel
    {
        public int ActorId { get; set; }

        public string ActorName { get; set; }

        [Required]
        [StringLength(150)]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Attachment")]
        [DataType(DataType.Upload)]
        public string ContentUpload { get; set; }
    }
}