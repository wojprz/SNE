﻿//Wojciech Przybyła
//C#
//CW-7
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw7
{
        class Program
        {
            static double[] PrepXS()
            {
                double[] xs = new double[25];
                for (int i = 0; i < 25; i++)
                {
                    xs[i] = 0;
                }
                xs[6] = 1.0;
                xs[7] = 1.0;
                xs[12] = 1.0;
                xs[17] = 1.0;
                xs[22] = 1.0;

                return xs;
            }
            static double[][] PrepCij(double[] xs)
            {
                double[][] Cij = new double[25][];
                for (int w = 0; w < 25; w++) Cij[w] = new double[25];
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        if (i != j) Cij[i][j] = (xs[i] - 0.5) * (xs[j] - 0.5);
                        else Cij[i][j] = 0;
                    }
                }
                return Cij;
            }
            static double[] PrepTheta(double[][] Cij)
            {
                double[] theta = new double[25];
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        theta[i] += Cij[i][j];
                    }
                }

                return theta;
            }

            static double[] PrepU(double[][] wij, double[] x, double[] theta)
            {
                double[] u = new double[25];

                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        u[i] += (wij[i][j] * x[j]) - theta[i];
                    }
                }
                return u;
            }

            static double[] StartX()
            {
                double[] x = new double[25];
                Random r = new Random();
                for (int i = 0; i < 25; i++)
                {
                    if ((r.Next() % 2) == 0) x[i] = 0;
                    else if ((r.Next() % 2) == 1) x[i] = 1;
                }

                return x;
            }
            static double[][] PrepWij(double[][] Cij)
            {
                double[][] w = new double[25][];
                for (int i = 0; i < 25; i++) w[i] = new double[25];

                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        w[i][j] = 2 * Cij[i][j];
                    }
                }
                return w;
            }

            static double[] NextX(double[] u, double[] x)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (u[i] > 0) x[i] = 1;
                    else if (u[i] == 0) x[i] = x[i];
                    else x[i] = 0;

                    for (int j = 0; j < 25; j++)
                    {
                        if (x[j] == 0) Console.Write(" [ ] ");
                        else Console.Write(" [*] ");
                        if (j % 5 == 4) Console.WriteLine();
                    }
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                if (Console.ReadKey().Key == ConsoleKey.Spacebar) break;
                }
            Console.WriteLine("Press spacebar to exit loop!");
            return x;
            }

            static void wyswietlanie(double[] x)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (x[i] == 0) Console.Write(" [ ] ");
                    else Console.Write(" [*] ");

                    if (i % 5 == 4) Console.WriteLine();
                }
            }

            static void Main(string[] args)
            {
                double[] xs = PrepXS();
                double[][] cij = PrepCij(xs);
                double[][] wij = PrepWij(cij);
                double[] theta = PrepTheta(cij);

                double[] x = StartX();
                double[] u = PrepU(wij, x, theta);

                wyswietlanie(x);
                Console.WriteLine();
                Console.WriteLine();
            while (true)
            {
                x = NextX(u, x);
                u = PrepU(wij, x, theta);

                if (Console.ReadKey().Key == ConsoleKey.Spacebar) break;
            }
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Press any key to exit.\n");
                Console.ReadKey();
            }
        }
    

}
