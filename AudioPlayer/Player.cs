using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audioplayer
{
    class Player
    {
        public class CompareHelper : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (Convert.ToInt32(x[x.Length - 1]) < Convert.ToInt32(y[y.Length - 1]))
                {
                    return -1;
                }
                else if (Convert.ToInt32(x[x.Length - 1]) > Convert.ToInt32(y[y.Length - 1]))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private int volume;
        public const int minVolume = 0;
        public const int maxVolume = 100;
        public bool isLock;
        private bool playing;
        public List<Song> songs;
        public Random rnd = new Random();
        public CompareHelper Comp = new CompareHelper();
            
        //B5-Player4/10. Properties.
        public bool Playing
        {
            get
            {
                return playing;
            }
        }
         
        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value < minVolume)
                {
                    volume = minVolume;
                }
                else if (value > maxVolume)
                {
                    volume = maxVolume;
                }
                else
                {
                    volume = value;
                }
            }

        }
        //B5-Player8/10. ParamsParameters
        public void ParametrSong(params Song[] SongList)
        {
            foreach (Song item in SongList)
            {
                Console.WriteLine(item.title);
            }
        }
        //B5-Player3/10. Method. 
        public void VolumeUp()
        {
            Volume = Volume + 1;
            Console.WriteLine("Volume " + Volume);

        }

        public void VolumeDown()
        {
            Volume = Volume - 1;
            Console.WriteLine("Volume " + Volume);
        }
        public void VolumeChange(int Step, string op)
        {
            if (op == "+")
            {
                Console.WriteLine($"up volume {Step}");
                Volume = Volume + Step;
            }
            else if (op == "-")
            {
                Console.WriteLine($"down volume {Step}");
                Volume = Volume - Step;
            }
        }
        public void Play(bool Loop = false)
        {
            if (Loop == false)
            {
                Shufle(songs);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Shufle(songs);
                }
            }
            if (playing == true)
            {
                Console.WriteLine("to Play has started");
                for (int i = 0; i < songs.Count; i++)
                {
                    Console.WriteLine(songs[i].title);
                    System.Threading.Thread.Sleep(2000);
                }
            }

        }
        public void LyricsOutput()
        {
            foreach (Song item in songs)
            {
                Console.WriteLine($"{item.title} --- {item.lyrics}");
            }
        }
        public bool Stop()
        {
            if (isLock == false)
            {
                Console.WriteLine("Stop");
                playing = false;
            }

            return playing;
        }
        public bool Start()
        {
            if (isLock == false)
            {
                Console.WriteLine("Start");
                playing = true;
            }

            return playing;
        }
        public void Pause()
        {
        }
        public void Lock()
        {
            Console.WriteLine("Player is locked");
            Console.WriteLine("Before action " + isLock);
            isLock = true;
            Console.WriteLine("After action " + isLock);
        }
        public void UnLock()
        {
            Console.WriteLine("Player is unlocked");
            Console.WriteLine("Before action " + isLock);
            isLock = false;
            Console.WriteLine("After action " + isLock);
        }
        public void Load()
        {
        }
        public void Save()
        {
        }

        public List<Song> Shufle(List<Song> oldList)
        {
            List<Song> newList = new List<Song>();
            for (int i = 0; i < oldList.Count + 1000; i++)
            {
                int index = rnd.Next(0, oldList.Count);
                if (!(newList.Contains(oldList[index])))
                {
                    newList.Add(oldList[index]);
                }
                else if (newList.Contains(oldList[index])) 
                {
                    continue;
                }
            }
            return newList;
        }

        public List<Song> SortByTitle(List<Song> oldList)
        {
            List<Song> sortedSongsList = new List<Song>();
            List<string> titleList = new List<string>();
            foreach (Song item in oldList)
            {
                titleList.Add(item.title);
                
            }
             titleList.Sort(Comp);
            for (int i = 0; i < titleList.Count; i++)
            {
                for (int j = 0; j < oldList.Count; j++)
                {
                    if (titleList[i] == oldList[j].title)
                    {
                        sortedSongsList.Add(oldList[j]);
                    }
                }
                
            }
            return sortedSongsList;
        }
    }
}