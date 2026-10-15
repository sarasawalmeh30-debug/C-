using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== ADVENTURE GAME =====");
            Console.WriteLine();

            Warrior warrior = new Warrior("Alex", 80);
            Wizard wizard = new Wizard("Luna", 70);

            //GameCharacter[] characters = { warrior, wizard };
             List<GameCharacter> characters = new List<GameCharacter>() { warrior, wizard };

            foreach (GameCharacter character in characters)
            {

                character.UseSpecialAbility();
            }
            warrior.TakeDamage(10);
            wizard.TakeDamage(10);
            HealthPotion potion = new HealthPotion("Health Potion");

            potion.Collect();
            potion.Use(wizard, "15");
            potion.Use(wizard, "abc");

        }
    }
}
