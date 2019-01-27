using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }

        public List<Album> _listOfAlbums;
    }
}
