using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace cw3
{
    class Program
    {
        static void Start()
        {
            Console.SetWindowSize(Math.Min(110, Console.LargestWindowWidth), Math.Min(35, Console.LargestWindowHeight));
        }
        static double[] GetVector(double value)
        {
            double[] vector = new double[25];
            for (int i = 0; i < 25; i++)
            {
                vector[i] = value;
            }
            return vector;
        }
        static double[] getZ0 (string type)
        {
            double[] z0 = new double[25];
            z0 = GetVector(-1.0);

            if (type == "normalny")
            {
                z0[6] = 1.0;
                z0[7] = 1.0;
                z0[8] = 1.0;
                z0[11] = 1.0;
                z0[13] = 1.0;
                z0[16] = 1.0;
                z0[17] = 1.0;
                z0[18] = 1.0;
            }
            else if(type == "zaburzony")
            {
                z0[1] = 1.0;
                z0[2] = 1.0;
                z0[3] = 1.0;
                z0[6] = 1.0;
                z0[8] = 1.0;
                z0[11] = 1.0;
                z0[13] = 1.0;
                z0[16] = 1.0;
                z0[17] = 1.0;
                z0[18] = 1.0;
            }
            return z0;
        }
        static double[] getZ1 (string type)
        {
            double[] z1 = new double[25];
            z1 = GetVector(-1.0);

            if (type == "normalny")
            {
                z1[6] = 1.0;
                z1[7] = 1.0;
                z1[12] = 1.0;
                z1[17] = 1.0;
            }
            else if(type == "zaburzony")
            {
                z1[2] = 1.0;
                z1[7] = 1.0;
                z1[12] = 1.0;
                z1[17] = 1.0;
                z1[22] = 1.0;
            }
            return z1;
        }
        static double[][] matrixW(double[] z0, double[] z1)
        {
            double[][] W = new double[25][];
            for (int i = 0; i < 25; i++)
            {
                W[i] = new double[25];
            }

            for(int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    W[i][j] = 1.0 / 25.0 * (z0[i] * z0[j] + z1[i] * z1[j]);
                }
            }
            return W;
        }
        static double[] SGN (double[] x)
        {
            for (int i = 0; i < 25; i++)
            {
                if (x[i] >= 0) x[i] = 1.0;
                else if (x[i] < 0) x[i] = -1.0;
            }
            return x;
        }
        static double[] f (double[][] w, double[] u)
        {
            double[] y = new double[25];
            double wartoscY = 0.0;

            for(int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    wartoscY += w[i][j] * u[j];
                }
                y[i] = wartoscY;
                wartoscY = 0.0;
            }
            y = SGN(y);
            return y;
        }
        static void wyswietlanie(double[] z)
        {
            for(int i = 0; i < 25; i++)
            {
                if (z[i] == -1.0) Console.Write(" [ ] ");
                else Console.Write(" [*] ");

                if (i % 5 == 4) Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Start();
            double[] z0 = getZ0("normalny");
            double[] z0pri = getZ0("zaburzony");

            double[] z1 = getZ1("normalny");
            double[] z1pri = getZ1("zaburzony");

            double[][] W = matrixW(z0, z1);
            double[] y;

            //z0
            Console.WriteLine("z0\tF(z0)");
            Console.WriteLine("***********************************************************");
            y = f(W, z0);
            wyswietlanie(y);
            Console.WriteLine();
            //z1
            Console.WriteLine("z1\tF(z1)");
            Console.WriteLine("***********************************************************");
            y = f(W, z1);
            wyswietlanie(y);
            Console.WriteLine();
            //z0 zaburzone
            Console.WriteLine("z0 zaburzone");
            Console.WriteLine("***********************************************************");
            wyswietlanie(z0pri);
            Console.WriteLine();
            //z0 zaburzone wynik
            Console.WriteLine("z0 (wynik zaburzonego)\tF(z0)");
            Console.WriteLine("***********************************************************");
            y = f(W, z0pri);
            wyswietlanie(y);
            Console.WriteLine();
           
            //z1 zaburzone
            Console.WriteLine("z1 zaburzone");
            Console.WriteLine("***********************************************************");
            wyswietlanie(z1pri);
            Console.WriteLine();
            //z1 zaburzone wynik
            Console.WriteLine("z1 (wynik zaburzonego)\tF(z1)");
            Console.WriteLine("***********************************************************");
            y = f(W, z1pri);
            wyswietlanie(y);
            Console.WriteLine();
            
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
