using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cw10
{
    class Program
    {
        static Random w = new Random();
        static int GCD(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            if (a > b)
                return GCD (a% b, b);
            else
                return GCD(a, b % a);
        }
        static int faktotyzacja(int n)
        {
            
            int a = w.Next(2, n);
            if (GCD(n, a) > 1) return GCD(n, a);
            int r = w.Next(2, n);
            if (r % 2 != 0) return faktotyzacja(n);
            if ((a ^ r) % n == 1 && r % 2 == 0 )
            {
                if (GCD(n, a ^ (r / 2) + 1) > 1 || GCD(n, a ^ (r / 2) - 1) > 1) return GCD(n, a ^ (r / 2) + 1);
                else return faktotyzacja(n);
            }
            else return faktotyzacja(n);
        }
        static void Main(string[] args)
        {
            int a1 = 12;
            int a2 = 91;
            int a3 = 143;
            int a4 = 1859;
            int a5 = 1737;
            int a6 = 13843;
            int a7 = 988027;

            int b1 = faktotyzacja(a1);
            int b2 = faktotyzacja(a2);
            int b3 = faktotyzacja(a3);
            int b4 = faktotyzacja(a4);
            int b5 = faktotyzacja(a5);
            int b6 = faktotyzacja(a6);
            int b7 = faktotyzacja(a7);

            int c1 = 12 / b1;
            int c2 = 91 / b2;
            int c3 = 143 / b3;
            int c4 = 1859 / b4;
            int c5 = 1737 / b5;
            int c6 = 13843 / b6;
            int c7 = 988027 / b7;


            Console.WriteLine(a1 + ": " + "(" + b1 + "," + c1 + ")\n");
            Console.WriteLine(a2 + ": " + "(" + b2 + "," + c2 + ")\n");
            Console.WriteLine(a3 + ": " + "(" + b3 + "," + c3 + ")\n");
            Console.WriteLine(a4 + ": " + "(" + b4 + "," + c4 + ")\n");
            Console.WriteLine(a5 + ": " + "(" + b5 + "," + c5 + ")\n");
            Console.WriteLine(a6 + ": " + "(" + b6 + "," + c6 + ")\n");
            Console.WriteLine(a7 + ": " + "(" + b7 + "," + c7 + ")\n");

            Console.ReadKey();
        }
    }
}
