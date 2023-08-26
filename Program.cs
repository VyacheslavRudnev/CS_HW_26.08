using System.Text;

namespace ConsoleApp260823
{
    internal class Program
    {
//Завдання 2
//Створіть набір методів:
//- Метод відображення поточного часу;
//- Метод відображення поточної дати;
//- Метод відображення поточного дня тижня;
//- Метод для підрахунку площі трикутника;
//- Метод для підрахунку площі прямокутника.
//Для реалізації проєкту використовуйте делегати: Action,
//Predicate, Func.

        delegate void MyDelegate();
        static void Main(string[] args)
        {
            Console.WriteLine("HW/Mod09/ex02\n");
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Action action = MyMethods.ShowTime;
            action += MyMethods.ShowDate;
            action += MyMethods.ShowDayOfWeek;
            action.Invoke();
            Console.WriteLine();

            Predicate<string> predicate = MyMethods.IsDate;
            Console.WriteLine(predicate("12.12"));
            Console.WriteLine(predicate("12.12.2012"));
            Console.WriteLine(predicate("якесь значення"));
            Console.WriteLine();

                     

            Func<double, double, double, double> func = MyMethods.ShowTriangleArea;
            func.Invoke(3, 4, 5);
            Console.WriteLine();

            Func<double, double, double> func2 = MyMethods.ShowRectangleArea;
            func2.Invoke(3, 4);
            Console.WriteLine(); 
        }
    }
}