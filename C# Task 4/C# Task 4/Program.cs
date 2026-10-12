using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("sara",23,80);
            Student student2 = new Student("Ahmad", 25, 70);
            Student student3 = new Student("Omar", 29, 60);
            //student.Name = "Sara";
            //student.Age = 23;
            //student.Grade = 80;
            student1.DisplayInfo();
            student2.DisplayInfo();
            student3.DisplayInfo();
        }
    }
}
