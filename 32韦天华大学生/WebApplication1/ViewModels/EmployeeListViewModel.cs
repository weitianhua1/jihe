using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class EmployeeListViewModel
    {
        public string UserName { get; set; }
        public string Greeting { get; set; }
        public List<EmployeeViewModel> EmployeeViewList { get; set; }

    }
}