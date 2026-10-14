using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_6
{
    internal interface ICollectible
    {
        void Collect();
    }

    class HealthPotion : ICollectible
    {
        public string PotionName { get; set; }

        public HealthPotion(string potionName)
        {
            PotionName = potionName;
        }

        public void Collect()
        {
            Console.WriteLine("Health Potion collected!");
        }

        public void Use(GameCharacter character, string amountText)
        {
            try
            {
                int amount = int.Parse(amountText);

                character.Heal(amount);
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Invalid input! Please enter a number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Invalid input! Please enter a number.");
            }
        }
    }
}
