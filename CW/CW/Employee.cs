using System;
using System.Collections.Generic;
using System.Text;

namespace CW
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Department { get; set; }
        public int Number { get; set; }

        public Employee(int id, string name, string Surname, string Patronymic, string Department, int Number)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
            this.Department = Department;
            this.Number = Number;
        }

        public void Display()
        {
            Console.WriteLine($"{ID,-5}{Name,-15}{Surname,-15}{Patronymic,-15}{Department,-15}{Number}");
        }
    }
}
