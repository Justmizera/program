using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Net;




namespace gra.tablicowa
{
    class Program
     

    { //PODAJINT
        public static int PodajInt(string a_sTekst, int a_iMin = int.MinValue, int a_iMax = int.MaxValue)
        {
            while (true)
            {
                try
                {
                    Console.Write(a_sTekst);

                    int _iValue = int.Parse(Console.ReadLine());

                    if (_iValue < a_iMin || _iValue > a_iMax)
                        throw new Exception("Błędny zakres wartości!");

                    return _iValue;

                }
                catch (Exception e)
                {
                    Console.WriteLine("Błąd!" + e.Message);
                }
            }
        }

        public static Random _rnd = new Random();

        //LOSOWE LICZBY 
        static void WylosujWartosc( int[,] a_oPlansza, int a)
        {

            List<int> _LiczbaRunda1 = new List<int>()
            {
                1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8
            }; 
            List<int> _LiczbaRunda2 = new List<int>()
            {
                10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27
            };

            int _iX = a_oPlansza.GetLength(0);
            int _iY = a_oPlansza.GetLength(1);

            for (int _y = 0; _y < _iY; _y++)
            {
                for (int _x = 0; _x < _iX; _x++)
                { if(a==4)
                    {
                        int _index = _rnd.Next(0, _LiczbaRunda1.Count);

                        a_oPlansza[_x, _y] = _LiczbaRunda1[_index];

                        _LiczbaRunda1.RemoveAt(_index);

                        if (_LiczbaRunda1.Count == 0)
                            return;
                    }
                    else if (a==6)
                    {
                        int _index = _rnd.Next(0, _LiczbaRunda2.Count);

                        a_oPlansza[_x, _y] = _LiczbaRunda2[_index];

                        _LiczbaRunda2.RemoveAt(_index);

                        if (_LiczbaRunda2.Count == 0)
                            return;
                    }

                    
                }
            }
        }

        // RYSOWANIE PUNKTÓW
        static void RysujPkt(int[,] a_oPlansza, int y_1, int x_1, int y_2, int x_2,int a)
        {
            for (int _y = 0; _y < 2 * a; _y++)
            {
                if (_y % 2 == 0)
                {
                    for (int _x = 0; _x < 2 * a; _x++)
                    {
                        if (_x % 2 == 0)
                        {
                            if (a_oPlansza[_x / 2, _y / 2] == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(a_oPlansza[_x / 2, _y / 2]);
                            }
                            else if (a_oPlansza[_x / 2, _y / 2] == 99)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(a_oPlansza[_x / 2, _y / 2]);
                            }
                            else if (_y / 2 == y_1 && _x / 2 == x_1)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(a_oPlansza[_x / 2, _y / 2]);
                            }
                            else if (_y / 2 == y_2 && _x / 2 == x_2)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(a_oPlansza[_x / 2, _y / 2]);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(a_oPlansza[_x / 2, _y / 2]);
                            }

                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("|");
                        }
                    }
                }
                else
                {
                    if (a == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("--------");
                    }
                    else if (a == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("------------------");
                    }
                }

                Console.WriteLine();


            }
        }
            
        //RYSOWANIE PLANSZY bez kolorów
        static void RysujPlanszeBlack( int[,] a_oPlansza, int a)
        {
            for (int _y = 0; _y < 2 * a; _y++)
            {
                if (_y % 2 == 0)
                {
                    for (int _x = 0; _x < 2 * a; _x++)
                    {
                        if (_x % 2 == 0)
                        { if (a_oPlansza[_x / 2, _y / 2] == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(a_oPlansza[_x / 2, _y / 2]);
                            }
                            else if (a_oPlansza[_x / 2, _y / 2] == 99)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(a_oPlansza[_x / 2, _y / 2]);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(a_oPlansza[_x / 2, _y / 2]);
                            }
                        }
                       
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("|");
                        }
                    }
                }
                else
                { if (a==4)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("--------");
                    }
                  else if (a==6)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("------------------");
                    }
                    
                }

                Console.WriteLine();

            }
        }
       
        //RYSOWANIE PLANSZY z kolorami
        static void RysujPlanszeWhite( int[,] a_oPlansza,int a)
        {
                
                for (int _y = 0; _y < 2*a; _y++)
                {
                    if (_y % 2 == 0)
                    {
                       for (int _x = 0; _x < 2 * a; _x++)
                       {  
                        if (_x % 2 == 0)
                        {
                            if (a_oPlansza[_x / 2, _y / 2] == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(a_oPlansza[_x / 2, _y / 2]);
                            }
                            else if (a_oPlansza[_x / 2, _y / 2] == 99)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(a_oPlansza[_x / 2, _y / 2]);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(a_oPlansza[_x / 2, _y / 2]);
                            }
                        }
                                              

                         else
                         {
                                
                                Console.Write("|");
                         }
                       }
                    }
                    else
                    {
                        if (a == 4)
                        {
                         Console.ForegroundColor = ConsoleColor.White;
                         Console.Write("--------");
                        }
                     else if (a == 6)
                     {
                         Console.ForegroundColor = ConsoleColor.White;
                         Console.Write("------------------");
                     }
                    }

                    Console.WriteLine();
            

                }
        }
        // SPRAWDZENIE WYGRANEJ
        static void SprawdzCzyWygral(int[,] a_oPlansza, ref int sumaPunktow, int a)
        {
            for (int _y = 0; _y < 2 * a; _y++)
            {
                if (_y % 2 == 0)
                {
                    for (int _x = 0; _x < 2 * a; _x++)
                    {
                        if (_x % 2 == 0)
                        {
                            if (a_oPlansza[_x / 2, _y / 2] == 0)
                            {
                                sumaPunktow = sumaPunktow - 1;
                            }
                            else if (a_oPlansza[_x / 2, _y / 2] == 99)
                            {
                                sumaPunktow = sumaPunktow - 1;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        static void Gra ()
        {
            bool x = true;
            while (x)
            {
                Console.Clear();
                // MENU GŁÓWNE GRY
                Console.WriteLine();
                Console.WriteLine("        Witaj w grze MEMO!");
                Console.WriteLine();
                Console.WriteLine(" KLAWISZ 1        ROZPOCZNIJ GRĘ");
                Console.WriteLine(" KLAWISZ 2        PRZEJDŹ DO INSTRUKCJI GRY");
                Console.WriteLine(" KLAWISZ 3        WYSTAW OPINIĘ O GRZE");
                Console.WriteLine(" KLAWISZ 4        WYJDŹ Z GRY");
                Console.WriteLine();
                int d = PodajInt("Wybieram klawisz nr.: ", 1, 4);

                switch (d)
                {
                    case 1: //GRA
                        Console.Clear();
                        int a = 4;      // zmienna mówiące o rozmiarze tablicy
                                        //PĘTLA RUND
                        while (true)
                        {
                            DateTime Start = DateTime.Now; //czas rozpoczęcia gry

                            Console.WriteLine(Start);

                            int[,] plansza = new int[a, a];     //utworzenie tablicy

                            WylosujWartosc(plansza, a);       //stworzenie losowych wartości na planszy

                            // PĘTLA GRY
                            while (true)
                            {
                                Console.Write("Oto Pozycje par: ");
                                Console.WriteLine();
                                Console.WriteLine();
                                RysujPlanszeWhite(plansza, a);
                                Thread.Sleep(4000);


                                //PĘTLA WPISYWANIA POZYCJI
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    RysujPlanszeBlack(plansza, a);

                                    Console.WriteLine("Podaj współrzędne punktu: ");
                                    while (true)
                                    {

                                        int x_1 = PodajInt("X- kolumnę pierwszego pola: ", 1, a);
                                        int y_1 = PodajInt("Y- wiersz pierwszego pola: ", 1, a);
                                        Console.WriteLine();
                                        int x_2 = PodajInt("X- kolumnę drugiego pola: ", 1, a);
                                        int y_2 = PodajInt("Y- wiersz drugiego pola: ", 1, a);

                                        x_2 = x_2 - 1;
                                        y_2 = y_2 - 1;
                                        x_1 = x_1 - 1;
                                        y_1 = y_1 - 1;

                                        if (x_1 == x_2 && y_1 == y_2)
                                        {// GDY KTOŚ WYBIERZE DWA RAZY TE SAME WSPÓŁRZĘDNE

                                            Console.WriteLine("Nie możesz podawać dwóch takich samych punktów!!!!!!");

                                            continue;
                                        }
                                        else
                                        {
                                            if (plansza[x_1, y_1] == plansza[x_2, y_2]) //GDY KTOŚ WYBIERZE WŁAŚCIWE POLA
                                            {
                                                if (a == 4)
                                                {
                                                    plansza[x_1, y_1] = 0;
                                                    plansza[x_2, y_2] = 0;
                                                    Console.Clear();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    RysujPlanszeBlack(plansza, a);
                                                }
                                                else if (a == 6)
                                                {
                                                    plansza[x_1, y_1] = 99;
                                                    plansza[x_2, y_2] = 99;
                                                    Console.Clear();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    RysujPlanszeBlack(plansza, a);
                                                }

                                            }
                                            else if (plansza[x_1, y_1] != plansza[x_2, y_2])//GDY KTOŚ WYBIERZE NIEWŁAŚCIWE POLA ODKRYJ TYLKO PODANE PUNKTY
                                            {
                                                Console.Clear();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                RysujPkt(plansza, y_1, x_1, y_2, x_2, a);
                                                Thread.Sleep(2000);

                                                Console.Clear();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                RysujPlanszeBlack(plansza, a);
                                            }
                                        }
                                        // SPRAWDZENIE CZY WSZYSTKIE POLA ZOSTAŁY ODKRYTE
                                        int sumaPkt = 0;
                                        SprawdzCzyWygral(plansza, ref sumaPkt, a);

                                        if (sumaPkt == (-a) * a)
                                        {
                                            Console.WriteLine("Wszystkie pola zostały odkryte");
                                            break;
                                        }
                                    }
                                    break;

                                }

                                switch (a)
                                {
                                    case 4:

                                        Console.Clear();
                                        Console.WriteLine("KONIEC RUNDY PIERWSZEJ!!!");

                                        DateTime Stop1 = DateTime.Now;
                                        TimeSpan CzasRozgrywkiR1 = Stop1 - Start;
                                        Console.WriteLine($"OTO WYNIKI CZASOWY TWOJEJ GRY {CzasRozgrywkiR1}");

                                        int l = PodajInt("WYJŚCIE       Kliknij 1 by przejść do RUNDY DRUGIEJ, 2 by przejść do MENU lub 3 by wyjść z gry  : ", 1, 3);
                                        if (l == 1)
                                        {
                                            break;
                                        }
                                        else if (l == 2)
                                        {
                                           a = 10;
                                           break;
                                        }
                                        else if (l == 3)
                                        
                                            System.Environment.Exit(0);
                                            break;
                                        

                                    case 6:
                                        DateTime Stop = DateTime.Now;
                                        TimeSpan CzasRozgrywkiR2 = Stop - Start;
                                        Console.Clear();
                                        Console.WriteLine("KONIEC RUNDY DRUGIEJ!!!");
                                        Console.WriteLine($"OTO WYNIKI CZASOWY TWOJEJ GRY {CzasRozgrywkiR2}");
                                        int k = PodajInt("WYJŚCIE       Kliknij 1 by wrócić do głównego menu lub 2 by wyjść z gry: ", 1, 2);
                                        if (k == 1)
                                        {
                                            break;
                                        }
                                        else if (k == 2)
                                            System.Environment.Exit(0);
                                        break;
                                }

                                break;
                            }
                            a = a + 2;
                            if (a == 6)
                            {
                                Console.Clear();
                                Console.WriteLine("PRZED TOBĄ RUNDA DRUGA!!!");
                                Thread.Sleep(2000);
                                continue;
                            }

                            else if (a > 6)
                            {
                                break;
                            }
                        }
                        break;
                    case 2: //INSTRUKCJA
                        Console.Clear();
                        try
                        {
                            using (StreamReader instrukcja = new StreamReader(@"C:\Users\Justyna\Desktop\instrukcja.txt"))
                            {
                                String line = instrukcja.ReadToEnd();
                                Console.WriteLine(line);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        int g = PodajInt("WYJŚCIE       Kliknij 1 by wrócić do głównego menu lub 2 by wyjść z gry: ", 1, 2);
                        if (g == 1)
                        {
                            break;
                        }
                        else if (g == 2)
                            System.Environment.Exit(0);
                        break;

                    case 3: // MAIL Z OPINIĄ O GRZE
                        Console.Clear();
                        Console.WriteLine("Podaj swoje imię");
                        string od = Console.ReadLine();

                        Console.WriteLine("Wyraź swoją opinię o grze: ");
                        string tresc = Console.ReadLine();

                        var fromAddress = new MailAddress("opinia.gra@gmail.com", "Memory");
                        var toAddress = new MailAddress("opinia.gra@gmail.com", "To Name");
                        const string fromPassword = "opinia$gra11";
                        string subject = $"Opinia o grze od {od}";
                        string body = tresc;

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                        };
                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }
                        int h = PodajInt("WYJŚCIE       Kliknij 1 by wrócić do głównego menu lub 2 by wyjść z gry: ", 1, 2);
                        if (h == 1)
                        {
                            break;
                        }
                        else if (h == 2)
                            System.Environment.Exit(0);

                        break;
                    case 4: // WYJŚCIE Z GRY
                        Console.Clear();
                        Console.WriteLine();
                        System.Environment.Exit(0);
                        break;

                    case 5:
                        break;
                }

            }
        }
        static void Main(string[] args)

        {
            Gra();
        }
    }

}
