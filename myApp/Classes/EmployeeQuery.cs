using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.Classes
{
    public class EmployeeQuery
    {
        public void CreateTable()
        {
            try
            {
                using (EmployeeDataContext context = new EmployeeDataContext())
                {
                    Employee employee = new Employee
                    {
                        FullName = "Ivanov Roman Andreevich",
                        Birthday = new DateTime(2003, 8, 14),
                        Gender = "Male"
                    };
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
                Console.WriteLine("Таблица создана!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Таблица не создана!");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public void InsertEmployee(string[] emp)
        {
            try
            {
                using (EmployeeDataContext context = new EmployeeDataContext())
                {
                    Employee employee = new Employee
                    {
                        FullName = emp[0],
                        Birthday = Convert.ToDateTime(emp[1]),
                        Gender = emp[2]
                    };
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
                Console.WriteLine("Сотрудник добавлен!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сотрудник не добавлен!");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public void SelectAllEmployee()
        {
            try
            {
                using (EmployeeDataContext context = new EmployeeDataContext())
                {
                    var EmployeesData = context.Employees.OrderBy(e => e.FullName).ToList();
                    if (EmployeesData != null)
                    {
                        foreach (var Employee in EmployeesData)
                        {
                            Console.WriteLine($"Уникальный номер - {Employee.ID} ФИО - {Employee.FullName} " +
                                $"Дата рождения - {Employee.Birthday.ToShortDateString()} Пол - {Employee.Gender} " +
                                $"Полных лет - {Convert.ToInt32((DateTime.Now - Employee.Birthday).Days / 365)}");
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Таблица пуста!");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Вывод данных не удался!");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public void SelectEmployeeWithFilter()
        {
            try
            {
                using (EmployeeDataContext context = new EmployeeDataContext())
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    var EmployeesData = context.Employees.Where(e => DbFunctions.Like(e.FullName, "F%")).Where(e => e.Gender == "Male").ToList();
                    timer.Stop();
                    Console.WriteLine($"Запрос выполнен за {timer.Elapsed} секунд");
                    Console.ReadKey();
                    if (EmployeesData != null)
                    {
                        foreach (var Employee in EmployeesData)
                        {
                            Console.WriteLine($"Уникальный номер - {Employee.ID} ФИО - {Employee.FullName} " +
                                $"Дата рождения - {Employee.Birthday.ToShortDateString()} Пол - {Employee.Gender} " +
                                $"Полных лет - {Convert.ToInt32((DateTime.Now - Employee.Birthday).Days / 365)}");
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Совпадений не найдено или таблица пуста!");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Вывод данных не удался!");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public void GenerateEmployees()
        {
            try
            {
                Generator generator = new Generator();
                for (int i = 0; i < 100; i++)
                {
                    EmployeeDataContext context1 = new EmployeeDataContext();
                    for (int i1 = 0; i1 < 10000; i1++)
                    {
                        context1.Employees.Add(generator.GenerateEmployeeRandomLastName());
                        Console.WriteLine(i + " " + i1);
                    }
                    context1.SaveChanges();
                }
                EmployeeDataContext context = new EmployeeDataContext();
                for (int i = 0; i < 100; i++)
                {
                    context.Employees.Add(generator.GenerateEmployeeFLastName());
                }
                context.SaveChanges();
                Console.WriteLine("Сотрудники добавлены!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сотрудники не добавлены!");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
