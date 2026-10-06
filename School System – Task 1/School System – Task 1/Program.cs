using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System___Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string StudentName = "Sara Sawalmeh";
            int StudentAge = 23;
            double StudentGrade = 30;
            double StudentAverage = 80.7;
            char StudentGender = 'F';
            bool IsStudentActive = true;
            Console.WriteLine("---------------Part1----------------");
            Console.WriteLine("Name :" + StudentName);
            Console.WriteLine("Age :" + StudentAge);
            Console.WriteLine("Grade :" + StudentGrade);
            Console.WriteLine("Average :" + StudentAverage);
            Console.WriteLine("Gender :" + StudentGender);
            Console.WriteLine("Grade :" + IsStudentActive);
            Console.WriteLine("---------------Part2----------------");

            ///////////////////////////////////////////////////////////////

            string[] students = { "Ahmad", "Sara", "Omar", "Lina" };
            Console.WriteLine("Student 1:" + students[0]);
            Console.WriteLine("Student 2:" + students[1]);
            Console.WriteLine("Student 3:" + students[2]);
            Console.WriteLine("Student 4:" + students[3]);
            Console.WriteLine("Number of Students:" + students.Length);

            Console.WriteLine("---------------Part3----------------");
            //////////////////////////////////////////////////////////////////

            Console.WriteLine("Student 1:" + students[0]);
            Console.WriteLine("Student 1:" + students[students.Length - 1]);
            students[3] = "Dana";
            Console.WriteLine("===== After Change =====");
            Console.WriteLine("Student 1:" + students[0]);
            Console.WriteLine("Student 2:" + students[1]);
            Console.WriteLine("Student 3:" + students[2]);
            Console.WriteLine("Student 4:" + students[3]);

            ///////////////////////////////////////////////////////////////////
        }
    }
}
