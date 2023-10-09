using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.Classes
{
    public class EmployeeDataContext : DbContext
    {
        public EmployeeDataContext() : base("name=TestQuestEntities") { }
        
        public DbSet<Employee> Employees { get; set; }
    }
}
