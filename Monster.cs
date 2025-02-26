using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyDungeon;

namespace Dice
{
    internal class Monster
    {
        public string Name { get; private set; }
        public int MonsterHealth {  get; private set; }
        public int Damage { get; private set; }

        public Monster(string name, int monsterhealth, int damage) 
        {
            Name = name;
            MonsterHealth = monsterhealth;
            Damage = damage;
        }

        public void Fight(Player player)
        {
            Console.WriteLine($"You have managed to win the fight with the {Name} but you lost {Damage} health.");
            player.LoseHealth(Damage);
            // MonsterHealth = 0;
            Console.WriteLine("You have received half of a key.");
            Console.WriteLine("");
            player.PickUpItem("half of a key");
        }
    }
}