using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class EmployeeViewModel //ViewModel为显示而生
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSalary { get; set; }
        public string EmployeeGrade { get; set; }

    }
}