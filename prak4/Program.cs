using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prak4
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 2.5;
            double b = 2.6;
            double e = 0.0001;

            Console.WriteLine(Combine(a, b, e));
            Console.WriteLine(Chord(a, b, e));
            Console.WriteLine(Tangent(a, b, e));
        }

        public static double Combine(double a, double b, double e)
        {
            double h = (b - a) / 100;
            double x = Calc(a);
            double y = Calc(a + 2 * h) - 2 * Calc(a + h) + Calc(a);

            double x0;
            double x1;
            double c;

            if (x * y < 0)
            {
                x0 = a;
                x1 = b;
                c = b;
            }
            else
            {
                x0 = b;
                x1 = a;
                c = a;
            }

            double x2 = (x0 * Calc(c) - c * Calc(x0)) / (Calc(c) - Calc(x0));
            double x3 = x1 - Calc(x1) / CalcProizvod(x1);

            while (Math.Abs(x1 - x0) > e)
            {
                x0 = x2;
                x2 = (x0 * Calc(c) - c * Calc(x0)) / (Calc(c) - Calc(x0));
                x1 = x3;
                x3 = x1 - Calc(x1) / CalcProizvod(x1);
            }

            x = (x2 + x3) / 2;

            return x;
        }

        public static double Chord(double a, double b, double e)
        {
            double h = (b - a) / 2;
            double y = Calc(a);
            double d = Calc(a + 2 * h) - 2 * Calc(a + h) + Calc(a);

            double x0 = y * d < 0 ? a : b;
            double c = y * d < 0 ? b : a;

            double x1 = (x0 * Calc(c) - c * Calc(x0)) / (Calc(c) - Calc(x0));

            while (Math.Abs(x1 - x0) > e)
            {
                x0 = x1;
                x1 = (x0 * Calc(c) - c * Calc(x0)) / (Calc(c) - Calc(x0));
            }

            return x1;
        }

        public static double Tangent(double a, double b, double e)
        {
            double h = (b - a) / 2;
            double x = Calc(a);
            double y = Calc(a + 2 * h) - 2 * Calc(a + h) + Calc(a);

            double x0 = x * y > 0 ? a : b;
            double x1 = x0 - Calc(x0) / CalcProizvod(x0);

            while (Math.Abs(x1 - x0) > e)
            {
                x0 = x1;
                x1 = x0 - Calc(x0) / CalcProizvod(x0);
            }

            return x1;
        }

        static public double Calc(double x)
        {
            return Math.Pow(2, -x) - 10 + 0.5 * Math.Pow(x, 2);
        }

        static public double CalcProizvod(double x)
        {
            return 1 + Math.Pow(2, x) * Math.Pow(Math.Log(2), 2);
        }
    }
}
