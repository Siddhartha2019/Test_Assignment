using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeSalary.Models
{
    public class Employee
    {
         public int id { get; set; }
        public   int? type { get; set; }
       public  decimal? sal { get; set; }
      public string name { get; set; }
        public decimal ? AnnualSalary { get; set; }
        public string typename { get; set; }
    }
}