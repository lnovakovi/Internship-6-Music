using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Xml.Xsl;
using Dapper;
using Music.Models;

namespace Music
{
    class Program
    {
        static void Main(string[] args)
        {

            var connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=MUSIC;Integrated Security=true;" +
                                   "MultipleActiveResultSets=true;";

            var artists = new SqlConnection(connectionString).Query<Artist>("select * from artists").ToList();
            var albums = new SqlConnection(connectionString).Query<Album>("select * from albums").ToList();
            var songs = new SqlConnection(connectionString).Query<Song>("select * from songs").ToList();
            var albumSongs = new SqlConnection(connectionString).Query<AlbumSong>("select * from albumsongs").ToList();
            //relation artist-album
            foreach (var artist in artists)
            {
                artist._ListOfAlbumsOfArtists = new List<Album>();
                foreach (var album in albums)
                {
                    if ( artist.ArtistId == album.ArtistId)
                        artist._ListOfAlbumsOfArtists.Add(album);
                }
            }
            //relation album-songs
            foreach (var album in albums)
            {
                album._ListOfSongs = new List<Song>();              
                foreach (var albumSong in albumSongs)
                {
                    if (albumSong.AlbumId != album.AlbumId) continue;
                    foreach (var song in songs)
                    {
                        if (albumSong.SongId == song.SongId)
                            album._ListOfSongs.Add(song);
                    }
                }
            }
            //relation album - artist name
            foreach (var album in albums)
            {
                foreach (var artist in artists)
                {
                    if (album.ArtistId == artist.ArtistId)
                    {
                        album.ArtistName = artist.Name;
                    }
                }
            }
           
            // 1.sorted by name
            Console.WriteLine("Sorted by name: ");
            var sortedArtists = artists.OrderBy(artist => artist.Name);
            foreach (var artist in sortedArtists)
            {
                Console.WriteLine($"{artist.Name}");
            }

            //2.artists with certain nationality
            Console.WriteLine("\nArtist who is Australain :");
            var nationalityArtist = artists.Where(artist => artist.Nationality == "Australian");
            foreach (var artist in nationalityArtist)
            {
                Console.WriteLine($"{artist.Name} - {artist.Nationality}");
            }

            //3.group by year of issue and show artist of album
            Console.WriteLine("\nGrouped by year of issue: ");
            var groupAlbum = albums.OrderBy(album => album.YearOfIssue );
            foreach (var album in groupAlbum)
            {
               
                 Console.WriteLine($"Album:  {album.Name} - Artist: {album.ArtistName} - Year: {album.YearOfIssue}");
                
            }

            //4.albums that contain certain text
            Console.WriteLine("\nAlbums that contain 'Love' ");
            var certainAlbums = albums.Where(album => album.Name.Contains("Love"));
            foreach (var album in certainAlbums)
            {
                Console.WriteLine($"Name of album: {album.Name}");
            }
            //5.whole duration 
            Console.WriteLine("\nDuration of albums: ");
            foreach (var album in albums)
            {
                var list = album._ListOfSongs;
                var sum = (from x in list select x.Duration.Ticks).Sum();
                Console.WriteLine($"Album: {album.Name} Length: {new TimeSpan(sum)}");
            }

            //6. Albums with certain song 
            Console.WriteLine("\nAlbums with song 'Where Them Girls At': ");
            var selectedAlbums = albums.Select(album =>
                album._ListOfSongs.Where(song => song.Name == " Where Them Girls At"));
            foreach (var album in albums)
            {
                foreach (var song in album._ListOfSongs)
                {
                    if (song.Name == "Where Them Girls At")
                    { Console.WriteLine(album.Name);}
                }
            }
           

            //7. all songs of artist ...
            Console.WriteLine("\nSongs of certain artist released after certain year: (David Guetta and after 2007");
            var selectedSongs = albums.Where(album => album.ArtistName == "Guetta David" && album.YearOfIssue > 2007)
                .Select(album => album._ListOfSongs).SelectMany(x=>x);
            foreach (var selectedSong in selectedSongs)
            {
                Console.WriteLine($"{selectedSong.Name}");
            }
            Console.ReadKey();

        }
    }
}
