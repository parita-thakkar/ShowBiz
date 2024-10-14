using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class ShowWithDetailViewModel : ShowBaseViewModel
    {
        public ShowWithDetailViewModel()
        {
            Actors = new List<ActorBaseViewModel>();
            Episodes = new List<EpisodeBaseViewModel>();
            ReleaseDate = DateTime.Now;
        }

        [StringLength(250)]
        public string Premise { get; set; }

        [DisplayName("Cast")]
        public IEnumerable<ActorBaseViewModel> Actors { get; set; }

        [DisplayName("Episodes")]
        public IEnumerable<EpisodeBaseViewModel> Episodes { get; set; }
    }
}