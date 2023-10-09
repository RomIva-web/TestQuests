using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.Classes
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(150)]
        public string FullName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }
        [Column(TypeName ="nvarchar")]
        [MaxLength(6)]
        public string Gender {  get; set; }
    }
}
