using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Person
    {
        public string Name { get; set; }

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
        }
    }

    class Employee : Person
    {
        public double Salary { get; set; }

        public Employee(string name, int age, double salary): base(name, age)
        {
            Salary = salary;
        }

        public void Work()
        {
            Console.WriteLine(Name + " is working.");
        }
    }

    class Program
    {
        static void Main()
        {
            Employee e1 = new Employee("Sara", 22, 800);

            e1.ShowInfo();
            e1.Work();
        }
    }

}
