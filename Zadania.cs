using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ksiazka ksiazka1 = new Ksiazka("Rambo - Pierwsza Krew", "Sylvester Stallone", 1982);
            Ksiazka ksiazka2 = new Ksiazka("Terminator - Dzień Sądu", "Arnold Schwarzenegger", 1991);
            Ksiazka ksiazka3 = new Ksiazka("Pan i Pani Smith", "Angelina Jolie & Brad Pitt", 2005);

            Console.WriteLine($"Nazwa twojej ksiazki to: {ksiazka1.Tytul}, autorem jest {ksiazka1.Autor}, a jej rok wydania to {ksiazka1.rok_wydania}.");
            Console.WriteLine($"Nazwa twojej ksiazki to: {ksiazka2.Tytul}, autorem jest {ksiazka2.Autor}, a jej rok wydania to {ksiazka2.rok_wydania}.");
            Console.WriteLine($"Nazwa twojej ksiazki to: {ksiazka3.Tytul}, autorem jest {ksiazka3.Autor}, a jej rok wydania to {ksiazka3.rok_wydania}.");

            List<Ksiazka> lista_ksiazek = new List<Ksiazka>
            {
                ksiazka1, ksiazka2, ksiazka3
            };

            Console.WriteLine("\nKsiazki autora 'Sylvester Stallone':");
            wypisz_aktora(lista_ksiazek, "Sylvester Stallone");

            Console.WriteLine("\nKsiazki wydane w roku 1991:");
            wypisz_rok(lista_ksiazek, 1991);

            edytuj_ksiazke(lista_ksiazek, "Rambo - Pierwsza Krew", "Bambi", "David Hand", 1942);
            Console.WriteLine("\nWszystkie książki po edycji:");
            wypisz_ksiazki(lista_ksiazek);

            usun_ksiazke(lista_ksiazek, "Terminator - Dzień Sądu");
            Console.WriteLine("\nWszystkie książki po usunięciu:");
            wypisz_ksiazki(lista_ksiazek);

            List<Ksztalt> lista_ksztaltow = new List<Ksztalt>
            {
                new Prostokat(4, 5),
                new Trojkat(3, 4, 5),
                new Kolo(3),
                new Prostokat(3, 3),
                new Trojkat(3, 6, 9),
                new Kolo(5),
            };

            Console.WriteLine("\nPola dla kzstaltow o obwodzie wiekszym od 10:");
            foreach (var ksztalt in lista_ksztaltow)
            {
                if (ksztalt.Obwod() > 10)
                {
                    Console.WriteLine($"Pole: {ksztalt.Pole()}, Obwod: {ksztalt.Obwod()}");
                }
            }
        }

        static void wypisz_aktora(List<Ksiazka> lista, string autor)
        {
            foreach (var ksiazka in lista)
            {
                if (ksiazka.Autor == autor)
                {
                    Console.WriteLine($"Tytuł: {ksiazka.Tytul}, Autor: {ksiazka.Autor}, Rok wydania: {ksiazka.rok_wydania}");
                }
            }
        }

        static void wypisz_rok(List<Ksiazka> lista, int rok)
        {
            foreach (var ksiazka in lista)
            {
                if (ksiazka.rok_wydania == rok)
                {
                    Console.WriteLine($"Tytuł: {ksiazka.Tytul}, Autor: {ksiazka.Autor}, Rok wydania: {ksiazka.rok_wydania}");
                }
            }
        }

        static void edytuj_ksiazke(List<Ksiazka> lista, string staryTytul, string nowyTytul, string nowyAutor, int nowyRok)
        {
            foreach (var ksiazka in lista)
            {
                if (ksiazka.Tytul == staryTytul)
                {
                    ksiazka.Tytul = nowyTytul;
                    ksiazka.Autor = nowyAutor;
                    ksiazka.rok_wydania = nowyRok;
                    break;
                }
            }
        }

        static void usun_ksiazke(List<Ksiazka> lista, string tytul)
        {
            lista.RemoveAll(ksiazka => ksiazka.Tytul == tytul);
        }

        static void wypisz_ksiazki(List<Ksiazka> lista)
        {
            foreach (var ksiazka in lista)
            {
                Console.WriteLine($"Tytuł: {ksiazka.Tytul}, Autor: {ksiazka.Autor}, Rok wydania: {ksiazka.rok_wydania}");
            }
        }

        public class Ksiazka
        {
            public string Tytul;
            public string Autor;
            public int rok_wydania;

            public Ksiazka() { }

            public Ksiazka(string tytul, string autor, int rok_wydania)
            {
                Tytul = tytul;
                Autor = autor;
                rok_wydania = rok_wydania;
            }
        }

        public abstract class Ksztalt
        {
            public abstract double Pole();
            public abstract double Obwod();
        }

        public class Prostokat : Ksztalt
        {
            public double X { get; }
            public double Y { get; }

            public Prostokat(double x, double y)
            {
                X = x;
                Y = y;
            }

            public override double Pole()
            {
                return X * Y;
            }

            public override double Obwod()
            {
                return 2 * (X + Y);
            }
        }

        public class Trojkat : Ksztalt
        {
            public double A { get; }
            public double B { get; }
            public double C { get; }

            public Trojkat(double a, double b, double c)
            {
                A = a;
                B = b;
                C = c;
            }

            public override double Pole()
            {
                double p = (A + B + C) / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }

            public override double Obwod()
            {
                return A + B + C;
            }
        }

        public class Kolo : Ksztalt
        {
            public double R { get; }

            public Kolo(double r)
            {
                R = r;
            }

            public override double Pole()
            {
                return Math.PI * R * R;
            }

            public override double Obwod()
            {
                return 2 * Math.PI * R;
            }
        }
    }
}
