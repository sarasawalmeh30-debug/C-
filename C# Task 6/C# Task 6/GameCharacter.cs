using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_6
{
    abstract class GameCharacter
    {
        private string _name;
        private int _health;

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        protected int Health
        {
            get { return _health; }
            set
            {
                if (value < 0)
                    _health = 0;
                else if (value > 100)
                    _health = 100;
                else
                    _health = value;
            }
        }

        public GameCharacter(string calledname, int calledHealth)
        {
            Name = calledname;
            Health = calledHealth;
        }

        public abstract void UseSpecialAbility();

        public virtual void TakeDamage(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid damage!");
                return;
            }

            Health -= amount;

            Console.WriteLine(Name + " takes " + amount + " damage.");
            Console.WriteLine(Name + "'s health: " + Health);
        }

        public void Heal()
        {
            Health += 10;

            Console.WriteLine();
            Console.WriteLine(Name + " heals 10 points.");
            Console.WriteLine(Name + "'s health: " + Health);
        }

        public void Heal(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Healing amount cannot be negative.");
                return;
            }

            Health += amount;

            Console.WriteLine();
            Console.WriteLine(Name + " heals " + amount + " points.");
            Console.WriteLine(Name + "'s health: " + Health);
        }
    }


}
