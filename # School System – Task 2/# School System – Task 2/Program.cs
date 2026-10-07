using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __School_System___Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your Name :");
            string StudentName=Console.ReadLine();

            Console.WriteLine("Enter your Age :");
            int StudentAge =Convert.ToInt32( Console.ReadLine());

            Console.WriteLine("Enter your Grade :");
            double  StudentGrade =Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter your Average :");
            double  StudentAverage = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter your Gender :");
            string StudentGender = Console.ReadLine();

            ////////////////////////part2/////////////////////////
            
            Console.WriteLine($"\nWelcome {StudentName}");
            Console.WriteLine($"Name : {StudentName}");
            Console.WriteLine($"Age : {StudentAge}");
            Console.WriteLine($"Grade :{StudentGrade}");
            Console.WriteLine($"Average : {StudentAverage}");
            Console.WriteLine($"Gender :{StudentGender}");

            ////////////////////////part3///////////////////////////////

            Console.WriteLine($"\nName : {StudentName}");
            Console.WriteLine($"Name in Uppercase : {StudentName.ToUpper()}");
            Console.WriteLine($"Name in Lowercase : {StudentName.ToLower()}");
            Console.WriteLine($"First Character : {StudentName[0]}");

            /////////////////////part4////////////////////

            int BonusMarks = 5;
            Console.WriteLine($"\nAverage : {StudentAverage}");
            Console.WriteLine($"Bonus Marks :{BonusMarks}");
            double BonusGrade = StudentAverage + BonusMarks;
            Console.WriteLine($"New Average :{BonusGrade}");

            ////////////////////////part5////////////////////////
            if (BonusGrade >= 50)
            {
                Console.WriteLine("Passed:"+true);
            }
            else
            {
                Console.WriteLine("Failed: "+false);
            }
            //////////////////////////part6///////////////////

            if (StudentAge >= 18)
            {
                Console.WriteLine("Adult :"+true);
            }
            else
            {
                Console.WriteLine("Not Adult");
            }

        }
    }
}
