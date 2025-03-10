using System;
using System.Collections.Generic;
using System.Diagnostics;
using DungeonExplorer;

namespace EasyDungeon
{
    /// <summary>
    /// Represents a player in the game, including their health, name, and inventory.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The player's name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The player's health.
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// A list as the player's inventory, which holds items as strings.
        /// </summary>
        private List<string> _inventory = new List<string>();

        /// <summary>
        /// An instance of the <see cref="Testing"/> class used for validating player's health.
        /// </summary>
        private Testing _tester = new Testing();

        /// <summary>
        /// Initialises a new instance of the <see cref="Player"/> class with a name and health.
        /// </summary>
        /// <param name="playerName">The name of the player.</param>
        /// <param name="health">The initial health of the player.</param>
        public Player(string playerName, int health) 
        {
            Name = playerName;
            Health = health;
        }

        /// <summary>
        /// Decreases the player's health by a specified damage amount.
        /// </summary>
        /// <param name="damage">The amount of damage to reduce from the player's health.</param>
        public void LoseHealth(int damage)
        {
            Health = Health - damage; // Decreases the health by the damage amount
            //_tester.TestHealth(Health); // Validate health state
            Console.WriteLine($"Your current health is now {Health}."); // Displays the updated health
        }

        /// <summary>
        /// Picks up an item and adds it to the player's inventory.
        /// It may also affect the player's health if the item is special.
        /// </summary>
        /// <param name="item">The item to pick up.</param>
        public void PickUpItem(string item)
        {
            // Check if the item is a health potion
            if (item == "health potion")
            {
                Health = Health + 30; // Increases the health by 30
                Console.WriteLine($"Your health increased by 30 HP. You now have {Health} HP.");
            }
            // Check if the item is a poisonous flower
            else if (item == "poisonous flower")
            {
                // Decrease health if picked up
                Health = Health - 10; // Decreases health by 10
                //_tester.TestHealth(Health); // Validate health state
                Console.WriteLine($"Oh no! The poisonous flower damaged you for 10 HP. You now have {Health} HP.");
            }

            // Add any other item to the inventory
            else _inventory.Add(item);
        }

        /// <summary>
        /// Gets the contents of the player's inventory as a string.
        /// </summary>
        /// <returns>A string representing the contents of the inventory.</returns>
        public string GetInventoryContents()
        {
            // Return a formatted string of items, or a message if the inventory is empty
            return _inventory.Count > 0 ? string.Join(", ", _inventory) : "Inventory empty.";
        }
    }
}
