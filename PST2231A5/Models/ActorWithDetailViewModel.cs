using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PST2231A5.Models
{
    public class ActorWithDetailViewModel : ActorBaseViewModel
    {
        public ActorWithDetailViewModel()
        {
            Shows = new List<ShowBaseViewModel>();
            BirthDate = DateTime.Now;
            ActorMediaItems = new List<ActorMediaItemBaseViewModel>();

        }

        [DisplayName("Appeared in")]
        public int ShowsCount { get; set; }

        [StringLength(250)]
        public string Biography { get; set; }

        public IEnumerable<ShowBaseViewModel> Shows { get; set; }

        public IEnumerable<ActorMediaItemBaseViewModel> ActorMediaItems { get; set; }
    }
}