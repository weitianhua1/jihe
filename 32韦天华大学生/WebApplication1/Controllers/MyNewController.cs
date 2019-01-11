using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MyNewController : Controller
    {
        // GET: MyNew
        public ActionResult Index()
        {
            Customer ct = new Customer();
            ct.CustomerName = "abc";
            ct.Address = "lzzy";
            return View(ct);
        }

        public ActionResult cust()
        {
            Customer ct = new Customer();
            ct.CustomerName = "abc";
            ct.Address = "lzzy";

            Employee emp = new Employee();
            emp.Name = "zhangsan";
            emp.Salary = 1222;

            EmCu emCu = new EmCu();
            emCu.CustomerInfo = ct;
            emCu.EmployeeInfo = emp;

            return View("View2",emCu);
        }
    }
}