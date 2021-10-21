using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prak5
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            double[,] array1 = new double[,]
            {
                { 5.38, 7.33, -0.24, -0.49, -8.41,  4.27},
                { 2.81, -4.69, -6.13, -3.05, -5.19, 5.77 },
                { 7.6, 4.78, 8.59, 0.98, 6.72, 3.7 },
                { -8.44, -8.53, 5.76, -8.34, 4.96,  5.95 },
                { 0.61, 4.63, -4.04, 1.72, 3.61, -6.77 }
            };

            double[,] array2 = new double[,]
            {
                {-6.32, 4.51, -3.84, -7.38, -6.56},
                {4.22, -4.13, -4.16, -1.93, 6.36},
                {1.9, -2.56, -3.94, -1.61, -8.84},
                {7.29, -1.49, 1.79, 6.11, 8},
                {-0.7, -2.39, -4.08, -6.9, 1.65}
            };

            double[,] array3 = new double[,]
            {
                {0.38, 1.83, 5.88, -5.62, 3.33},
                {6.65, -7.51, -5.84, 2.54, -5.38},
                {-1.37, -2.32, 6, 8.49, 3.03},
                {-8.46, 4.73, -1.71, 7.04, -2.11},
                {-7.34, -1.04, -6.43, -4.91, -7.14}
            };

            foreach (var i in Gauss(array1))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("---------------");
            Console.WriteLine(GetDeterminator(array2));
            Console.WriteLine("---------------");
            Console.WriteLine(Print2DArray(InverseArray(array3)));
        }

        public static double[] Gauss(double[,] array)
        {
            int n = array.GetLength(0);

            for (int i = 0; i < n; ++i)
            {
                for (int j = n; j > 0; --j)
                {
                    array[i, j] /= array[i, i];
                }

                for (int k = 0; k < n; ++k)
                {
                    if (k != i)
                    {
                        for (int j = n; j > 0; --j)
                        {
                            array[k, j] -= array[k, i] * array[i, j];
                        }
                    }
                }
            }

            double[] arrayX = new double[n];
            for (int i = 0; i < n; ++i)
            {
                arrayX[i] = array[i, n];
            }

            return arrayX;
        }

        public static double GetDeterminator(double[,] array)
        {
            double det = 1;
            int n = array.GetLength(0);

            for (int i = 0; i < n; ++i)
            {
                det *= array[i, i];
                for (int j = n - 1; j > 0; --j)
                {
                    array[i, j] /= array[i, i];
                }

                for (int k = 0; k < n; ++k)
                {
                    if (k != i)
                    {
                        for (int j = n - 1; j > 0; --j)
                        {
                            array[k, j] -= array[k, i] * array[i, j];
                        }
                    }
                }
            }

            return det;
        }

        public static double[,] InverseArray(double[,] array)
        {
            int n = array.GetLength(0);
            double[,] unitArray = new double[n, n];
            for (int i = 0; i < n; ++i)
            {
                unitArray[i, i] = 1;
            }

            for (int i = 0; i < n; ++i)
            {
                double tempii = array[i, i];
                for (int j = 0; j < n; ++j)
                {
                    unitArray[i, j] /= tempii;
                    array[i, j] /= tempii;
                }

                for (int k = 0; k < n; ++k)
                {
                    double tempki = array[k, i];
                    if (k != i)
                    {
                        for (int j = 0; j < n; ++j)
                        {
                            unitArray[k, j] -= tempki * unitArray[i, j];
                            array[k, j] -= array[k, i] * array[i, j];
                        }
                    }
                }
            }

            return unitArray;
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
