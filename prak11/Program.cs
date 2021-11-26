using System;

namespace prak11
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0;
            double y = 1;
            double h = 0.1;
            double b = 1;

            Console.WriteLine(Eyler(x, y, h, b));
        }

        static string Eyler(double x, double y, double h, double b)
        {
            string result = "";

            while (x <= b - h)
            {
                y += h * Calc(x, y);
                x += h;

                result += $"{y}{Environment.NewLine}";
            }

            return result;
        }

        static double Calc(double x, double y)
        {
            return (x + x * y * y)/(y - x * x * y);
        }
    }
}
