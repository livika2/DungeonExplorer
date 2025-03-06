using System;
using EasyDungeon;

namespace Dungeon
{
    /// <summary>
    /// Represents a monster in the dungeon with health and damage properties.
    /// </summary>
    internal class Monster
    {
        /// <summary>
        /// Gets the name of the monster.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the monster's current health.
        /// </summary>
        public int MonsterHealth { get; private set; }

        /// <summary>
        /// Gets the damage that the monster inflicts on the player.
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="Monster"/> class.
        /// </summary>
        /// <param name="name">The name of the monster.</param>
        /// <param name="monsterHealth">The initial health of the monster.</param>
        /// <param name="damage">The damage the monster inflicts when fighting.</param>
        public Monster(string name, int monsterHealth, int damage) 
        {
            // Assigning values to the monster's properties
            Name = name;
            MonsterHealth = monsterHealth;
            Damage = damage;
        }

        /// <summary>
        /// Engages the player in combat with the monster.
        /// The player loses health equal to the monster's damage.
        /// The monster is considered defeated after the fight.
        /// </summary>
        /// <param name="player">The player who is fighting the monster.</param>
        public void Fight(Player player)
        {
            // Informing the player about the fight outcome
            Console.WriteLine($"You have managed to win the fight with the {Name} but you lost {Damage} health.");

            // Deducting health from player
            player.LoseHealth(Damage);

            // The monster is defeated, it's health could be set to zero if tracking defeated monsters needed
            // MonsterHealth = 0;

            // Rewarding the player with an item
            Console.WriteLine("You have received half of a key.");
            Console.WriteLine("");
            player.PickUpItem("half of a key"); // Adding "half of a key" to the player's inventory
        }
    }
}