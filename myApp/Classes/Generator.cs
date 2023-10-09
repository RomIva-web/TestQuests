using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace myApp.Classes
{
    public class Generator
    {
        string[] ListFirstNameMale = File.ReadAllLines("../../Resources/ListsFirstName/Male.txt");
        string[] ListFirstNameFemale = File.ReadAllLines("../../Resources/ListsFirstName/Female.txt");
        string[] ListLastNameMale = File.ReadAllLines("../../Resources/ListsLastName/Male.txt");
        string[] ListLastNameFemale = File.ReadAllLines("../../Resources/ListsLastName/Female.txt");
        string[] ListPatronymicMale = File.ReadAllLines("../../Resources/ListsPatronymic/Male.txt");
        string[] ListPatronymicFemale = File.ReadAllLines("../../Resources/ListsPatronymic/Female.txt");
        static Random random = new Random();
        public Employee GenerateEmployeeRandomLastName()
        {
            try
            {
                    if (random.Next(1, 3) == 1)
                    {
                        Employee employee = new Employee
                        {
                            FullName = $"{ListLastNameMale[random.Next(0, ListLastNameMale.Length)]} " +
                            $"{ListFirstNameMale[random.Next(0, ListFirstNameMale.Length)]} " +
                            $"{ListPatronymicMale[random.Next(0, ListPatronymicMale.Length)]}",
                            Birthday = new DateTime(random.Next(1980 , 2005), random.Next(1, 12), random.Next(1, 28)),
                            Gender = "Male"
                        };
                        return employee;
                    }
                    else
                    {
                        Employee employee = new Employee
                        {
                            FullName = $"{ListLastNameFemale[random.Next(0, ListLastNameFemale.Length)]} " +
                            $"{ListFirstNameFemale[random.Next(0, ListFirstNameFemale.Length)]} " +
                            $"{ListPatronymicFemale[random.Next(0, ListPatronymicFemale.Length)]}",
                            Birthday = new DateTime(random.Next(1980 , 2005), random.Next(1, 13), random.Next(1, 29)),
                            Gender = "Female"
                        };
                        return employee;
                    }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка во время генерации с рандомной фамилией");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return null;
            }
        }
        public Employee GenerateEmployeeFLastName()
        {
            try
            {
                    Employee employee = new Employee
                    {
                        FullName = $"{ListLastNameMale[6]} {ListFirstNameMale[random.Next(0, ListFirstNameMale.Length)]} {ListPatronymicMale[random.Next(0, ListPatronymicMale.Length)]}",
                        Birthday = new DateTime(random.Next(1980, 2005), random.Next(1, 12), random.Next(1, 28)),
                        Gender = "Male"
                    };
                    return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка во время генерации с фамилией на F");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return null;
            }
        }
    }
}
