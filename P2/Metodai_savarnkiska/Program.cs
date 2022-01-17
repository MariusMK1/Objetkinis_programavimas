using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodai_savarnkiska
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Nr 0
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx0(x));

            // Nr 1
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx1(x));

            // Nr 2
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx2(x));

            // Nr 3
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx3(x));

            // Nr 4
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx4(x));

            // Nr 5
            //double fx;
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx5(x));

            // Nr 6
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx6(x));

            // Nr 7
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx7(x));

            // Nr 8
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx8(x));

            // Nr 9
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx9(x));

            // Nr 10
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx10(x));

            // Nr 11
            //double x;
            //Console.Write("Įveskite x reikšmę: ");
            //x = double.Parse(Console.ReadLine());
            //Console.WriteLine("fx = {0, 8:f3}", fx11(x));

            // skaičiuotuvas
            double a;
            char b;
            double c;
            double result;
            Console.WriteLine("Įveskite pirmajį skaičių: ");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite matematinės operacijos simbolį:");
            b = char.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite antrajį skaičių: ");
            c = double.Parse(Console.ReadLine());
            if (b == '+')
            {
                Console.WriteLine("Atsakymas = {0,8:f3}", suma(a, c));
            }
            else
                if (b == '-')
            {
                Console.WriteLine("Atsakymas = {0,8:f3}", atimtis(a, c));
            }
            else
                if (b == '*')
            {
                Console.WriteLine("Atsakymas = {0,8:f3}", daugyba(a, c));
            }
            else
                if (b == '/')
            {
                if (c != 0)
                {
                    Console.WriteLine("Atsakymas = {0,8:f3}", dalyba(a, c));
                }
                else
                    Console.WriteLine("Dalyba iš 0 negalima");
            }
            else
                Console.WriteLine("ERROR");
        }
        static double fx0(double sk1)
        {
            if (sk1 >= -2 && sk1 <= 0)
                return Math.Exp(-sk1);
            else
               if (sk1 > 0 && sk1 < 2)
                return 2 * Math.Pow(sk1, 2) + 1;
            else
                return 1 / Math.Pow(sk1, 2);
        }
        static double fx1(double sk1)
        {
            if (sk1 >= -3 && sk1 <= 0)
                return Math.Exp(-sk1);
            else
                if (sk1 > 0 && sk1 <= 1)
                return 5 * sk1 - 7;
            else
                return Math.Sqrt(sk1 + 1);
        }
        static double fx2(double sk1)
        {
            if (sk1 >= -4 && sk1 <= 0)
                return Math.Cos(sk1);
            else
               if (sk1 > 0 && sk1 <= 4)
                return 1 / Math.Pow(sk1 + 5, 3);
            else
                return Math.Sqrt(Math.Pow(sk1, 2) + 1);
        }
        static double fx3(double sk1)
        {
            if (sk1 >= -5 && sk1 <= 0)
                return sk1 + 2 * Math.Pow(sk1, 2);
            else
                if (sk1 > 0 && sk1 < 3)
                return Math.Pow(sk1, 2) + 4;
            else
                return Math.Sqrt(2 * Math.Pow(sk1, 2) + 3);
        }
        static double fx4(double sk1)
        {
            if (sk1 >= -1 && sk1 <= 0)
                return Math.Cos(Math.Pow(sk1, 2));
            else
                if (sk1 > 0 && sk1 < 1)
                return 4 * Math.Pow(sk1, 2) + 3;
            else
                return Math.Sqrt(Math.Pow(sk1, 2) + sk1 + 4);
        }
        static double fx5(double sk1)
        {
            if (sk1 >= -1 && sk1 < 0)
                return 1 / (sk1 + 5);
            else
                if (sk1 >= 0 && sk1 < 1)
                return sk1 + 1;
            else
                return Math.Sqrt(Math.Pow(sk1, 2) + sk1 + 1);
        }
        static double fx6(double sk1)
        {
            if (sk1 >= -1 && sk1 < 0)
                return Math.Pow(Math.Sin(sk1), 2);
            else
                if (sk1 >= 0 && sk1 < 1)
                return Math.Pow(sk1 - 1, 2);
            else
                return Math.Pow(sk1, 2) + sk1 + 1;
        }
        static double fx7(double sk1)
        {
            if (sk1 >= -2 && sk1 < 0)
                return 3.2 * Math.Pow(sk1, 2);
            else
                if (sk1 >= 0 && sk1 <= 1)
                return Math.Pow(Math.Sin(sk1 + 1), 2);
            else
                return 3 * Math.Pow(sk1, 2) - 1;
        }
        static double fx8(double sk1)
        {
            if (sk1 >= -3 && sk1 <= 0)
                return 1 / (sk1 - 5);
            else
                if (sk1 > 0 && sk1 <= 5)
                return Math.Pow(sk1 + 3, 2);
            else
                return Math.Sqrt(sk1 + 5);
        }
        static double fx9(double sk1)
        {
            if (sk1 >= -4 && sk1 < -2)
                return 1 / sk1;
            else
                if (sk1 >= -2 && sk1 <= 2)
                return Math.Cos(sk1);
            else
                return 2 * sk1 + 4;
        }
        static double fx10(double sk1)
        {
            if (sk1 >= -5 && sk1 < 0)
                return 1 / Math.Pow(sk1, 2);
            else
               if (sk1 >= 0 && sk1 <= 2)
                return Math.Sin(sk1 + 1);
            else
                return Math.Sqrt(2 * sk1);
        }
        static double fx11(double sk1)
        {
            if (sk1 >= -6 && sk1 <= -1)
                return 1 / (sk1 - 3);
            else
                if (sk1 > -1 && sk1 <= 3)
                return Math.Pow(sk1, 2) + 6;
            else
                return 2 * sk1 + 3;
        }
        static double suma(double sk1, double sk2)
        {
            return sk1 + sk2;
        }
        static double atimtis(double sk1, double sk2)
        {
            return sk1 - sk2;
        }
        static double daugyba(double sk1, double sk2)
        {
            return sk1 * sk2;
        }
        static double dalyba(double sk1, double sk2)
        {
            return sk1 / sk2;
        }
    }
}
