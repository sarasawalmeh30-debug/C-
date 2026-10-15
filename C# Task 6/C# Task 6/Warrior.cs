using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_6
{
    internal class Warrior : GameCharacter
    {
        public Warrior(string cc, int h) : base(cc, h)
        {
        }

        public override void UseSpecialAbility()
        {
            Console.WriteLine("The Warrior attacks with a sword!");
        }

        public override void TakeDamage(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid damage!");
                return;
            }

            Health = Health - (amount - 2);
            Console.WriteLine(Name + " takes " + amount + " damage.");
            Console.WriteLine(Name + "'s health: " + Health);
        }
    }
}
