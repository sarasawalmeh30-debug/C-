using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_4
{
    internal class Student
    {
        public string Name;
        public int Age;
        public int Grade;
        public Student(string n, int a, int g)
        {
            Name = n;
            Age = a;
            Grade = g;

        }
        public void DisplayInfo()
        {
            Console.WriteLine("Name :" + Name);
            Console.WriteLine("Age :" + Age);
            Console.WriteLine("Grade :" + Grade);
            Console.WriteLine("-------------------------------");
        }
    }
}
