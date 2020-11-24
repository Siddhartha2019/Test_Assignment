using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmployeeSalary.Models;
namespace EmployeeSalary.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public async Task<ActionResult> IndexAsync(int? id)
        {
            IEnumerable<Employee> Employees = null;
            if (id == null)
            {
                try
                {
                    var client = new HttpClient();
                   
                    client.BaseAddress = new Uri("http://localhost:44391/api/");
                    var responseTask = client.GetAsync("employeeservice");
                    await Task.WhenAll(responseTask);
                   // responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                        readTask.Wait();

                        Employees = readTask.Result;
                    }
                    else
                    {


                        Employees = Enumerable.Empty<Employee>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

                catch(AggregateException e)
                {
                    if (e.InnerException is OperationCanceledException)
                    {

                    }

                }

                catch (OperationCanceledException)
                {
                    //Request was cancelled
                };



            }

             else
            {
                try
                {
                    var client = new HttpClient();

                    client.BaseAddress = new Uri("http://localhost:44391/api/");
                    var responseTask = client.GetAsync($"employeeservice/{id}");

                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                        readTask.Wait();

                        Employees = readTask.Result;
                    }
                    else
                    {


                        Employees = Enumerable.Empty<Employee>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

                catch (AggregateException e)
                {
                    if (e.InnerException is OperationCanceledException)
                    {

                    }

                }

                catch (OperationCanceledException)
                {
                    //Request was cancelled
                };

            }
            return View(Employees);

        }






        public ActionResult getemployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult getemployee(int ? pid)
        {
            return RedirectToAction("IndexAsync", new { id=pid});
        }


    }
}