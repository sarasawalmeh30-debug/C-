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

            List<GameCharacter> characters =
                new List<GameCharacter>();

            characters.Add(warrior);
            characters.Add(wizard);

            foreach (GameCharacter character in characters)
            {
                Console.WriteLine(
                    character is Warrior
                    ? "Warrior " + character.Name + " enters the game!"
                    : "Wizard " + character.Name + " enters the game!");

                character.UseSpecialAbility();
                character.TakeDamage(10);

                if (character is Warrior)
                {
                    character.Heal();
                    character.Heal(15);
                }

                Console.WriteLine();
            }

            HealthPotion potion =
                new HealthPotion("Health Potion");

            potion.Collect();

            potion.Use(wizard, "15");
            potion.Use(wizard, "abc");
        
    }
    }
}
