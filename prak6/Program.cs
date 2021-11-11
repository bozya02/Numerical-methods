using System;

namespace prak6
{
    class Program
    {
        static void Main(string[] args)
        {
            double e = 0.0001;
            double[,] arrayI1 = new double[,]
            {
                { -14.95, 0.68, 8.86, -0.76 },
                { 0.16, -15.38, 0.53, -8.69 },
                { 4.71, -2.84, 24.18, 8.68 }
            };

            double[,] arrayI2 = new double[,]
            {
                { -28.93, -7.61, -7.61, -7.29, 7.68 },
                { 8.33, 23.48, -6.01, 1.42, -7.32 },
                { 8.64, 8.4, -16.51, -7.74, -0.16 },
                { 0.91, 6.13, -4.51, -22.76, -2.33 }
            };

            double[,] arrayI3 = new double[,]
            {
                { 24.58, -0.18, -7.14, -5.06, 8, 4.26 },
                { 6.98, 13.75, 1.1, 7.43, -4.96, -6.73 },
                { -7.2, 1.42, 26.33, 4.35, 0.58, -2.19 },
                { -6.7, -5.3, -1.2, -21.02, 6.55, 8.45 },
                { -6.19, -8.56, -3.08, -6.76, -13.61, -4.09 }
            };

            double[,] arrayS1 = new double[,]
            {
                { 22.52, -4.62, -1.41, 0.53 },
                { -5.1, -28.37, 4.58, -8.78 },
                { 4.68, -1.91, 23.85, 5.14 }
            };

            double[,] arrayS2 = new double[,]
            {
                { -23.98, 1.5, -8.78, 7.74, -0.04 },
                { -8.7, -28.73, 3.86, 8.08, 7.86 },
                { 1.62, 3.88, -18.17, -8.68, -0.44 },
                { -6.97, 1.96, 1.55, -29.54, -2.02 }
            };

            double[,] arrayS3 = new double[,]
            {
                { -17.01, 6.28, -8.25, -2.57, 3.05, -6.47 },
                { 7.98, 18.4, 0.79, -0.35, 8.54, 0.28 },
                { -8.82, 2.07, -15.99, 4.3, 1.03, -4.39 },
                { 2.43, -4.29, 0.52, 31.46, 4.78, 5.05 },
                { -5.82, 1.84, 3.11, 6.42, 21.47, -0.54 }
            };

            foreach (var i in Iteration(arrayI1, e))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("---------------");
            foreach (var i in Iteration(arrayI2, e))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("---------------");
            foreach (var i in Iteration(arrayI3, e))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("---------------");

            foreach (var i in Seidel(arrayS1, e))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("---------------");
            foreach (var i in Iteration(arrayS2, e))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("---------------");
            foreach (var i in Iteration(arrayS3, e))
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

        public static double[] Seidel(double[,] array, double e)
        {
            int n = array.GetLength(0);
            double d = 0;
            double[] y = new double[n];

            double[] x = new double[n];
            for (int i = 0; i < n; ++i)
            {
                x[i] = array[i, n];
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (j != i)
                    {
                        array[i, j] /= -array[i, i];
                        d += Math.Pow(array[i, j], 2);
                    }
                }
                array[i, n] /= array[i, i];
                array[i, i] = 0;
            }

            if (!ConvergenceCheck(array))
                return null;
            d = 2 * e;
            while (d > e)
            {
                d = 0;

                for (int i = 0; i < n; ++i)
                {
                    y[i] = array[i, n];
                    for (int j = 0; j < n; ++j)
                    {
                        y[i] += array[i, j] * x[j];
                    }
                    d += Math.Pow(y[i] - x[i], 2);
                    x[i] = y[i];
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
