using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public User User { get; set; }
        public DateTime CardExpirationDate { get; set; }
        public string CardPin { get; set; }
        public Balance Balance { get; set; }
        public delegate void CreditCardHandler(string message);
        public event CreditCardHandler? NotifyAdd;
        public event CreditCardHandler? NotifySpend;
        public event CreditCardHandler? NotifyStartCredit;
        public event CreditCardHandler? NotifyCreditLimit;
        public event CreditCardHandler? NotifyPin;

        public CreditCard(string cardNumber, User user, DateTime cardExpirationDate, string cardPin, Balance balance)
        {
            CardNumber = cardNumber;
            User = user;
            CardExpirationDate = cardExpirationDate;
            CardPin = cardPin;
            Balance = balance;
            NotifyAdd += (message) => Console.WriteLine(message);
            NotifySpend += (message) => Console.WriteLine(message);
            NotifyStartCredit += (message) => Console.WriteLine(message);
            NotifyCreditLimit += (message) => Console.WriteLine(message);
            NotifyPin += (message) => Console.WriteLine(message);
        }
        public void AddAccount(decimal value)
        {
            if (Balance.Value >= 0 && Balance.CheckCreditStart() != true)
            {
                Balance.Add(value);
                Console.ForegroundColor = ConsoleColor.Green;
                NotifyAdd?.Invoke($" {User.Name} Ваш рахунок поповнено на {value} грн. Поточний баланс {Balance.Value} грн.");
                Console.ResetColor();
            }
            else
            {
                if (Balance.CheckCreditRepay(value) != true)
                {
                    Balance.AddCredit(value);
                    Console.ForegroundColor = ConsoleColor.Green;
                    NotifyAdd?.Invoke($" {User.Name} Ваш кредитний рахунок поповнено на {value} грн. Поточний кредитний баланс {Balance.CreditValue} грн.");
                    Console.ResetColor();
                }
                else 
                {
                    Balance.AddCredit(value);
                    if (Balance.RestValue() == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        NotifyAdd?.Invoke($" {User.Name} Ваш поточний кредит закрито. Кредитний ліміт відновлено до {Balance.CreditLimit} грн. " +
                            $" Баланс {Balance.Value} грн.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Balance.Add(Balance.RestValue());
                        Console.ForegroundColor = ConsoleColor.Green;
                        NotifyAdd?.Invoke($" {User.Name} Ваш поточний кредит закрито. Поточний баланс {Balance.Value} грн.");
                        Console.ResetColor();
                    }
                }
            }
        }
        public void SpendAccount(decimal value)
        {
            if (Balance.Value >= value)
            {
                Balance.Spend(value);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                NotifySpend?.Invoke($" {User.Name} з рахунку списано {value} грн. Поточний баланс {Balance.Value} грн.");
                Console.ResetColor();
            }
            else
            {
                if (Balance.CheckCreditStart())
                {
                    if (Balance.CheckCreditEnouph(value))
                    {
                        if (Balance.CheckCreditLimit())
                        {
                            Balance.SpendCredit(value);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            NotifySpend?.Invoke($" {User.Name} з кредитного рахунку списано {value} грн. Поточний кредитний баланс {Balance.CreditValue} грн.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Balance.SpendCredit(value);
                            NotifySpend?.Invoke($" {User.Name} з кредитного рахунку списано {value} грн.");
                            Console.ForegroundColor = ConsoleColor.Red;
                            NotifyCreditLimit?.Invoke($" Ви вичерпали кредитний ліміт. Внесіть кошти для погашення кредиту");
                            Console.ResetColor();
                            return;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        NotifyCreditLimit?.Invoke($" {User.Name} На Вашому кредитному рахунку недостатньо коштів для проведення операції." +
                            $"\nПоточний кредитний баланс дорівнює {Balance.CreditValue} грн." +
                            $"\nПоповніть кредитний баланс!");
                        Console.ResetColor();
                    }
                }
                else
                {
                    if (Balance.CheckCreditLimit() != true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        NotifySpend?.Invoke($" {User.Name}, на Вашому рахунку недостатньо коштів для виконання операції." +
                        $"\nЧи бажаєте відкрити кредитний ліміт на {Balance.CreditLimit} грн.?" +
                        $"\n натисніть 1 якщо ТАК" +
                        $"\n натисніть 2 якщо НІ");
                        Console.ResetColor();
                        int result = Convert.ToInt32(Console.ReadLine());
                        switch (result)
                        {
                            case 1:
                                Balance.StartCredit();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                NotifyStartCredit?.Invoke($" {User.Name} Ваш кредитний ліміт відкрито. Поточний кредитний баланс {Balance.CreditValue} грн.");
                                Console.ResetColor();
                                if (Balance.CheckCreditEnouph(value))
                                {
                                    Balance.SpendCredit(value);
                                    NotifySpend?.Invoke($" {User.Name} з кредитного рахунку списано {value} грн. Поточний кредитний баланс {Balance.CreditValue} грн.");
                                }
                                else
                                {
                                    NotifyCreditLimit?.Invoke($" {User.Name} На Вашому кредитному рахунку недостатньо коштів для проведення операції.");
                                }
                                break;
                            case 2:
                                if (Balance.CheckCreditLimit())
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    NotifySpend?.Invoke($"Кредитна лінія не відкрита. Незабудьте поповнити кредитний баланс.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    NotifySpend?.Invoke($"Кредитна лінія не відкрита. Незабудьте поповнити поточний баланс.");
                                    Console.ResetColor();
                                }
                               
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                NotifySpend?.Invoke($"Невірне значення.");
                                Console.ResetColor();
                                break;
                        }
                    }
                    else
                    {
                        NotifyCreditLimit?.Invoke($" {User.Name} На Вашому кредитному рахунку недостатньо коштів для проведення операції." +
                            $"\n Поповніть кредитний баланс.");
                    }
                    
                }
               
            } 
            
        }
        public void ChangePin()
        {
            Console.WriteLine("Заміна PIN коду картки");
            Console.WriteLine("Хочете змінити PIN код?" +
                "\n 1 - ТАК" +
                "\n 2 - НІ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введіть старий PIN код");
                    string oldPin = Console.ReadLine();
                    
                    if (oldPin != CardPin)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        NotifyPin?.Invoke($"Невірний PIN код");
                        Console.ResetColor();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Введіть новий PIN код");
                        string newPin = Console.ReadLine();
                        Console.WriteLine("Повторіть новий PIN код");
                        string newPin2 = Console.ReadLine();
                        if (newPin != newPin2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            NotifyPin?.Invoke($"Новий PIN код не співпадає");
                            Console.ResetColor();
                            return;
                        }
                        else
                        {
                            CardPin = newPin;
                            Console.ForegroundColor = ConsoleColor.Green;
                            NotifyPin?.Invoke($" {User.Name} Ваш PIN змінено на {CardPin}");
                            Console.ResetColor();
                        }
                    }
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    NotifyPin?.Invoke($"Відміна зміни PIN коду");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    NotifyPin?.Invoke($"Відміна операції");
                    break;
            }


           
        }
         
        
    }  
}
