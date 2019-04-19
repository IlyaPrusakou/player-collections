using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audioplayer
{
    class Song
    {
        public int duration;
        public string title;
        public string songPath;
        public string lyrics;
        public string songGenre;
        public Artist artist;
        public Album album;
        public Player player;
        public List<Playlist> playlists = new List<Playlist>();


    }
}