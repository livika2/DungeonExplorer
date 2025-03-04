using Dungeon;

namespace EasyDungeon
{
    internal class Room
    {
        // The description of the room
        public string Description { get; private set; }

        // The item present in the room
        public string Item { get; private set; }

        // The monster present in the room, if any
        public Monster Monster { get; private set; }

        // Boolean flag to track if the monster is hidden or not
        private bool isMonsterHidden = true;

        // Constructor to initialise the room with a description, item and maybe monster
        public Room(string description, string item, Monster monster = null)
        {
            Description = description;
            Item = item;
            Monster = monster;
        }

        // Returns the name of the item in the room, or "no items" if none exists
        public string Items()
        {
            return string.IsNullOrEmpty(Item) ? "no items" : Item;
        }

        // Returns the room's description
        public string GetDescription()
        {
            return Description;
        }

        // Removes the item from the room
        public void RemoveItem()
        {
            Item = ""; // Clears the item in the room
        }

        // Checks if a monster exists in the room and if it's still alive 
        public bool IsMonster()
        {
            return Monster != null && Monster.MonsterHealth > 0;
        }

        // Removes the monster from the room
        public void RemoveMonster()
        {
            Monster = null; // Sets the monster to null, removing it
        }

        // Checks if a monster exists in the room and is hidden
        public bool IsMonsterVisible()
        {
            return Monster != null && isMonsterHidden;
        }

        // Hides the monster in the room
        public void HideMonster()
        {
            isMonsterHidden = false;
        }

        // Resets the monster's visibility to hidden 
        public void ResetMonster()
        { 
            isMonsterHidden = true; // Resets the visibility flag to true
        }
    }
}
