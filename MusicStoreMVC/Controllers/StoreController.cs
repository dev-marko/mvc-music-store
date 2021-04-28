using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreMVC.Models;
using MusicStoreMVC.ViewModels;


namespace MusicStoreMVC.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult List()
        {
            Artist artist = new Artist { Name = "Travis Scott" };
            var albums = new List<Album>();

            albums.Add(new Album { AlbumId = 0, Title = "Rodeo" });
            albums.Add(new Album { AlbumId = 1, Title = "Birds In The Trap Sing McKnight" });
            albums.Add(new Album { AlbumId = 2, Title = "Astroworld" });
            albums.Add(new Album { AlbumId = 3, Title = "JACKBOYS" });

            var viewModel = new ArtistAlbums
            {
                Artist = artist,
                Albums = albums
            };

            return View(viewModel);
        }

        public ActionResult ShowSearch()
        {
            return View();
        }

        public ActionResult Search(string q)
        {
            var albums = new List<Album>();

            albums.Add(new Album { AlbumId = 0, Title = "Days Before Rodeo" });
            albums.Add(new Album { AlbumId = 1, Title = "Rodeo" });
            albums.Add(new Album { AlbumId = 2, Title = "Birds In The Trap Sing McKnight" });
            albums.Add(new Album { AlbumId = 3, Title = "Astroworld" });
            albums.Add(new Album { AlbumId = 4, Title = "JACKBOYS" });

            var resultAlbums = new List<Album>();

            foreach (Album a in albums)
            {
                if (a.Title.ToLower().Contains(q.ToLower()))
                {
                    resultAlbums.Add(a);
                }
            }

            return View(resultAlbums);
        }

        [Route("store/details/{artistId}/{albumName}")]
        public string Details(int? artistId, string albumName)
        {
            return "Artist = " + artistId + ", Album = " + albumName;
        }
    }
}