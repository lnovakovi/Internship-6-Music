using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
    }
}
