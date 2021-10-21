using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prak6
{
    class Program
    {
        static void Main(string[] args)
        {
            double e = 0.0001;
            double[,] array1 = new double[,]
            {
                { -14.95, 0.68, 8.86, -0.76 },
                {  0.16, -15.38, 0.53, -8.69 },
                { 4.71, -2.84, 24.18, 8.68 }
            };

            foreach(var i in Iteration(array1, e))
            {
                Console.WriteLine(i);
            }
        }

        public static double[] Iteration(double[,] array, double e)
        {
            int n = array.GetLength(0);
            double[] x = new double[n];
            double[] y = new double[n];
            ConvertArray(array);
            if (!ConvergenceCheck(array))
                return null;
            for (int i = 0; i < n; ++i)
            {
                x[i] = array[i, n];
            }

            double d = 0;
            for (int i = 0; i < n; ++i)
            {
                y[i] = array[i, n];
                for (int j = 0; j < n; ++j)
                {
                    y[i] += array[i, j] * x[j];
                }
                d += Math.Pow(y[i] - x[i], 2);
            }
            d = Math.Sqrt(d);

            while (d > e)
            {
                for (int i = 0; i < n; ++i)
                {
                    x[i] = y[i];
                }
                d = 0;
                for (int i = 0; i < n; ++i)
                {
                    y[i] = array[i, n];
                    for (int j = 0; j < n; ++j)
                    {
                        y[i] += array[i, j] * x[j];
                    }
                    d += Math.Pow(y[i] - x[i], 2);
                }
                d = Math.Sqrt(d);
            }

            return y;
        }

        public static bool ConvergenceCheck(double[,] array)
        {
            int n = array.GetLength(0);
            double max = array[0, 0] * array[0, 0];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    max = Math.Max(array[i, j] * array[i, j], max);
                }
            }

            return max < 1;
        }

        public static void ConvertArray(double[,] array)
        {
            int n = array.GetLength(0);
            for (int i = 0; i < n; ++i)
            {
                double divider = array[i, i];
                for (int j = 0; j < n + 1; ++j)
                {
                    array[i, j] /= j == n ? divider : -divider;
                }
                array[i, i] = 0;
            }
        }

        static public string Print2DArray(double[,] array)
        {
            string result = "";
            int n = array.GetLength(0);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    result += $"{array[i, j]}\t";
                }
                result += Environment.NewLine;
            }
            return result;
        }
    }
}
