using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PST2231A5.Controllers
{
    public class GenresController : Controller
    {
        Manager m = new Manager();

        // GET: Genres
        public ActionResult Index()
        {
            var allGenres = m.GenreGetAll();
            return View(allGenres);
        }
    }
}
