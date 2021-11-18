using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prak9
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 1;
            double b = 2;
            double e = 0.001;
            int n = 50;
            Console.WriteLine(Math.Round(Rectangle(a, b, e, n), 3));
        }

        public static double Rectangle(double a, double b, double e, int n)
        {
            double i0 = 0;
            double i1 = Int32.MaxValue;

            while (Math.Abs(i1 - i0) > e)
            {
                n *= 2;
                i0 = i1;
                double h = (b - a) / n;
                i1 = 0;

                for (int i = 0; i < n; ++i)
                {
                    double x = a + i * h;
                    i1 += Calc(x);
                }
                i1 *= h;
            }

            return i1;
        }

        public static double Calc(double x)
        {
            return 1 / (x * Math.Sqrt(1 + x * x * x + Math.Pow(x, 6)));
        }

    }
}
