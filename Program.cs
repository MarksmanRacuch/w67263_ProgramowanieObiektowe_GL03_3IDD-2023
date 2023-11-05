using System;

class Program
{
    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Sprawdz parzystosc liczby");
            Console.WriteLine("2. Wyswietl parzyste liczby od 1 do N");
            Console.WriteLine("3. Oblicz silnie");
            Console.WriteLine("4. Gra w zgadywanie liczby");
            Console.WriteLine("5. Przelicz jednostki miar");
            Console.WriteLine("0. Wyjscie");
            Console.Write("Wybierz opcjke: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        SprawdzParzystoscLiczby();
                        break;
                    case 2:
                        WyswietlParzysteLiczby();
                        break;
                    case 3:
                        ObliczSilnie();
                        break;
                    case 4:
                        GraZgadywanieLiczby();
                        break;
                    case 5:
                        PrzeliczJednostkiMiar();
                        break;
                    case 0:
                        Console.WriteLine("Koniec programu.");
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybor.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny wybor.");
            }
        } while (choice != 0);
    }

    static void SprawdzParzystoscLiczby()
    {
        Console.Write("Podaj liczbe: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            if (number % 2 == 0)
            {
                Console.WriteLine("Podana liczba jest parzysta.");
            }
            else
            {
                Console.WriteLine("Podana liczba jest nieparzysta.");
            }
        }
        else
        {
            Console.WriteLine("Wprowadzony znak nie jest liczba.");
        }
    }

    static void WyswietlParzysteLiczby()
    {
        Console.Write("Podaj liczbe N: ");
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        else
        {
            Console.WriteLine("To nie jest poprawna liczba calkowita.");
        }
    }

    static long CalculateFactorial(int n)
    {
        if (n == 0)
            return 1;
        return n * CalculateFactorial(n - 1);
    }

    static void ObliczSilnie()
    {
        Console.Write("Podaj liczbe n do obliczenia silni: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
        {
            long result = CalculateFactorial(n);
            Console.WriteLine($"{n}! = {result}");
        }
        else
        {
            Console.WriteLine("To nie jest poprawna liczba calkowita lub jest mniejsza od zera.");
        }
    }

    static void GraZgadywanieLiczby()
    {
        Random random = new Random();
        int numberToGuess = random.Next(1, 101); 
        int attempts = 0;

        Console.WriteLine("Witaj w grze w zgadywanie liczby!");

        while (true)
        {
            Console.Write("Zgadnij liczbe (od 1 do 100): ");
            if (int.TryParse(Console.ReadLine(), out int guess))
            {
                attempts++;

                if (guess == numberToGuess)
                {
                    Console.WriteLine($"Gratulacje! Zgadłes liczbe {numberToGuess} w {attempts} probach.");
                    break;
                }
                else if (guess < numberToGuess)
                {
                    Console.WriteLine("Podana liczba jest za mała. Sprobuj ponownie.");
                }
                else
                {
                    Console.WriteLine("Podana liczba jest za duza. Sprobuj ponownie.");
                }
            }
            else
            {
                Console.WriteLine("To nie jest poprawna liczba całkowita.");
            }
        }
    }

    static void PrzeliczJednostkiMiar()
    {
        Console.WriteLine("Przeliczanie jednostek miar:");
        Console.WriteLine("1. Przelicz temperature (Celsjusz na Fahrenheita)");
        Console.WriteLine("2. Przelicz długosc (metry na centymetry)");
        Console.Write("Wybierz opcje: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    Console.Write("Podaj temperature w stopniach Celsjusza: ");
                    if (double.TryParse(Console.ReadLine(), out double celsius))
                    {
                        double fahrenheit = (celsius * 9 / 5) + 32;
                        Console.WriteLine($"{celsius}°C = {fahrenheit}°F");
                    }
                    else
                    {
                        Console.WriteLine("To nie jest poprawna temperatura w stopniach Celsjusza.");
                    }
                    break;
                case 2:
                    Console.Write("Podaj długosc w metrach: ");
                    if (double.TryParse(Console.ReadLine(), out double meters))
                    {
                        double centimeters = meters * 100;
                        Console.WriteLine($"{meters} m = {centimeters} cm");
                    }
                    else
                    {
                        Console.WriteLine("To nie jest poprawna długosc w metrach.");
                    }
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybor.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Niepoprawny wybor.");
        }
    }
}
