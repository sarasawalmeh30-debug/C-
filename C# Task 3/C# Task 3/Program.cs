using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /////////////////////part1//////////////////////////////////
            Random num = new Random();
            int count = 1;
            int randomnum = num.Next(50, 76);
            Console.WriteLine("Guess a number between 50 and 75: ");
            double guess = Convert.ToDouble(Console.ReadLine());
            while (randomnum != guess)
            {
                count++;

                if (guess > randomnum)
                {
                    Console.WriteLine("Try a lower number.");
                }
                else if (guess < randomnum)
                {
                    Console.WriteLine("Try a higher number.");
                }
                else
                {
                    Console.WriteLine("Congratulations!");
                }
                guess = Convert.ToDouble(Console.ReadLine());

            }
            if (count == 1)
            {
                Console.WriteLine("Attempts :" + count);
                Console.WriteLine("Points " + 10);
            }
            else if (count == 2)
            {
                Console.WriteLine("Attempts :" + count);
                Console.WriteLine("Points " + 7);
            }
            else if (count == 3)
            {
                Console.WriteLine("Attempts :" + count);
                Console.WriteLine("Points " + 5);
            }
            else
            {
                Console.WriteLine("Attempts :" + count);
                Console.WriteLine("Points " + 0);
            }
            ////////////////////////////////////////////////////////////////////

            int[] StudentGrades = { 85, 92, 68, 75, 90 };
            foreach (var item in StudentGrades)
            {
                Console.WriteLine("grades : " + item);
            }


            ////////////////////////////////////////////////////////////////////

            string[] StudentsArray ={"Ahmad","Sara","Omar","Lina","Yazan"};



            int choice;

            do
            {
                Console.WriteLine("===== School System =====");
                Console.WriteLine("1. Display Students");
                Console.WriteLine("2. Search for Student");
                Console.WriteLine("3. Check Student Result");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            for (int i = 0; i < StudentsArray.Length; i++)
                            {
                                Console.WriteLine("Name : " + StudentsArray[i]);
                            }
                        }
                        break;

                    case 2:
                        {
                            int i = 0;
                            Console.WriteLine("Enter Your Name :");
                            string name = Console.ReadLine();
                            bool namechoose = false;
                            while (i < StudentsArray.Length)
                            {
                                if (StudentsArray[i] == name)
                                {
                                    namechoose = true;
                                }
                                i++;


                            }
                            if (namechoose == true)
                            {
                                Console.WriteLine("Student Found!");
                            }
                            else
                            {
                                Console.WriteLine("Student Not Found!");
                            }
                        }
                        break;

                    case 3:
                        {
                            Console.WriteLine("Enter Your Gread :");
                            double Gread = Convert.ToDouble(Console.ReadLine());
                            if (Gread >= 90 && Gread <= 100)
                            {
                                Console.WriteLine("Excellent");
                            }
                            else if (Gread >= 80 && Gread < 90)
                            {
                                Console.WriteLine("Very Good");
                            }
                            else if (Gread >= 70 && Gread < 80)
                            {
                                Console.WriteLine("Good");
                            }
                            else if (Gread >= 60 && Gread < 70)
                            {
                                Console.WriteLine("Pass");
                            }
                            else if (Gread >= 0 && Gread < 60)
                            {
                                Console.WriteLine("Fail");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Grade");
                            }
                        }
                        break;

                    case 4:
                        {
                            Console.WriteLine("Goodbye!");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 4);

        }

    }
}
