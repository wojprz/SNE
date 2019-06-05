using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw9
{
    class Program
    {
        static Random g = new Random((int)DateTime.Now.Ticks);
        static int GCD(int x, int y)
        {
            if (x % y == 0) return y;
            else return GCD(y, x % y);
        }

        private static int F(int n)
        {
            int a = g.Next(1, n);
            int r = g.Next(1, n);
            if (GCD(n, a) > 1) return GCD(n, a);
            if (((a ^ r) % n) == 1 && r % 2 == 0 && (GCD(n, a ^ (r / 2) + 1) > 1 || GCD(n, a ^ (r / 2) + 1) > 1)) return GCD(n, a ^ (r / 2) + 1);
            else return F(n);
        }

        static void Main(string[] args)
        {
            int a1 = F(12);
            int b1 = 12 / a1;
            Console.WriteLine("12: "+ "(" + a1 + ";" + b1 + ")");
            Console.WriteLine();
            Console.ReadKey();

            int a2 = F(91);
            int b2 = 91 / a2;
            Console.WriteLine("91: " + "(" + a2 + ";" + b2 + ")");
            Console.WriteLine();
            Console.ReadKey();

            int a3 = F(143);
            int b3 = 143 / a3;
            Console.WriteLine("143: " + "(" + a3 + ";" + b3 + ")");
            Console.WriteLine();
            Console.ReadKey();

            int a4 = F(1859);
            int b4 = 1859 / a4;
            Console.WriteLine("1859: " + "(" + a4 + ";" + b4 + ")");
            Console.WriteLine();
            Console.ReadKey();

            int a5 = F(1737);
            int b5 = 1737 / a5;
            Console.WriteLine("1737: " + "(" + a5 + ";" + b5 + ")");
            Console.WriteLine();
            Console.ReadKey();

            int a6 = F(13843);
            int b6 = 13843 / a6;
            Console.WriteLine("13843: " + "(" + a6 + ";" + b6 + ")");
            Console.WriteLine();
            Console.ReadKey();

            int a7 = F(988027);
            int b7 = 988027 / a7;
            Console.WriteLine("988027: " + "(" + a7 + ";" + b7 + ")");
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Podaj ile wlasnych");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Podaj liczbe!");
                int input = int.Parse(Console.ReadLine());
                int a8 = F(input);
                int b8 = input / a8;
                Console.WriteLine($"{input}" + ": " + "(" + a8 + ";" + b8 + ")");
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
}
