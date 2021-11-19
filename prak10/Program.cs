using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prak10
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 1;
            double b = 2;
            int n = 10;

            Console.WriteLine(Math.Round(Gauss(a, b, n),3));
        }

        public static double Gauss(double a, double b, int n)
        {
            double result = 0;
            double h = (b - a) / n;
            for (double i = a; i < b; i += h)
            {
                result += Calc(i + h / 2 - h / ( 2 * Math.Sqrt(3))) + Calc(i + h / 2 + h / (2 * Math.Sqrt(3)));
            }

            return result * h / 2;
        }

        public static double Calc(double x)
        {
            return Math.Sqrt(1 + x * x);
        }
    }
}
