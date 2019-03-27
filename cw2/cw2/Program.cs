//Wojciech Przybyła
//Cw 2
//C#

using System;
using System.Collections.Generic;
using System.Globalization;

namespace cw2
{
    class Program
    {
        static void Start()
        {
            Console.SetWindowSize(Math.Min(110, Console.LargestWindowWidth), Math.Min(35, Console.LargestWindowHeight));
        }
        static double[] GetVector(double value)
        {
            double[] vector = new double[26];
            for (int i=0; i<26; i++)
            {
                vector[i] = value;
            }
            return vector;
        }
        static double sygNaucz(double t)
        {
            if (1 + ((t - 1) % 5) <= 3)
                return 1.0;
            else if (1 + ((t - 1) % 5) > 3)
                return 0.0;
            else
                return 2.0;
        }
        static string viewDouble(double value)
        {

            CultureInfo USFormat = new CultureInfo("en-US");
            return value.ToString("0.00", USFormat);
        }
        static List<double[]> wejscie()
        {
            double[] u1 = new double[26];
            u1 = GetVector(0.0);
            u1[6] = 1.0;
            u1[7] = 1.0;
            u1[12] = 1.0;
            u1[17] = 1.0;
            u1[23] = 1.0;
            u1[25] = 1.0;

            double[] u2 = new double[26];
            u2 = GetVector(0.0);
            u2[2] = 1.0;
            u2[3] = 1.0;
            u2[8] = 1.0;
            u2[13] = 1.0;
            u2[25] = 1.0;

            double[] u3 = new double[26];
            u3 = GetVector(0.0);
            u3[5] = 1.0;
            u3[6] = 1.0;
            u3[11] = 1.0;
            u3[16] = 1.0;
            u3[22] = 1.0;
            u3[25] = 1.0;

            double[] u4 = new double[26];
            u4 = GetVector(0.0);
            u4[6] = 1.0;
            u4[7] = 1.0;
            u4[8] = 1.0;
            u4[11] = 1.0;
            u4[13] = 1.0;
            u4[16] = 1.0;
            u4[17] = 1.0;
            u4[18] = 1.0;
            u4[25] = 1.0;

            double[] u5 = new double[26];
            u5 = GetVector(0.0);
            u5[10] = 1.0;
            u5[11] = 1.0;
            u5[12] = 1.0;
            u5[15] = 1.0;
            u5[17] = 1.0;
            u5[20] = 1.0;
            u5[21] = 1.0;
            u5[22] = 1.0;
            u5[25] = 1.0;

            List<double[]> u = new List<double[]>() { u1, u2, u3, u4, u5 };
            return u;
        }
        static double iloSkal(double[] w, double[] u)
        {
            double y = 0.0;
            for(int i=0; i<26; i++)
            {
                y += w[i] * u[i];
            }
            if (y >= 0)
                return 1.0;
            else
                return 0.0;
        }
        static void algorytm(double c)
        {
            int licznik = 0;
            int t = 1;
            double z;
            double y;

            double[] w = new double[26];
            w = GetVector(1.0);

            List<double[]> u = new List<double[]>();
            u = wejscie();

            while(licznik != 5)
            {
                z = sygNaucz(t);
                y = iloSkal(w, u[(t - 1) % 5]);

                for(int i=0; i<26; i++)
                {
                    w[i] = w[i] + c * (z - y) * u[(t - 1) % 5][i];
                }

                t += 1;

                if (z == y)
                    licznik++;
                else
                    licznik = 0;
            }

            Console.WriteLine("c= " + c + "," + "t= " + t);
            Console.WriteLine("******************************************************");

            int id = 0;
            for(int r = 1; r<6; r++)
            {
                for(int co = 1; co<6; co++)
                {
                    Console.Write(viewDouble(w[id]) + "\t");
                    id++;
                }
                if(r == 5)
                    Console.WriteLine(viewDouble(w[25]));

                Console.WriteLine();

            }
        }
        static void Main(string[] args)
        {
            Start();
            algorytm(0.01);
            Console.WriteLine();

            algorytm(0.1);
            Console.WriteLine();

            algorytm(1.0);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
         
        }
    }
}
