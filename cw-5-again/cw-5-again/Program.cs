using System;
using System.Globalization;

namespace cw_5_again
{
    class Program
    {
        static double beta = 1.0;
        static double epsilon = 0.000001;
        static double c = 0.1;
        static bool Status = false;
        static double[] z = new double[4] { 0, 1, 1, 0 };
        static double[] s = new double[3] { 0, 1, 2 };
        static double[][] u = new double[4][];
        static double[][] w = new double[2][];

        static double[] x1 = new double[4];
        static double[] x2 = new double[4];
        static double[] x3 = new double[4] { 1, 1, 1, 1 };
        static double[][] x = new double[3][];
        static double[] y = new double[4];
        static double[] si = new double[3];
        static double[] s_new = new double[3];
        static double[][] wij = new double[2][];
        static double[][] w_new = new double[2][];
        static string DisplayDouble(double value)
        {
            CultureInfo USFormat = new CultureInfo("en-US");
            return value.ToString("0.000000000000", USFormat);
        }
        static double F(double u)
        {
            return 1.0 / (1.0 + Math.Exp((-1.0) * beta * u));
        }
        static double DE_F(double u)
        {
            return beta * F(u) * (1 - F(u));
        }
        static double[] calX(double[][] w, double[][] u, int h)
        {
            if (h == 1)
            {
                for (int p = 0; p < 4; p++)
                {
                    x1[p] = F(w[0][0] * u[p][0] + w[0][1] * u[p][1] + w[0][2] * u[p][2]);
                }
                return x1;
            }
            else
            {
                for (int p = 0; p < 4; p++)
                {
                    x2[p] = F(w[1][0] * u[p][0] + w[1][1] * u[p][1] + w[1][2] * u[p][2]);
                }
                return x2;
            }
        }
        static double[][] X(double[] x1, double[] x2, double[] x3)
        {
            x[0] = x1;
            x[1] = x2;
            x[2] = x3;
            return x;
        }
        static double[] calY(double[] s, double[][] x)
        {
            for (int p = 0; p < 4; p++)
            {
                y[p] = F(s[0] * x[0][p] + s[1] * x[1][p] + s[2]);
            }
            return y;
        }
        static double[] DE_s(double[] y, double[] z, double[] s, double[][] x)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int p = 0; p < 4; p++)
                {
                    si[i] += (y[p] - z[p]) * DE_F(s[0] * x[0][p] + s[1] * x[1][p] + s[2]) * x[i][p];
                }
            }
            return si;
        }
        static double[][] DE_w(double[] y, double[] z, double[] s, double[][] w, double[][] u, double[][] x)
        {
            double[] u1 = new double[4];
            double[] u2 = new double[4];
            for (int i = 0; i < 2; i++)
            {
                wij[i] = new double[3];
            }

            for (int p = 0; p < 4; p++)
            {
                u1[p] = s[0] * x[0][p] + s[1] * x[1][p] + s[2] * x[2][p];
            }

            for (int i = 0; i < 2; i++)
            {
                for (int p = 0; p < 4; p++)
                {
                    u2[p] = w[i][0] * u[p][0] + w[i][1] * u[p][1] + w[i][2] * u[p][2];
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int p = 0; p < 4; p++)
                    {
                        wij[i][j] += (y[p] - z[p]) * DE_F(u1[p]) * s[i] * DE_F(u2[p]) * u[p][j];
                    }
                }
            }

            return wij;
        }
        static bool max(double[][] w_new, double[][] w, double[] s_new, double[] s)
        {
            double max1 = 0.0;
            double max2 = 0.0;

            for (int i = 0; i < 3; i++)
            {
                if (Math.Abs(s_new[i] - s[i]) > Math.Abs(max1))
                {
                    max1 = Math.Abs(s_new[i] - s[i]);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Math.Abs(w_new[i][j] - w[i][j]) > Math.Abs(max2))
                    {
                        max2 = Math.Abs(w_new[i][j] - w[i][j]);
                    }
                }
            }
            if (Math.Max(Math.Abs(max1), Math.Abs(max2)) < epsilon )
                return true;
            else
                return false;
        }
        static void Nauczyciel()
        {
            for (int i = 0; i < 2; i++)
            {
                wij[i] = new double[3];
                w_new[i] = new double[3];
            }
            int counter = 0;
            //x1 = calX(w, u, 1);
            //x2 = calX(w, u, 2);
            //x = X(x1, x2, x3);
            //y = calY(s, x);
            //si = DE_s(y, z, s, x);
            //wij = DE_w(y, z, s, w, u, x);
            while (Status != true)
            {
                x1 = calX(w, u, 1);
                x2 = calX(w, u, 2);
                x = X(x1, x2, x3);
                y = calY(s, x);
                si = DE_s(y, z, s, x);
                wij = DE_w(y, z, s, w, u, x);

                s_new[0] = s[0] - (c * si[0]);
                s_new[1] = s[1] - (c * si[1]);
                s_new[2] = s[2] - (c * si[2]);

                w_new[0][0] = w[0][0] - (c * wij[0][0]);
                w_new[0][1] = w[0][1] - (c * wij[0][1]);
                w_new[0][2] = w[0][2] - (c * wij[0][2]);
                w_new[1][0] = w[1][0] - (c * wij[1][0]);
                w_new[1][1] = w[1][1] - (c * wij[1][1]);
                w_new[1][2] = w[1][2] - (c * wij[1][2]);

                Status = max(w_new, w, s_new, s);
                s = s_new;
                w = w_new;
                counter++;
            }
            Console.WriteLine("Liczba iteracji: " + counter);
            Console.WriteLine();
            Console.WriteLine("Wagi:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("w" + (i + 1) + (j + 1) + ": " + DisplayDouble(w_new[i][j]) + "\t");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 3; i++)
            {
                Console.Write("s" + (i + 1) + " : " + DisplayDouble(s_new[i]) + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\ty");
            Console.WriteLine("0 XOR 0 \t" + y[0]);
            Console.WriteLine("1 XOR 0 \t" + y[1]);
            Console.WriteLine("0 XOR 1 \t" + y[2]);
            Console.WriteLine("1 XOR 1 \t" + y[3]);
        }
        static void Main(string[] args)
        {


            u[0] = new double[3] { 0, 0, 1 };
            u[1] = new double[3] { 1, 0, 1 };
            u[2] = new double[3] { 0, 1, 1 };
            u[3] = new double[3] { 1, 1, 1 };

            for (int i = 0; i < 2; i++)
            {
                w[i] = new double[3] { 0, 1, 2 };
            }

            Nauczyciel();

            Console.WriteLine();
            Console.Write("Aby zakończyć, wciśnij dowolny klawisz...");
            Console.ReadKey();
        }

    }
}