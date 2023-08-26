using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp260823
{
    public class MyMethods
    {
        public static void ShowTime()
        {
            Console.WriteLine($"Час: {DateTime.Now.ToLongTimeString()}");
        }
        public static void ShowDate()
        {
            Console.WriteLine($"Дата: {DateTime.Now.ToShortDateString()}");
        }
        public static void ShowDayOfWeek()
        {
            Console.WriteLine($"День: {DateTime.Now.DayOfWeek}");
        }
        public static bool IsDate(string date)
        {
            DateTime dt;
            if (DateTime.TryParse(date, out dt))
                return true;
            else
                return false;
        }
        public static double ShowTriangleArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine($"Площа трикутника = {area}");
            return area;
        }
        public static double ShowRectangleArea(double a, double b)
        {
            double area = a * b;
            Console.WriteLine($"Площа прямокутника = {area}");
            return area;
        }
        
    }
}
