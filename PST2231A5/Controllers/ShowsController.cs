using PST2231A5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PST2231A5.Controllers
{
    public class ShowsController : Controller
    {
        Manager m = new Manager();

        // GET: Shows
        public ActionResult Index()
        {
            var allShows = m.ShowGetAll();
            return View(allShows);
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            var s = m.ShowGetByID(id.GetValueOrDefault());
            if (s == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(s);
            }
        }

        [Authorize(Roles = "Clerk")]
        [Route("Shows/{id}/AddEpisode")]
        public ActionResult AddEpisode(int id)
        {
            var show = m.ShowGetByID(id);

            var form = new EpisodeAddFormViewModel();
            var genres = m.GenreGetAll();
            form.ShowShowId = show.ShowId;
            form.GenreList = new SelectList(genres, "GenreId", "Name", selectedValue: genres.First().GenreId);

            return View(form);
        }

        [Authorize(Roles = "Clerk")]
        [Route("Shows/{id}/AddEpisode")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddEpisode(EpisodeAddViewModel addEpisode)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(addEpisode);
            //}

            var episode = m.EpisodeAdd(addEpisode);

            if (episode != null)
            {
                return RedirectToAction("Details", "Episodes", new { id = episode.EpisodeId });
            }
            else
            {
                return View(addEpisode);
            }
        }
    }
}
