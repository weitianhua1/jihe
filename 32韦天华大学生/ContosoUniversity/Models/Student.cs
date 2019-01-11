using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Student
    {

        public int ID { get; set; }
        [Display(Name="姓名")] //数据注解

        public string Name { get; set; }
        [Display(Name = "注册日期")]
        public DateTime EnrollmentDate { get; set; }  //注册事件

        //导航属性 来表示（一对多关系）   Enrollment注册
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}