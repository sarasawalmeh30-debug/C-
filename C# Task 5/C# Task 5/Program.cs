using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Sara", 22,"Moath bin Jabl", 90, 101);
            Student s2 = new Student("Ahmad", 20,"Bait yafa", 85, 102);
            Teacher t1 = new Teacher("Khaled", 35, "Moath bin Jabl", "Math");
            s1.DisplayStudentInfo();
            Console.WriteLine("---------------------------------"); 
            s2.DisplayStudentInfo();
            Console.WriteLine("---------------------------------");
            t1.DisplayTeacherInfo();
            Console.WriteLine("---------------------------------");
            SchoolReport r1 = new SchoolReport("Daily Report");
            r1.DisplayReportTitle();
        }
    }
}
