using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prak3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0.3;
            double b = 0.4;
            double e = 0.00001;

            double a1 = 0;  //Separetion 
            double b1 = 1;  //Separetion 
            double h = 0.1; //Separetion 

            Console.WriteLine(HalfDivision(a, b, e));
            Console.WriteLine(Separation(a1, b1, h));
            Console.WriteLine(Iteration(a, b, e));
        }

        public static double HalfDivision(double a, double b, double e)
        {
            while (b - a > 2 * e)
            {
                double c = (a + b) / 2;

                if (Calc(a) * Calc(c) < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }
            }
            return (a + b) / 2;
        }

        public static string Separation(double a, double b, double h)
        {
            double x1 = a;
            double x2 = x1 + h;
            double y1 = Calc(x1);

            while (x2 < b)
            {
                double y2 = Calc(x2);

                if (y1 * y2 < 0)
                {
                    return $"{x1} {x2}";
                }

                x1 = x2;
                x2 = x1 + h;
                y1 = y2;
            }

            return "Choose a different interval";
        }

        public static double Iteration(double a, double b, double e)
        {
            double x0 = (a + b) / 2;
            double x1 = CalcForIter(x0);

            while (Math.Abs(x1 - x0) > e)
            {
                x0 = x1;
                x1 = CalcForIter(x0);
            }
            return x1;
        }

        public static double Calc(double x)
        {
            return Math.Sqrt(4 * x + 7) - 3 * Math.Cos(x);
        }

        public static double CalcForIter(double x)
        {
            return Math.Acos(Math.Sqrt(4 * x + 7) / 3);
        }
    }
}

