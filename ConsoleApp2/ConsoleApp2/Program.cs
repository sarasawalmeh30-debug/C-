using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int x=Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= x; i++) {
                if (i % 2 == 0) {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
