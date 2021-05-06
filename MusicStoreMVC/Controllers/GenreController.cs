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
        private ApplicationDbContext _contex;

        public GenreController()
        {
            _contex = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contex.Dispose();
            base.Dispose(disposing);
        }

        /*        public static List<Genre> genreList = new List<Genre>
                {
                    new Genre() {GenreId = 0, Name = "Rock"},
                    new Genre() {GenreId = 2, Name = "Metal"},
                    new Genre() {GenreId = 1, Name = "Rap/Hip-Hop"},
                    new Genre() {GenreId = 3, Name = "Pop"}
                };*/
        public ActionResult Index()
        {
            var genreList = _contex.Genres.ToList();
            return View(genreList);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateNew(Genre g)
        {
            _contex.Genres.Add(g);
            _contex.SaveChanges();

            return RedirectToAction("Index", "Genre");
        }

        public ActionResult Delete(int id)
        {
            /*            foreach(Genre g in genreList.ToList())
                        {
                            if (g.GenreId == id)
                            {
                                genreList.Remove(g);
                            }
                        }*/

            Genre searchResult = _contex.Genres.Find(id);
            _contex.Genres.Remove(searchResult);
            _contex.SaveChanges();

            return RedirectToAction("Index", "Genre");
        }

        public ActionResult Edit(int id)
        {
            /*            var genre = new Genre() { GenreId = -1 };

                        foreach(Genre g in genreList.ToList())
                        {
                            if (g.GenreId == id)
                            {
                                genre = g;
                            }
                        }

                        if (genre.GenreId == -1)
                        {
                            return HttpNotFound();
                        }*/

            var searchResult = _contex.Genres.Single(g => g.GenreId == id);

            if (searchResult == null)
            {
                return HttpNotFound();
            }

            return View(searchResult);
        }

        public ActionResult EditGenre(Genre genre)
        {
            /*            foreach (Genre g in genreList.ToList())
                        {
                            if (g.GenreId == genre.GenreId)
                            {
                                g.Name = genre.Name;
                            }
                        }*/

            var genreInDb = _contex.Genres.Single(g => g.GenreId == genre.GenreId);
            TryUpdateModel(genreInDb);
            _contex.SaveChanges();

            return RedirectToAction("Index", "Genre");
        }
    }
}