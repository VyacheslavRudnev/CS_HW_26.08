using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp260823
{
    public class Balance
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public decimal CreditValue { get; set; }
        public decimal CreditLimit { get; set; }
        public Balance()
        {
            Value = 0;
            CreditValue = 0;
            CreditLimit = 10000;
        }
        public void Add(decimal value)
        {
            Value += value;
        }
        public void Spend(decimal value)
        {
            Value -= value;
        }
        public void AddCredit(decimal value)
        {
            CreditValue += value;
        }
        public void SpendCredit(decimal value)
        {
            CreditValue -= value;
        }
        public void StartCredit()
        {
            CreditValue += CreditLimit;
        }
        public bool CheckCreditLimit()
        {
            if (CreditValue != 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckCreditStart()
        {
            if (CreditValue > 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckBalanceEnouph(decimal value)
        {
            if (Value - value >= 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckCreditEnouph(decimal value)
        {
            if (CreditValue - value >= 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckCreditRepay(decimal value)
        {
            if (CreditValue + value < CreditLimit)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public decimal RestValue()
        {
           return Value += CreditValue - CreditLimit;
        }
       
        
        

    }
}
         
