using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Audioplayer
{
    class Program
    {

        //B5-Player7/10. OutRefParameters.
        public static int TotalDur;
        public static string Prop = "s";
        public static int CreateSong(List<Song> s, ref int xshort, ref int ylong, out string _shortname, out string _longname)
        {
            Random rnd = new Random();
            _shortname = Prop;
            _longname = Prop;
            for (int i = 0; i < s.Count; i++)
            {
                
                s[i] = new Song();
                s[i].title = "songN" + i;
                WriteLine(s[i].title);
                s[i].duration = rnd.Next(500);
                WriteLine(s[i].duration);
                TotalDur = TotalDur + s[i].duration;
                WriteLine($"iteration {i} " + TotalDur);
                if (s[i].duration < xshort)
                {
                    xshort = s[i].duration;
                    _shortname = s[i].title;
                }
                if (s[i].duration > ylong)
                {
                    ylong = s[i].duration;
                    _longname = s[i].title;
                }
            }
            WriteLine(xshort + " " + _shortname);
            WriteLine(ylong + " " + _longname);
            return TotalDur;
        }
        // helper
        public static string GeneratorRandomStrings()
            
        {
            Random rndgen = new Random();
            string randomstring = "s";
            for (int i = 1; i < 5; i++)
            {
                randomstring = randomstring + Convert.ToString((char)rndgen.Next(100));
            }
            WriteLine("Result random generate" + randomstring);
            return randomstring;
        }
        //B5-Player9/10. MethodOverloading and B5-Player6/10. MethodParameters. 
        public static Song InitSong()
        {
            Random rndDefault = new Random();
            Song defaultsong = new Song();
            defaultsong.title = GeneratorRandomStrings();
            defaultsong.duration = rndDefault.Next(500);
            defaultsong.album = new Album ();
            defaultsong.artist = new Artist();
            defaultsong.lyrics = GeneratorRandomStrings();
            defaultsong.songPath = GeneratorRandomStrings();
            defaultsong.playlists = new List<Playlist>();
            return defaultsong;
        }
        public static Song InitSong(string _name)
        {
            var defsong = InitSong();
            defsong.title = _name;
            return defsong;
        }
        public static Song InitSong(string _title, int dur, Album _album, Artist _artist, string _lyrics, List<Playlist> _playlist)
        {
            Song initsong = new Song();
            initsong.title = _title;
            initsong.duration = dur;
            initsong.album = _album;
            initsong.artist = _artist;
            initsong.lyrics = _lyrics;
            initsong.songPath = GeneratorRandomStrings();
            initsong.playlists = _playlist;
            return initsong;
        }
        //B5-Player10/10. DefaultAndNamedParamters.
        public static Artist AddArtist(string _name = "unknown artist")
        {
            Artist artist = new Artist();
            artist.name = _name;
            return artist;
        }
        public static Album AddAlbum(string _name = "unknown album", int _year = 0)
        {
            Album album = new Album();
            album.name = _name;
            album.year = _year;
            return album;
        }
        static void Main(string[] args)
        {

            Player player = new Player(); //try new methods (shufle and sortbytitle)

            List<Song> songList = new List<Song>(); //try new methods (shufle and sortbytitle)
            for (int i = 0; i < 40; i++) //try new methods (shufle and sortbytitle)
            {
                songList.Add(new Song { title = "ssss" + i }); //try new methods (shufle and sortbytitle)
            }
            
            var TestShufle = player.Shufle(songList); //try new methods (shufle and sortbytitle)

            foreach (Song item in TestShufle) //try new methods (shufle and sortbytitle)
            {
                WriteLine("Unsorted     " + item.title); //try new methods (shufle and sortbytitle)
            }
            var SortedTEST = player.SortByTitle(TestShufle); //try new methods (shufle and sortbytitle)
            foreach (Song item in SortedTEST) //try new methods (shufle and sortbytitle)
            {
                WriteLine("Sortedtest   " + item.title); //try new methods (shufle and sortbytitle)
            }
            // B5-Player2/10. Fields.
            Song song1 = new Song();

            song1.duration = 300;
            song1.title = "Cvet nastroenia sinii";
            song1.songGenre = "Metal";
            song1.lyrics = "lalala";
            song1.artist = new Artist{name = "Kirkorov"};

            // B5-Player2/10. Fields.
            Song song2 = new Song();
            song2.duration = 300;
            song2.title = "Anaconda";
            song2.songGenre = "Pop";
            song2.lyrics = "lalala";
            song2.artist = new Artist
            {
                name = "Minaj",
                band = new Band
                {
                    bandYear = 1988,
                    isExist = true
                }
            };
            song2.album = new Album
            {
                name = "MinajAlbum",
                path = "pathAlbum",
                year = 1988
            };
            
            song2.artist.band.bandTitle = "MinajBand";
            

            WriteLine("Now we try to use your keyboard");

            
            while (true)
            {
                switch (ReadLine())
                {
                    case "a":
                        {
                            player.VolumeUp();
                            break;
                        }
                    case "s":
                        {
                            player.VolumeDown();
                            break;
                        }
                    case "d":
                        {
                            player.Play();
                            break;
                        }
                    case "q":
                        {
                            player.Lock();
                            break;
                        }
                    case "w":
                        {
                            player.UnLock();
                            break;
                        }
                    case "e":
                        {
                            player.Start();
                            break;
                        }
                    case "r":
                        {
                            player.Stop();
                            break;
                        }

                }
            }



            ReadLine();
        }
    }
}