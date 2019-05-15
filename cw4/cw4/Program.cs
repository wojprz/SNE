//Wojciech Przybyła
//Cw 4
//C#
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace cw4
{
    class Program
    {
        static double c = 0.01;
        static double epsilon = 0.000001;
        static void Start()
        {
            Console.SetWindowSize(Math.Min(110, Console.LargestWindowWidth), Math.Min(35, Console.LargestWindowHeight));
        }
        static string viewDouble(double value)
        {

            CultureInfo USFormat = new CultureInfo("en-US");
            return value.ToString("0.00", USFormat);
        }
        static  double Oblicz(double[] x_old, double[] x_new)
        {
            double w = 0.0;
            for (int i=0; i<x_old.Length;i++)
                w = Math.Abs(x_new[i] - x_old[i]);
            return w;
        }
        static double f_xyz(double[] v) //1 funkcja
        {
            //v[0] == wartosc x
            //v[1] == wartosc y
            //v[2] == wartosc z
            return 2 * Math.Pow(v[0], 2) + 2 * Math.Pow(v[1], 2) + Math.Pow(v[2], 2) - 2 * v[0] * v[1] - 2 * v[1] * v[2] - 2 * v[0] + 3;
        }
        static double DF_x(double[] v) 
        {
            //v[0] == wartosc x
            //v[1] == wartosc y
            return 4 * v[0] - 2 * (v[1] + 1);
        }
        static double DF_y(double[] v) 
        {
            //v[0] == wartosc x
            //v[1] == wartosc y
            //v[2] == wartosc z
            return -2 * (v[0] - 2 * v[1] + v[2]);
        }
        static double DF_z(double[] v) 
        {
            //v[1] == wartosc y
            //v[2] == wartosc z
            return 2 * v[2] - 2 * v[1];
        }
        static double g_xy(double[] v) //2 funkcja
        {
            //v[0] == wartosc x
            //v[1] == wartosc y
            return 3 * Math.Pow(v[0], 4) + 4 * Math.Pow(v[0], 3) - 12 * Math.Pow(v[0], 2) + 12 * Math.Pow(v[1], 2) - 24 * v[1];
        }
        static double DG_x(double[] v) 
        {
            //v[0] == wartosc x
            return 12 * v[0] * (Math.Pow(v[0], 2) + v[0] -2);
        }
        static double DG_y(double[] v) 
        {
            //v[1] == wartosc y
            return 24 * (v[1] - 1);
        }
      
        static void gradientF(double[] x_old)
        {
            double wynik = 0.0;
            double[] x_new = new double[3];

            x_new[0] = x_old[0] - c * DF_x(x_old);
            x_new[1] = x_old[1] - c * DF_y(x_old);
            x_new[2] = x_old[2] - c * DF_z(x_old);

            while (Oblicz(x_old, x_new) >= epsilon)
            {
                x_old[0] = x_new[0];
                x_old[1] = x_new[1];
                x_old[2] = x_new[2];
                x_new[0] = x_old[0] - c * DF_x(x_old);
                x_new[1] = x_old[1] - c * DF_y(x_old);
                x_new[2] = x_old[2] - c * DF_z(x_old);
            }
            Console.WriteLine("Funkcja 1");
            Console.WriteLine("x = " + viewDouble(x_new[0]));
            Console.WriteLine("y = " + viewDouble(x_new[1]));
            Console.WriteLine("z = " + viewDouble(x_new[2]));
            wynik = f_xyz(x_new);
            Console.WriteLine("f(x, y, z) = " + viewDouble(wynik));
        }
        static void gradientG(double[] x_old)
        {
            double wynik = 0.0;
            double[] x_new = new double[2];

            x_new[0] = x_old[0] - c * DG_x(x_old);
            x_new[1] = x_old[1] - c * DG_y(x_old);
  

            while (Oblicz(x_old, x_new) >= epsilon)
            {
                x_old[0] = x_new[0];
                x_old[1] = x_new[1];

                x_new[0] = x_old[0] - c * DG_x(x_old);
                x_new[1] = x_old[1] - c * DG_y(x_old);
            }
            Console.WriteLine("Funkcja 2");
            Console.WriteLine("x = " + viewDouble(x_new[0]));
            Console.WriteLine("y = " + viewDouble(x_new[1]));
            wynik = g_xy(x_new);
            Console.WriteLine("g(x, y) = " + viewDouble(wynik));
        }
        static void Main(string[] args)
        {
            Start();
            System.Random r = new Random();
            double[] x = new double[3];
            double[] xx = new double[2];
            x[0] = 2;
            xx[0] = r.Next(0, 10);

            System.Threading.Thread.Sleep(100);
            System.Threading.Thread.Sleep(10);
            x[1] = 4;
            xx[1] = r.Next(0, 10);

            System.Threading.Thread.Sleep(10);
            x[2] = r.Next(0,10);
                
            Console.WriteLine("c == 0.01, Epsilon == 0.000001");
            gradientF(x);
            Console.WriteLine();
            Console.WriteLine("c == 0.01, Epsilon == 0.000001");
            gradientG(xx);
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
