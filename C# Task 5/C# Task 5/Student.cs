using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_5
{
    internal class Student:Person
    {
        public int Grade {  get; set; }
        public int StudentId { get; set; }
        public Student(string n,int a,string sn,int G,int i):base(n,a,sn) 
        {
            Grade = G;
            StudentId = i;
         
        }
        public void DisplayStudentInfo()
        {
            DisplayInfo();
            Console.WriteLine("Grade: " + Grade);
            Console.WriteLine("Student ID: " + StudentId);
            Console.WriteLine("School: " + SchoolName);
        }
    }
}
