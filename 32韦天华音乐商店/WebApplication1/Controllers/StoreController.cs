using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }

        //
        // GET: /Store/Browse
        [HttpPost]
        [ValidateAntiForgeryToken]//防止过多发布
        public string Browse()
        {
            return "Hello from Store.Browse()";
        }
        //
        // GET: /Store/Details
        [HttpPost]
        [ValidateAntiForgeryToken]//防止过多发布
        public string Details()
        {
            return "Hello from Store.Details()";
        }
        //
        // GET: /Store/Browse?genre=Disco
        public ActionResult Browse(string genre)
        {
            var genreModel = new Genre { Name = genre };
            return View(genreModel);
        }
        //
        // GET: /Store/Details/5
        

        public ActionResult Details(int id)
        {
            var album = new Album { Title = "Album " + id };
            return View(album);
        }
    }
}