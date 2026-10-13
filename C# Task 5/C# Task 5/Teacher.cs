using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_5
{
    internal class Teacher:Person
    {
        public string Subject {  get; set; }
    public Teacher(string n,int a,string s,string subject) : base(n, a, s)
        {
            Subject = subject;
        }
        public void DisplayTeacherInfo()
        {
            DisplayInfo();
            Console.WriteLine("subject :" + Subject);
        }
    }
}
