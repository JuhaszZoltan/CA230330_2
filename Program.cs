using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;

namespace CA230330_2
{
    internal class Program
    {
        static char[,] palya = new char[24, 79];
        static Stopwatch sw = new();

        static void Main()
        {
            Beolvas("..\\..\\..\\src\\lab.txt");
            Kirajzol();
            Jatek();
            Eredmeny();
        }

        private static void Eredmeny()
        {
            sw.Stop();
            Console.Clear();
            Console.ResetColor();

            Console.WriteLine("gratulálok., nyertél!");
            Console.WriteLine($"időeredményed: {sw.ElapsedMilliseconds / 1000F:0.000} sec.");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static void Jatek()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Red;
            int s = 0;
            int o = 0;
            Console.SetCursorPosition(o, s);

            while (palya[s, o] != 'O')
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                if (!sw.IsRunning) sw.Start();

                Console.SetCursorPosition(o, s);
                Console.Write(' ');
                if (cki.Key == ConsoleKey.RightArrow
               && o < palya.GetLength(1) - 1
               && palya[s, o + 1] != '#') o++;
                else if (cki.Key == ConsoleKey.LeftArrow
                    && o != 0
                    && palya[s, o - 1] != '#') o--;
                else if (cki.Key == ConsoleKey.DownArrow
                    && s < palya.GetLength(0) - 1
                    && palya[s + 1, o] != '#') s++;
                else if (cki.Key == ConsoleKey.UpArrow
                    && s != 0
                    && palya[s - 1, o] != '#') s--;
                Console.SetCursorPosition(o, s);
                Console.Write('@');
            }
        }

        static void Beolvas(string file)
        {
            using StreamReader sr = new(file, Encoding.UTF8);
            int s = 0;
            while (!sr.EndOfStream)
            {
                string beolvasottSor = sr.ReadLine();

                for (int o = 0; o < beolvasottSor.Length; o++)
                {
                    palya[s, o] = beolvasottSor[o];
                }
                s++;
            }
        }

        static void Kirajzol()
        {
            for (int s = 0; s < palya.GetLength(0); s++)
            {
                for (int o = 0; o < palya.GetLength(1); o++)
                {
                    if (palya[s, o] == 'O' || palya[s, o] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(palya[s, o]);
                    Console.ResetColor();
                }
                Console.Write("\n");
            }
        }

        
    }
}