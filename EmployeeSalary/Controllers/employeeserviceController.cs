using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeSalary.Models;
using BussinessLayer;
using ObjectLayer;

namespace EmployeeSalary.Controllers
{
    public class employeeserviceController : ApiController
    {
        public employeeserviceController()
        {


        }


        public  IEnumerable<Employeeobj> Getasync()
        {


            var employeeinfo = getsaltypebussiness.allemptype();
             
            return employeeinfo;
        }


        public IEnumerable<Employeeobj> Get(int id)
        {
            var employeeinfo = getsaltypebussiness.emptype(id);
            return employeeinfo;
        }







    }
}
