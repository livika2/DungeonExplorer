using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dice;

namespace EasyDungeon
{
    internal class Room
    {
        public string Description { get; private set; }
        public string Item { get; private set; }
        public Monster Monster { get; private set; }

        private bool isMonsterHidden = true;

        public Room(string description, string item, Monster monster = null)
        {
            Description = description;
            Item = item;
            Monster = monster;
        }

        public string Items()
        {
            return string.IsNullOrEmpty(Item) ? "no items" : Item;
        }
        public string GetDescription()
        {
            return Description;
        }

        public void RemoveItem()
        {
            Item = "";
        }

        public bool IsMonster()
        {
            return Monster != null && Monster.MonsterHealth > 0;
        }
        public void RemoveMonster()
        {
            Monster = null;
        }

        public bool IsMonsterVisible()
        {
            return Monster != null && isMonsterHidden;
        }

        public void HideMonster()
        {
            isMonsterHidden = false;
        }

        public void ResetMonster()
        { 
            isMonsterHidden = true; 
        }
    }
}
