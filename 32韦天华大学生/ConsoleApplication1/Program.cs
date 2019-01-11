using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var studentList = new List<Student>();
            List<Student> studentList = new List<Student>();

            Student st = new Student();
            st.Name = "zhangsan";
            st.age = 20;

            studentList.Add(st);

            st = new Student();
            st.Name = "李四";
            st.age = 18;

            studentList.Add(st);

            foreach (var item in studentList)
            {
                Console.WriteLine("Name:{0},Age:{1}", item.Name, item.age);
            }
            Console.ReadKey();




        }
    }
}
