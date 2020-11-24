using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLayer;
namespace DataAcess
{
   public  class dataacessgetsal
    {
       
        TESTEntities te = new TESTEntities();
     public    List<Employeeobj> getsalarytype(int id)
        {
            var employeetype = te.employees.Where(x => x.id == id).Select(x => new Employeeobj()
            {
                id = x.id,
                type = x.type,
                sal = x.salary,
                name = x.employeename

            }).ToList();
            return employeetype;
        }

        public List<Employeeobj> getallsalarytype()
        {
            var employeetype = te.employees.Select(x => new Employeeobj()
            {
                id = x.id,
                type = x.type,
                sal = x.salary,
                name = x.employeename

            }).ToList();
            return employeetype;
        }

    }
}
