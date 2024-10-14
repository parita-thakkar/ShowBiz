using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class EpisodeWithDetailViewModel : EpisodeBaseViewModel
    {
        [Key]
        public int Id { get; set; }

        //public EpisodeWithDetailViewModel()
        //{
        //    Shows = new List<ShowBaseViewModel>();
        //}

        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Premise { get; set; }

        [Display(Name = "Video Attachment")]
        public string VideoUrl
        {
            get
            {
                return $"/video/{Id}";
            }
        }

        public string VideoContentType { get; set; }

        //public IEnumerable<ShowBaseViewModel> Shows { get; set; }
    }
}