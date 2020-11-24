using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess;
using ObjectLayer;
namespace BussinessLayer
{
    public static class getsaltypebussiness
    {
      
   static    dataacessgetsal sdmm = new dataacessgetsal();
  
        public  static List<Employeeobj> emptype(int id)
        {
            //var sall = 0.00m;
            List<Employeeobj> enmp = sdmm.getsalarytype(id);
            foreach(var item in enmp)
            {
                if(item.type==1)
                {
                    item.AnnualSalary = 120 * item.sal * 12??0;
                    item.typename = "Hourly Basis";
                }
            
             else if(item.type==2)
                {

                    item.AnnualSalary = item.sal * 12??0;
                    item.typename = "Monthly Basis";
                }
            
            
            }
            return enmp;
        }

        public static List<Employeeobj> allemptype()
        {
            //var sall = 0.00m;
            List<Employeeobj> enmp = sdmm.getallsalarytype();
            foreach (var item in enmp)
            {
                if (item.type == 1)
                {
                    item.AnnualSalary = 120 * item.sal * 12 ?? 0;
                    item.typename = "Hourly Basis";
                }

                else if (item.type == 2)
                {

                    item.AnnualSalary = item.sal * 12 ?? 0;
                    item.typename = "Monthly Basis";
                }


            }
            return enmp;
        }












    }
}
