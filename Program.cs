using System.Text;

namespace ConsoleApp260823
{
    internal class Program
    {
//Завдання 1
//Створіть набір методів для роботи з масивами:
//- Метод для отримання усіх парних чисел у масиві;
//- Метод для отримання усіх непарних чисел у масиві;
//- Метод для отримання усіх простих чисел у масиві;
//- Метод для отримання усіх чисел Фібоначчі в масиві.
//Використовуйте механізми делегатів.

        delegate void MyDelegate(int[] arr);
        static void Main(string[] args)
        {
            Console.WriteLine("HW/Mod09/ex01\n");
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            MyDelegate myDelegate = ArrMethods.Even;
            myDelegate += ArrMethods.Odd;
            myDelegate += ArrMethods.Prime;
            myDelegate += ArrMethods.Fibonacci;
            myDelegate(arr);
            Console.WriteLine();

            Console.WriteLine("Другий варіант, зі створенням масиву випадкових чисел:");
            Console.WriteLine();
            int[] arr01 = ArrMethods.CreateArr(10);
            ArrMethods.PrintArr(arr01);
            myDelegate(arr01);
        }
    }
}