using System;
using System.Collections.Generic;

namespace SzafaGrajaca
{
    class Program
    {
        static void Main(string[] args)
        {
            bool czyKoniec = true;
            Plyta p1 = new Plyta("Kai Straw", "GUN", "Nie wiem", new List<string> { "They Send You", "Cherry Corvette", "Rolls", "The Recipe", "#1 Customer", "Jesse James" });
            Plyta p2 = new Plyta("Ja", "Autko", "Rozne", new List<string> { "Bangier", "August", "Harnas Ice Tea", "Mexico", "Wendy", "Oreo" });

            SzafaGra szafka = new SzafaGra();
            szafka.dodajPlyte(p1);
            szafka.dodajPlyte(p2);

            #region Menu
            do
            {
                Console.WriteLine("\n\nMenu:");
                Console.WriteLine("1) Pokaz plyty");
                Console.WriteLine("2) Dodaj plyte");
                Console.WriteLine("3) Wybierz plyte");
                Console.WriteLine("4) Nastepny utwor");
                Console.WriteLine("5) Zakoncz sluchanie plyty");
                Console.WriteLine("6) Exit");
                Console.Write("\r\nWybierz madrze: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        szafka.pokazTytulyAlbomow();
                        break;
                    case "2":
                        szafka.dodajPlyte();
                        break;
                    case "3":
                        szafka.wybierzPlyte();
                        break;
                    case "4":
                        szafka.nastepnaPiosenka();
                        break;
                    case "5":
                        szafka.zakonczOdtwarzanie();
                        break;
                    case "6":
                        Console.WriteLine("Do widzenia");
                        czyKoniec = false;
                        break;
                    default:
                        break;
                }
            } while (czyKoniec);

            #endregion
        }

    }

    class Plyta
    {
        public string nazwa_albumu, wykonawca, rodzaj_muzyki;
        public List<string> nazwy_utworow = new List<string>();
        public int ilosc_utworow;

        public Plyta(string _nazwa_albumu, string _wykonawca, string _rodzaj_muzyki, List<string> _lista)
        {
            nazwa_albumu = _nazwa_albumu;
            wykonawca = _wykonawca;
            rodzaj_muzyki = _rodzaj_muzyki;
            foreach (string l in _lista)
            {
                nazwy_utworow.Add(l);
            }
            ilosc_utworow = _lista.Count;

        }
    }


    class SzafaGra
    {
        public List<Plyta> plytoteka = new List<Plyta>();
        public int aktualnaPiosenka;
        public int aktualnaPlyta;


        public SzafaGra()
        {
            aktualnaPiosenka = -1;
            aktualnaPlyta = -1;
        }

        public void pokazTytulyAlbomow()
        {
            Console.Clear();
            for (int i = 0; i < plytoteka.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {plytoteka[i].nazwa_albumu}");
            }
        }

        public void wybierzPlyte()
        {
            Console.Clear();
            aktualnaPiosenka = 0;
            aktualnaPlyta = 0;
            pokazTytulyAlbomow();
            Console.Write("Którą płytę załadować?: ");
            aktualnaPlyta = (Convert.ToInt32(Console.ReadLine()) - 1);
            switch (plytoteka.Count > aktualnaPlyta)
            {
                case true:
                    Console.WriteLine($"\nTytul albumu: {plytoteka[aktualnaPlyta].nazwa_albumu}");
                    Console.WriteLine($"Tytul piosenki: {plytoteka[aktualnaPlyta].nazwy_utworow[aktualnaPiosenka]}");
                    break;
                case false:
                    Console.WriteLine("Podana wartosc jest za duza");
                    wybierzPlyte();
                    break;
            }


        }

        public void dodajPlyte(Plyta _plyta)
        {
            plytoteka.Add(_plyta);
        }

        public void dodajPlyte()
        {
            Console.Clear();
            string autor = "";
            string gatunek = "";
            string nazwa = "";
            string cn = "";
            List<string> plyta = new List<string>();
            int licznik = 1;

            Console.Write("Podaj autora: ");
            autor = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Podaj nazwe albumu: ");
            nazwa = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Podaj gatunek: ");
            gatunek = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Podaj nazwy kolejnych utworow na tej plycie, albo pusty znak by zakończyć: ");
            do
            {
                Console.WriteLine($"Utwor nr. {licznik}: ");
                cn = Console.ReadLine();
                if(cn != "")
                {
                    plyta.Add(cn);
                    licznik++;
                }
                else
                {
                    break;
                }

            } while (cn != "");
            Plyta plytas = new Plyta(nazwa, autor, gatunek, plyta);
            plytoteka.Add(plytas);

        }

        public void nastepnaPiosenka()
        {
            Console.Clear();
            if (aktualnaPiosenka == -1)
            {
                Console.WriteLine("Nie ma wybranej plyty do odtworzenia");
            }
            else
            {
                if (aktualnaPiosenka + 1 == plytoteka[aktualnaPlyta].nazwy_utworow.Count)
                {
                    aktualnaPiosenka = -1;
                    Console.WriteLine("Nie ma juz piosenek na tej plycie. Wybierz kolejna");
                }
                else
                {
                    aktualnaPiosenka += 1;
                    Console.WriteLine($"Odtwarzam: {plytoteka[aktualnaPlyta].nazwy_utworow[aktualnaPiosenka]}");
                }

            }

        }

        public void zakonczOdtwarzanie()
        {
            Console.Clear();
            aktualnaPiosenka = -1;
            aktualnaPlyta = -1;
            Console.WriteLine("Sluchanie zakonczone odtworz kolejna plyte");
        }


    }
}
