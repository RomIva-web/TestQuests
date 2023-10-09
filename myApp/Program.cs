using myApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace myApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeQuery employeeQuery = new EmployeeQuery();
            switch (args[0])
            {
                case "1": employeeQuery.CreateTable(); break;
                case "2": employeeQuery.InsertEmployee(new string[]{ args[1],args[2],args[3]}); break;
                case "3": employeeQuery.SelectAllEmployee(); break;
                case "4": employeeQuery.GenerateEmployees(); break;
                case "5": employeeQuery.SelectEmployeeWithFilter();  break;
                default: Console.WriteLine("Режим не найден!"); Console.ReadKey(); break;
            }
        }
    }
}
