using System.Net.NetworkInformation;
using System.Text;

namespace ConsoleApp260823
{
//Завдання 3
//Створіть клас «Кредитна картка». Клас повинен містити:
//- Номер картки;
//- ПІБ власника;
//- Термін дії карти;
//- PIN;
//- Кредитний ліміт;
//- Сума грошей.
//Створіть потрібний набір способів класу. Реалізуйте
//події для наступних ситуацій:
//- Поповнення рахунку;
//- Витрата коштів з рахунку;
//- Старт використання кредитних коштів;
//- Досягнення ліміту заданої суми грошей;
//- Зміна PIN.

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HW/Mod09/ex03\n");
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            User user = new User("Вячеслав", "Руднєв");
            Balance balance = new Balance();
            CreditCard creditCard = new CreditCard("1234 5678 9012 3456", user, new DateTime(2022, 12, 31), "123", balance);

            creditCard.AddAccount(1000);
            creditCard.SpendAccount(500);
            creditCard.SpendAccount(500);
            creditCard.SpendAccount(500);
            creditCard.SpendAccount(500);
            creditCard.SpendAccount(8000);
            creditCard.AddAccount(1000);
            creditCard.AddAccount(7000);
            creditCard.AddAccount(1500);
            creditCard.AddAccount(1000);
            creditCard.ChangePin();
            
            
            


            
















        }
    }
}