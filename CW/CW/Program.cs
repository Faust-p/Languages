using System;
using System.Collections.Generic;
using System.Linq;

namespace CW
{
    class Program
    {
        static void Main()
        {
            List<Employee> peoples = new List<Employee>();
            Random random = new Random();
            Employee people;
            string[] Name = new string[] { "Александр", "Никита", "Иван", "Василий", "Артём" };
            string[] Surname = new string[] { "Павленко", "Усков", "Макалич", "Птахин", "Герганов" };
            string[] Patronymic = new string[] { "Иванович", "Александрович", "Артёмович", "Владимирович", "Дмитриевич" };
            string[] Department = new string[] { "Кадров", "Маркетинга", "Учета" };
            int[] Number = new int[15];
            int count;
            int sort;
            string sortSurname;
            while (true)
            {
                try
                {
                    for (int i = 0; i < 15; i++)
                    {
                        count = 1;
                        do
                        {
                            var Phone = random.Next(101, 116);
                            if (!Number.Contains(Phone))
                            {
                                people = new Employee(i + 1, Name[random.Next(0, 5)], Surname[random.Next(0, 5)], Patronymic[random.Next(0, 5)], Department[random.Next(0, 3)], Phone);
                                peoples.Add(people);
                                Number[i] = Phone;
                                count = 0;
                            }
                        }
                        while (count == 1);
                    }

                    Console.WriteLine($"{"Id",-5}{"Name",-15}{"Surname",-15}{"Patronymic",-15}{"Department",-15}{"Number"}");
                    foreach (Employee f in peoples)
                    {
                        f.Display();
                    }

                    Console.Write("Сортировка списка по столбцу номер: ");
                    sort = Int32.Parse(Console.ReadLine());
                    switch (sort)
                    {
                        case 1:
                            peoples.Sort((a, b) => a.ID.CompareTo(b.ID));
                            break;
                        case 2:
                            peoples.Sort((a, b) => a.Name.CompareTo(b.Name));
                            break;
                        case 3:
                            peoples.Sort((a, b) => a.Surname.CompareTo(b.Surname));
                            break;
                        case 4:
                            peoples.Sort((a, b) => a.Patronymic.CompareTo(b.Patronymic));
                            break;
                        case 5:
                            peoples.Sort((a, b) => a.Department.CompareTo(b.Department));
                            break;
                        case 6:
                            peoples.Sort((a, b) => a.Number.CompareTo(b.Number));
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine($"{"Id",-5}{"Name",-15}{"Surname",-15}{"Patronymic",-15}{"Department",-15}{"Number"}");
                    foreach (Employee f in peoples)
                    {
                        f.Display();
                    }
                    Console.WriteLine();

                    Console.Write("Введите фамилию рабочего: ");
                    sortSurname = Console.ReadLine();
                    List<Employee> surname = peoples.Where(x => x.Surname.ToLower().Equals(sortSurname.ToLower())).ToList();
                    Console.WriteLine("Такой человек существует? - " + (surname.Count > 0));
                    if (surname.Count > 0)
                    {
                        Console.WriteLine($"{"Id",-5}{"Name",-15}{"Surname",-15}{"Patronymic",-15}{"Department",-15}{"Number"}");
                        foreach (Employee e in surname)
                        {
                            if (e.Surname.ToLower() == sortSurname.ToLower())
                                e.Display();
                        }
                    }
                    Console.WriteLine();

                    Console.WriteLine("Группировка по отделам:");
                    var EmployeeGroups = from People in peoples
                                         group People by People.Department;
                    foreach (IGrouping<string, Employee> group in EmployeeGroups)
                    {
                        Console.WriteLine("Отдел {0}: {1} человек(а)", group.Key, group.ToList().Count);
                        Console.WriteLine($"{"Id",-5}{"Name",-15}{"Surname",-15}{"Patronymic",-15}{"Department",-15}{"Number"}");
                        foreach (Employee employeeGroups in group)
                        {
                            employeeGroups.Display();
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();

                    Console.WriteLine("Повторить программу?\n1 - Да;\nДругое число - Нет");
                    int m = int.Parse(Console.ReadLine());
                    if (m == 1)
                    {
                        Console.Clear();
                        Main();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Main();
                }
            }
        }
    }
}
