using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            //获取将处理过的数据列表
            empListModel.EmployeeViewList = getEmpVmList();
            // 获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();
            //将数据送往视图
            return View(empListModel);
        }

        //跳转新增页面
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }

        public ActionResult UpdateEmployee()
        {
            return View();
        }


        //保存
        public ActionResult Save(Employee emp)
        {
            //将数据保存
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            empBL.AddEmp(emp);
            //抓取表单中的姓名与工资
            //return (emp.Name + "----" + emp.Salary.ToString());

            return new RedirectResult("index"); //跳转到index（RedirectResult:跳转）
        }

        //删除
        public ActionResult Delete(int id)
        {

            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            empBL.DeleteEmployee(id);
            //return id.ToString();
            return RedirectToAction("index");
        }

        //编辑
        public ActionResult Update(int id)
        {
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            ViewBag.id = id;
            Employee emp = empBL.Query(id);
            //empBL.Query(id)
            return View("UpdateEmployee",emp);
            
        }
        [HttpPost]
        public ActionResult Update(Employee emp)
        {
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            empBL.UpdateEmp(emp);
            return RedirectToAction("index");
        }

        [NonAction]
        //获取列表
        List<EmployeeViewModel> getEmpVmList()
        {
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = empBL.GetEmployeeList();
            //员工原始数据加工后的视图数据列表，当前状态是空的
            var listEmpVm = new List<EmployeeViewModel>();

            //通过循环遍历员工原始数据数组，将数据一个一个的转换，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeId = item.EmployeeID;
                empVmObj.EmployeeName = item.Name;
                empVmObj.EmployeeSalary = item.Salary.ToString("C");//ToString("C")货币化
                if (item.Salary > 10000)
                {
                    empVmObj.EmployeeGrade = "土豪";
                }
                else
                {
                    empVmObj.EmployeeGrade = "qiong";
                }

                listEmpVm.Add(empVmObj);
            }

            return listEmpVm;

        }


        [NonAction]
        // 获取问候语
        string getGreeting()
        {
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
            return greeting;
        }


        [NonAction]
        //获取用户名
        string getUserName()
        {
            return "Admin";
        }
    }
}