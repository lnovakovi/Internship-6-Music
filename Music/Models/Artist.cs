using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

        public List<Album> _ListOfAlbumsOfArtists;

    }
}
