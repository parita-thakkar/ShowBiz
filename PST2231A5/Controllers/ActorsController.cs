using PST2231A5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PST2231A5.Controllers
{
    public class ActorsController : Controller
    {
        Manager m = new Manager();

        // GET: Actors
        public ActionResult Index()
        {
            var allActors = m.ActorGetAll();
            return View(allActors);
        }

        // GET: Actors/Details/5
        public ActionResult Details(int? id)
        {
            var act = m.ActorGetByID(id.GetValueOrDefault());  
            if (act == null)
            {
                return HttpNotFound(); 
            }
            else
            {
                return View(act);
            }
        }

        // GET: Actors/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var a = new ActorAddViewModel();
            a.Executive = User.Identity.Name;

            return View(a);
        }

        // POST: Actors/Create
        [Authorize(Roles = "Executive")]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ActorAddViewModel actorObj)
        {
            var newObj = m.ActorAdd(actorObj);

            if (newObj != null)
            {
                return RedirectToAction("Details", new { id = newObj.ActorId });
            }
            else
            {
                return View(actorObj);
            }
        }

        [Authorize(Roles = "Coordinator")]
        [Route("Actors/{id}/AddShow")]
        public ActionResult AddShow(int? id)
        {
            var actor = m.ActorGetByID(id);
            var allActors = m.ActorGetAll();
            var genres = m.GenreGetAll();
            var form = new ShowAddFormViewModel();

            form.ActorName = actor.Name;
            form.GenreList = new SelectList(genres, "GenreId", "Name", selectedValue: genres.First().GenreId);
            form.ActorList = new MultiSelectList( items: allActors, dataValueField: "ActorId", dataTextField: "Name", selectedValues: new List<int>() { actor.ActorId });

            return View(form);
        }

        [HttpPost, ValidateInput(false)]
        [Route("Actors/{id}/AddShow")]
        public ActionResult AddShow(ShowAddViewModel addShow)
        {
            if (!ModelState.IsValid)
            {
                return View(addShow);
            }

            var show = m.ShowAdd(addShow);

            if (show != null)
            {
                return RedirectToAction("details", "Shows", new { id = show.ShowId });
            }
            else
            {
                return View(addShow);
            }
        }

        public ActionResult AddActorMediaItem(int? id)
        {
            var actor = m.ActorGetByID(id.GetValueOrDefault());

            if (actor == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new ActorMediaItemAddFormViewModel();
                form.ActorId = actor.ActorId;
                form.ActorName = actor.Name;

                return View(form);
            }
        }

        [HttpPost]
        public ActionResult AddActorMediaItem(int? id, ActorMediaItemAddViewModel actorMediaItem)
        {
            if (!ModelState.IsValid)
            {
                return View(actorMediaItem);
            }

            var item = m.ActorMediaItemAdd(actorMediaItem);
            if (item == null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("Details", new { id = item.ActorId });
            }
        }

    }
}
