using System;
using System.Collections.Generic;

namespace SzafaGrajaca
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasEnded = true;
            Album album1 = new Album("Kai Straw", "GUN", "Soul", new List<string> { "They Send You", "Cherry Corvette", "Rolls", "The Recipe", "#1 Customer", "Jesse James" });
            Album album2 = new Album("Ja", "Autko", "Rozne", new List<string> { "Bangier", "August", "Harnas Ice Tea", "Mexico", "Wendy", "Oreo" });

            JukeBox jukeBox = new JukeBox();
            jukeBox.addAlbum(album1);
            jukeBox.addAlbum(album2);

            #region Menu
            do
            {
                Console.WriteLine("\n\nMenu:");
                Console.WriteLine("1) Show avaliable albums");
                Console.WriteLine("2) Insert your own album");
                Console.WriteLine("3) Pick album");
                Console.WriteLine("4) Next song");
                Console.WriteLine("5) Stop listening to album");
                Console.WriteLine("6) Exit");
                Console.Write("\r\nPick wisely: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        jukeBox.showAlbumTitle();
                        break;
                    case "2":
                        jukeBox.addAlbum();
                        break;
                    case "3":
                        jukeBox.pickAlbum();
                        break;
                    case "4":
                        jukeBox.nextSong();
                        break;
                    case "5":
                        jukeBox.stopPlaying();
                        break;
                    case "6":
                        Console.WriteLine("See you soon");
                        hasEnded = false;
                        break;
                    default:
                        break;
                }
            } while (hasEnded);

            #endregion
        }

    }

    class Album
    {
        public string albumName, author, genre;
        public List<string> songNameList = new List<string>();
        public int songCount;

        public Album(string _albumName, string _author, string _genre, List<string> _list)
        {
            albumName = _albumName;
            author = _author;
            genre = _genre;
            foreach (string l in _list)
            {
                songNameList.Add(l);
            }
            songCount = _list.Count;

        }
    }


    class JukeBox
    {
        public List<Album> allAlbums = new List<Album>();
        public int currSong;
        public int currAlbum;


        public JukeBox()
        {
            currSong = -1;
            currAlbum = -1;
        }

        public void showAlbumTitle()
        {
            Console.Clear();
            for (int i = 0; i < allAlbums.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allAlbums[i].albumName}");
            }
        }

        public void pickAlbum()
        {
            Console.Clear();
            currSong = 0;
            currAlbum = 0;
            showAlbumTitle();
            Console.Write("Wich album would you like to play: ");
            currAlbum = (Convert.ToInt32(Console.ReadLine()) - 1);
            switch (allAlbums.Count > currAlbum)
            {
                case true:
                    Console.WriteLine($"\nAlbum's name: {allAlbums[currAlbum].albumName}");
                    Console.WriteLine($"Name of the song: {allAlbums[currAlbum].songNameList[currSong]}");
                    break;
                case false:
                    Console.WriteLine("Inserted value is too high");
                    pickAlbum();
                    break;
            }


        }

        public void addAlbum(Album _Album)
        {
            allAlbums.Add(_Album);
        }

        public void addAlbum()
        {
            Console.Clear();
            string authorF = "";
            string genreF = "";
            string nameF = "";
            string cn = "";
            List<string> Album = new List<string>();
            int helper = 1;

            Console.Write("Who the author is: ");
            authorF = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Write album's name: ");
            nameF = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Write genre: ");
            genreF = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Write names of the following song in that album, if you ended -> insert blank text: ");
            do
            {
                Console.WriteLine($"Track nr. {helper}: ");
                cn = Console.ReadLine();
                if(cn != "")
                {
                    Album.Add(cn);
                    helperer++;
                }
                else
                {
                    break;
                }

            } while (cn != "");
            Album Albums = new Album(nameF, authorF, genreF, Album);
            allAlbums.Add(Albums);

        }

        public void nextSong()
        {
            Console.Clear();
            if (currSong == -1)
            {
                Console.WriteLine("There is no selected album to play");
            }
            else
            {
                if (currSong + 1 == allAlbums[currAlbum].songNameList.Count)
                {
                    currSong = -1;
                    Console.WriteLine("This album has ended pick another one");
                }
                else
                {
                    currSong += 1;
                    Console.WriteLine($"Playing: {allAlbums[currAlbum].songNameList[currSong]}");
                }

            }

        }

        public void stopPlaying()
        {
            Console.Clear();
            currSong = -1;
            currAlbum = -1;
            Console.WriteLine("Playing has ended, pick another album to play music from");
        }


    }
}
