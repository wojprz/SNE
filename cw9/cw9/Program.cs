using System;
using System.Collections.Generic;
using System.Linq;

namespace cw9
{
    class Program
    {
        //static List<int[]> S = new List<int[]>();
        //static void permute(int[] s, int l, int r)
        //{
        //    if (l == r)
        //        S.Add(s);
        //    else
        //    {
        //        for (int i = l; i <= r; i++)
        //        {
        //            s = swap(s, l, i);
        //            permute(s, l + 1, r);
        //            s = swap(s, l, i);
        //        }
        //    }

        //}

        //static int[] swap(int[] a, int i, int j)
        //{
        //    int temp;
        //    int[] intArray = a;
        //    temp = intArray[i];
        //    intArray[i] = intArray[j];
        //    intArray[j] = temp;
        //    return intArray;
        //}

        static IEnumerable<IEnumerable<T>>
            GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        static int D(int sa, int sb)
        {
            if ((sa == 1 && sb == 10) || (sa == 10 && sb == 1)) return 1;
            else return Math.Abs(sa - sb);
        }

        static int D_prim(int sa, int sb)
        {
            if ((sa == 1 && sb == 2) || (sa == 9 && sb == 10)) return 1;
            if (sa < sb) return sa ^ 3 + sb ^ 3 - ((sa ^ 2) * sb) - (sa * sb ^ 2) + 4 * sa ^ (2) - 4 * sb ^ (2) + 4 * sa + 4 * sb + 1;
            else return D_prim(sb, sa);
        }

        static int E(int[] S)
        {
            int e = 0;
            e = D(S[0], S[1]) + D(S[2], S[3]) + D(S[3], S[4]) + D(S[4], S[5]) + D(S[5], S[6]) + D(S[6], S[7]) + D(S[7], S[8]) + D(S[8], S[9]) + D(S[9], S[0]);
            return e;
        }

        static int E_prim(int[] S)
        {
            int e = 0;
            e = D_prim(S[0], S[1]) + D_prim(S[2], S[3]) + D_prim(S[3], S[4]) + D_prim(S[4], S[5]) + D_prim(S[5], S[6]) + D_prim(S[6], S[7]) + D_prim(S[7], S[8]) + D_prim(S[8], S[9]) + D_prim(S[9], S[0]);
            return e;
        }

        static void Main(string[] args)
        {

            int L = 6;
            int l = 0;

            int M = 100;
            int m = 0;

            double T;
            int T0 = 5;
            Random r = new Random();
            int[] s = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<IEnumerable<int>> S = GetPermutations(Enumerable.Range(1, 10), 10);

            //permute(s, 0, 9);
            int[] St = new int[10];
            List<int> stat = new List<int>();
            int w;

            int[] S_prim = new int[10];
            int delta_E;

            int w_prim;

            w = r.Next(0, 3628799);
            stat.Add(w);
            St = S.ElementAt(w).ToArray();
            T = T0;

            while (l < L)
            {
                while (m < M)
                {
                    w_prim = r.Next(0, 3628799);

                    while (stat.Contains(w_prim))
                    {
                        w_prim = r.Next(0, 3628799);
                    }
                    S_prim = S.ElementAt(w_prim).ToArray();
                    stat.Add(w_prim);

                    delta_E = E_prim(S_prim) - E_prim(St);
                    //delta_E = E(S_prim) - E(St);
                    double tem = r.NextDouble();
                    if ((delta_E < 0) || (tem < Math.Exp(-1 * (delta_E / T))))
                    {
                        St = S_prim;
                        l++;
                    }
                    m++;
                }
                m = 0;
                T = T0 / (1 + Math.Log(1 + l));
                //stat.Clear();
            }
            Console.WriteLine("S:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(St[i] + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("E(S): " + E(St));
            Console.ReadKey();



        }
    }
}
