using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreMVC.Models;

namespace MusicStoreMVC.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre

        public static List<Genre> genreList = new List<Genre>
        {
            new Genre() {GenreId = 0, Name = "Rock"},
            new Genre() {GenreId = 2, Name = "Metal"},
            new Genre() {GenreId = 1, Name = "Rap/Hip-Hop"},
            new Genre() {GenreId = 3, Name = "Pop"}
        };
        public ActionResult Index()
        {
            return View(genreList);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateNew(Genre g)
        {
            genreList.Add(g);
            return RedirectToAction("Index", "Genre");
        }
    }
}