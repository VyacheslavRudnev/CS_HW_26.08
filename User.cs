using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp260823
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public User(string name, string surname) 
        {
            Name = name;
            Surname = surname;
        }
        public User(string name, string surname, string middleName)
        {
            Name = name;
            Surname = surname;
            MiddleName = middleName;
        }
        public override string ToString()
        {
            if (MiddleName == null)
            {
                return $"Ім'я: {Name}\nПрізвище: {Surname}";
            }
            return $"Ім'я: {Name}\nПрізвище: {Surname}\nMiddleName: {MiddleName}";
        } 
    }
}
