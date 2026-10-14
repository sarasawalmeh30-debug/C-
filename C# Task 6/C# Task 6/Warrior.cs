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

            int reducedDamage = Math.Max(0, amount - 2);

            base.TakeDamage(reducedDamage);
        }
    }
}
