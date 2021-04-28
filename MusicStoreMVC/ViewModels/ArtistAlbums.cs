using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStoreMVC.Models;

namespace MusicStoreMVC.ViewModels
{
    public class ArtistAlbums
    {
        public Artist Artist { get; set; }
        public List<Album> Albums { get; set; }

    }
}