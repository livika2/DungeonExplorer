using System;
using System.Collections.Generic;

namespace EasyDungeon
{
    public class Player
    {
        // The player's name
        public string Name { get; private set; }

        // The player's health
        public int Health { get; private set; }

        // A list as the player's inventory, which holds items as strings
        private List<string> inventory = new List<string>();

        // Constructor that sets the player's name and health
        public Player(string playerName, int health) 
        {
            Name = playerName;
            Health = health;
        }

        public void LoseHealth(int damage)
        {
            Health = Health - damage; // Decreases the health by the damage amount
            Console.WriteLine($"Your current health is now {Health}."); // Displays the updated health
        }

        // Method to handle picking up items in the game
        public void PickUpItem(string item)
        {
            // Check if the item is a health potion
            if (item == "health potion")
            {
                Health = Health + 30;
                Console.WriteLine($"Your health increased by 30 HP. You now have {Health} HP.");
            }
            // Check if the item is a poisonous flower
            else if (item == "poisonous flower")
            {
                // Decrease health if picked up
                Health = Health - 10;
                Console.WriteLine($"Oh no! The poisonous flower damaged you for 10 HP. You now have {Health} HP.");
            }

            // Add any other item to the inventory
            else inventory.Add(item);
        }

        // Method to get a string representation of the player's inventory contents
        public string InventoryContents()
        {
            // Return a formatted string of items, or a message if the inventory is empty
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Inventory empty.";
        }
    }
}
