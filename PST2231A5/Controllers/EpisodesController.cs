using PST2231A5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PST2231A5.Controllers
{
    public class EpisodesController : Controller
    {
        Manager m = new Manager();

        // GET: Episodes
        public ActionResult Index()
        {
            var allEpisodes = m.EpisodeGetAll();
            return View(allEpisodes);
        }

        // GET: Episodes/Details/5
        public ActionResult Details(int? id)
        {
            var episode = m.EpisodeGetByID(id.GetValueOrDefault());
            if (episode == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(episode);
            }
        }

        [Route("episode/{id}")]
        public ActionResult GetEpisodeVideo(int id)
        {
            var v = m.EpisodeVideoGetById(id);
            if (v == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(v.Video, v.VideoContentType);
            }
        }

    }
}