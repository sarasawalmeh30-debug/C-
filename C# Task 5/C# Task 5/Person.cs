using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_5
{
    internal class Person
    {
        public string Name {  get; set; }
        private int _internalCode; ///cannot be accessed outside Person becous is private Access Modifiers 
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
            }
        }
        public Person(string name, int age,string schoolname)
        {
            Name = name;
            Age = age;
            SchoolName = schoolname;
        }
        protected string SchoolName {  get; set; }
        public void DisplayInfo()
        {
            Console.WriteLine("Name :" + Name);
            Console.WriteLine("Age :" + age);
        }
    }
}
