//Wojciech Przybyła
//Cw 1
//C#
using System;
using System.Collections.Generic;
using System.Linq;

namespace cw1
{
    class Program
    {
        static void start()
        {
            Console.SetWindowSize(Math.Min(110, Console.LargestWindowWidth), Math.Min(35, Console.LargestWindowHeight));
        }

        static void Gate(string type, List<double> wagi)
        {
            double y = 0.0;
            if (type == "AND")
            {
                double[] u1 = new double[3] { 0, 0, 1 };
                double[] u2 = new double[3] { 1, 0, 1 };
                double[] u3 = new double[3] { 0, 1, 1 };
                double[] u4 = new double[3] { 1, 1, 1 };

                List<double[]> u = new List<double[]>() { u1, u2, u3, u4 };

                for (int i = 0; i <= u.Count() - 1; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        y += wagi[j] * u[i][j];
                    }
                    if (y >= 0)
                        Console.WriteLine(u[i][0] + "\t" + u[i][1] + "\t" + 1.0 + "\t" + y);
                    else
                        Console.WriteLine(u[i][0] + "\t" + u[i][1] + "\t" + 0.0 + "\t" + y);
                    y = 0.0;
                }
            }
            if (type == "NAT")
            {
                double[] u1 = new double[2] { 0, 1 };
                double[] u2 = new double[2] { 1, 1 };
                List<double[]> u = new List<double[]>() { u1, u2 };
                for (int i = 0; i <= u.Count() - 1; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        y += wagi[j] * u[i][j];
                    }
                    if (y >= 0)
                        Console.WriteLine(u[i][0] + "\t" + u[i][1] + "\t" + 1.0 + "\t" + y);
                    else
                        Console.WriteLine(u[i][0] + "\t" + u[i][1] + "\t" + 0.0 + "\t" + y);
                    y = 0.0;
                }
            }
            if (type == "OR")
            {
                double[] u1 = new double[3] { 0, 0, 1 };
                double[] u2 = new double[3] { 1, 0, 1 };
                double[] u3 = new double[3] { 0, 1, 1 };
                double[] u4 = new double[3] { 1, 1, 1 };

                List<double[]> u = new List<double[]>() { u1, u2, u3, u4 };

                for (int i = 0; i <= u.Count() - 1; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        y += wagi[j] * u[i][j];
                    }
                    if (y >= 0)
                        Console.WriteLine(u[i][0] + "\t" + u[i][1] + "\t" + 1.0 + "\t" + y);
                    else
                        Console.WriteLine(u[i][0] + "\t" + u[i][1] + "\t" + 0.0 + "\t" + y);
                    y = 0.0;
                }
            }
            if (type == "NAND")
            {
                double[] u1 = new double[3] { 0, 0, 1 };
                double[] u2 = new double[3] { 1, 0, 1 };
                double[] u3 = new double[3] { 0, 1, 1 };
                double[] u4 = new double[3] { 1, 1, 1 };

                List<double[]> u = new List<double[]>() { u1, u2, u3, u4 };

                for (int i = 0; i <= u.Count() - 1; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        y += wagi[j] * u[i][j];
                    }
                    if (y >= 0)
                        Console.WriteLine(u[i][0] + "\t" + u[i][1] + "\t" + 1.0 + "\t" + y);
                    else
                        Console.WriteLine(u[i][0] + "\t" + u[i][1] + "\t" + 0.0 + "\t" + y);
                    y = 0.0;
                }
            }
        }


        static void Main(string[] args)
        {
            start();
            List<double> wagi = new List<double>();

            Console.WriteLine("NAT");
            wagi.Add(-0.5);
            wagi.Add(0.3);
            Console.WriteLine("U1\tU2\tUm");
            Gate("NAT", wagi);
            wagi.Clear();
            Console.WriteLine("***************************************");


            Console.WriteLine("AND");
            wagi.Add(0.3);
            wagi.Add(0.3);
            wagi.Add(-0.5);
            Console.WriteLine("U1\tU2\tUm");
            Gate("AND", wagi);
            wagi.Clear();
            Console.WriteLine("***************************************");


            Console.WriteLine("NAND");
            wagi.Add(-0.3);
            wagi.Add(-0.3);
            wagi.Add(0.5);
            Console.WriteLine("U1\tU2\tUm");
            Gate("NAND", wagi);
            wagi.Clear();
            Console.WriteLine("***************************************");


            Console.WriteLine("OR");
            wagi.Add(0.2);
            wagi.Add(0.2);
            wagi.Add(-0.1);
            Console.WriteLine("U1\tU2\tUm");
            Gate("OR", wagi);
            wagi.Clear();
            Console.WriteLine("***************************************");


            Console.WriteLine("Press any button to exit!");
            Console.ReadKey();

        }
    }
}
