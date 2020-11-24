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
        public async Task<ActionResult> Index(int? id)
        {
            IEnumerable<Employee> Employees = null;
            if (id == null)
            {
                try
                {
                    var client = new HttpClient();
                    //client.Timeout = TimeSpan.FromMinutes(30);
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

                catch (Exception ex)
                {
                    if (ex.InnerException is TimeoutException)
                    {
                        ex = ex.InnerException;
                    }
                    else if (ex is TaskCanceledException)
                    {
                        if ((ex as TaskCanceledException).CancellationToken == null || (ex as TaskCanceledException).CancellationToken.IsCancellationRequested == false)
                        {
                            ex = new TimeoutException("Timeout occurred");
                        }
                    }
                    //Logger.Fatal(string.Format("Exception at calling {0} :{1}", url, ex.Message), ex);
                }



            }

             else
            {
                try
                {
                    var client = new HttpClient();
                    //client.Timeout = TimeSpan.FromMinutes(30);

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
                 catch (Exception ex)
                {
                    if (ex.InnerException is TimeoutException)
                    {
                        ex = ex.InnerException;
                    }
                    else if (ex is TaskCanceledException)
                    {
                        if ((ex as TaskCanceledException).CancellationToken == null || (ex as TaskCanceledException).CancellationToken.IsCancellationRequested == false)
                        {
                            ex = new TimeoutException("Timeout occurred");
                        }
                    }
                    //Logger.Fatal(string.Format("Exception at calling {0} :{1}", url, ex.Message), ex);
                }

               
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
            return RedirectToAction("Index", new { id=pid});
        }


    }
}