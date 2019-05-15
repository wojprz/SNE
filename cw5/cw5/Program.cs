using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw5
{
    class Program
    {
        static double[] s = new double[3] { 0, 1, 2 };
        static double[] z = new double[4] { 0, 1, 1, 0 };
        static double c = 1.0;
        static double epsilon = 0.0001;
        static double beta = 1.0;
        static List<double[]> prepUP()
        {
            List<double[]> up = new List<double[]>();
            double[] u1 = new double[3] { 0, 0, 1 };
            double[] u2 = new double[3] { 1, 0, 1 };
            double[] u3 = new double[3] { 0, 1, 1 };
            double[] u4 = new double[3] { 1, 1, 1 };

            up.Add(u1);
            up.Add(u2);
            up.Add(u3);
            up.Add(u4);

            return up;
        }
        static List<double[]> prepW()
        {
            List<double[]> w = new List<double[]>();
            double[] w1 = new double[3] { 0, 1, 2 };
            double[] w2 = new double[3] { 0, 1, 2 };
            w.Add(w1);
            w.Add(w2);
            return w;
        }
        static double calY(double[,] x, int p)
        {
            return s[0] * x[p,0] + s[1] * x[p,1] + s[2] * x[p,2];
        }
        static double[,] calX(List<double[]> w, List<double[]> u, int p)
        {
            double[,] x = new double[4,2];
            x[p, 1] = w[0][0] * u[p][1] + w[0][1] * u[p][1] + w[0][2] * u[p][2];
            x[p, 2] = w[1][0] * u[p][1] + w[1][1] * u[p][1] + w[1][2] * u[p][2];
            return x;
        }
        static double DE_w(List<double[]> w, List<double[]> u)
        {
            for(int i = 0; i<4; i++)
            {
                (calY(calX(w, u, i), i)-z[i]) * (s[1]*calX(w,u,i)
            }
        }
        static List<double[]> gardientW(List<double[]> w_old)
        {
            List<double[]> w_new = new List<double[]>();
            for(int i = 0; i<2; i++)
            {
                for(int j = 0; j<=2; j++)
                {
                    w_new[i][j] = w_old[i][j] - 
                }
            }
        }





        static void Main(string[] args)
        {
            List<double[]> up = prepUP();
            Console.WriteLine(up[0][0]);
            Console.ReadKey();
        }
    }
}
