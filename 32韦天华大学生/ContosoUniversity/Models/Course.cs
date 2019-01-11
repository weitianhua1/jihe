using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        //数据特性：取消数据库主键自增长特性，改为用户自己为记录赋予ID
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //数据库自生成特性
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}