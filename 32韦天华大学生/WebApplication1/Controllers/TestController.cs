using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public string GetString()
        {
            return "hello world! MVC!";
        }

        public Customer getCustomer()
        {
            Customer ct = new Customer();
            ct.CustomerName = "abc";
            ct.Address = "def";
            return ct;           
        }

        public ActionResult GetView() {



            //ViewData["greeting"] = greeting;
            Employee emp = new Employee();
            emp.Name = "李四";
            emp.Salary = 20002;

            EmployeeViewModel vmEmp = new EmployeeViewModel();

            vmEmp.EmployeeName = emp.Name;
            vmEmp.EmployeeSalary = emp.Salary.ToString("C");

            if (emp.Salary > 1000)
            {
                vmEmp.EmployeeGrade = "土豪";
            }
            else {
                vmEmp.EmployeeGrade = "屌丝";
            }

            string greeting;
            //获取当前时间
            DateTime dt = DateTime.Now;
            //获取当前小时数
            int hour = dt.Hour;
            //根据小时数判断需要返回哪个视图，<12 返回myview 否则返回 yourview
            if (hour < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "下午好";
            }
            //vmEmp.Greeting = greeting;


            //vmEmp.UserName = "超级管理员";

            //ViewData["EmpKey"] = emp;
            //ViewBag.EmpKey = emp;
            return View("MyView",vmEmp);

        }


    }
}