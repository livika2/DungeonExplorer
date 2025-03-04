using System;
using EasyDungeon;

namespace Dungeon
{
    internal class Monster
    {
        public string Name { get; private set; }
        public int MonsterHealth { get; private set; }
        public int Damage { get; private set; }

        public Monster(string name, int monsterHealth, int damage) 
        {
            // Assigning values to properties
            Name = name;
            MonsterHealth = monsterHealth;
            Damage = damage;
        }

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
            player.PickUpItem("half of a key");
        }
    }
}