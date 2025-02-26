using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDungeon
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string playerName, int health) 
        {
            Name = playerName;
            Health = health;
        }

        public void LoseHealth(int damage)
        {
            Health = Health - damage;
            Console.WriteLine($"Your current health is now {Health}.");
        }

        public void PickUpItem(string item)
        {
            if (item == "health potion")
            {
                Health = Health + 30;
                Console.WriteLine($"Your health increased by 30 HP. You now have {Health} HP.");
            }
            else if (item == "poisonous flower")
            {
                Health = Health - 10;
                Console.WriteLine($"Oh no! The poisonous flower damaged you for 10 HP. You now have {Health} HP.");
            }
            else inventory.Add(item);
        }

        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Inventory empty.";
        }
    }
}
