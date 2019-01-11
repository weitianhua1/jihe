

namespace ContosoUniversity.Models
{
    //枚举类型（整型）
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }  //带问号表达字段可以为空（Grade属性是枚举）

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}