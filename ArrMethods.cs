using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp260823
{
    public class ArrMethods
    {
        //Метод для створення масиву з випадкових чисел.
        public static int[] CreateArr(int size)
        {
            int[] arr = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(1, 100);
            }
            return arr;
        }
        //Метод для виведення масиву на екран.
        public static void PrintArr(int[] arr)
        {
            Console.WriteLine("Масив випадкових значень:");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        //Метод для отримання усіх парних чисел у масиві;
        public static void Even(int[] arr)
        {
            Console.WriteLine("Парні числа:");
            foreach (var item in arr)
            {
                if (item % 2 == 0)
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }
        //Метод для отримання усіх непарних чисел у масиві;
        public static void Odd(int[] arr)
        {
            Console.WriteLine("Непарні числа:");
            foreach (var item in arr)
            {
                if (item % 2 != 0)
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }
        //Метод для отримання усіх простих чисел у масиві;
        public static void Prime(int[] arr)
        {
            Console.WriteLine("Прості числа:");
            foreach (var item in arr)
            {
                if (item == 1)
                {
                    Console.Write(item + " ");
                }
                else
                {
                    for (int i = 2; i < item; i++)
                    {
                        if (item % i == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write(item + " ");
                            break;
                        }
                    }
                }
            }
            Console.WriteLine();
        }
        //Метод для отримання усіх чисел Фібоначчі в масиві.
        public static void Fibonacci(int[] arr)
        {
            Console.WriteLine("Числа Фібоначчі:");
            foreach (var item in arr)
            {
                int a = 0;
                int b = 1;
                int c = 0;
                while (c < item)
                {
                    c = a + b;
                    a = b;
                    b = c;
                    if (c == item)
                    {
                        Console.Write(item + " ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
