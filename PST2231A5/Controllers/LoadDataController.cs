using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PST2231A5.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LoadDataController : Controller
    {
        // Reference to the manager object
        Manager m = new Manager();

        // GET: LoadData
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (m.LoadData())
            {
                return Content("data has been loaded");
            }
            else
            {
                return Content("data exists already");
            }
        }

        public ActionResult LoadGenres()
        {
            if (m.LoadGenres())
            {
                return Content("Genre data has been loaded");
            }
            else
            {
                return Content("Genre data exists already");
            }
        }

        public ActionResult LoadActors()
        {
            if (m.LoadActors())
            {
                return Content("Actor data has been loaded");
            }
            else
            {
                return Content("Actor data exists already");
            }
        }

        public ActionResult LoadShows()
        {
            if (m.LoadShows())
            {
                return Content("Show data has been loaded");
            }
            else
            {
                return Content("Show data exists already");
            }
        }

        public ActionResult LoadEpisodes()
        {
            if (m.LoadEpisodes())
            {
                return Content("Episode data has been loaded");
            }
            else
            {
                return Content("Episode data exists already");
            }
        }

        public ActionResult Remove()
        {
            if (m.RemoveData())
            {
                return Content("data has been removed");
            }
            else
            {
                return Content("could not remove data");
            }
        }

        public ActionResult RemoveDatabase()
        {
            if (m.RemoveDatabase())
            {
                return Content("database has been removed");
            }
            else
            {
                return Content("could not remove database");
            }
        }

    }
}