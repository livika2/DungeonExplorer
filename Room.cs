using Dungeon;

namespace EasyDungeon
{
    /// <summary>
    /// Represents a room in the dungeon with a description, item and monster.
    /// </summary>
    internal class Room
    {
        /// <summary>
        /// Gets the description of the room.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the item present in the room.
        /// </summary>
        public string Item { get; private set; }

        /// <summary>
        /// Gets the monster present in the room, if any.
        /// </summary>
        public Monster Monster { get; private set; }

        /// <summary>
        /// A flag to track if the monster is hidden or not.
        /// </summary>
        private bool isMonsterHidden = true;

        /// <summary>
        /// Initialises a new instance of <see cref="Room"/> class.
        /// </summary>
        /// <param name="description">The description of the room.</param>
        /// <param name="item">The item in the room.</param>
        /// <param name="monster">The monster in the room, if any.</param>
        public Room(string description, string item, Monster monster = null)
        {
            Description = description;
            Item = item;
            Monster = monster;
        }

        /// <summary>
        /// Returns the item in the room, or "no items" if none exists.
        /// </summary>
        /// <returns>A string representing the item in the room, or "no items" if none.</returns>
        public string Items()
        {
            return string.IsNullOrEmpty(Item) ? "no items" : Item;
        }

        /// <summary>
        /// Returns the room's description.
        /// </summary>
        /// <returns>The description of the room.</returns>
        public string GetDescription()
        {
            return Description;
        }

        /// <summary>
        /// Removes the item from the room.
        /// </summary>
        public void RemoveItem()
        {
            Item = ""; // Clears the item in the room
        }

        /// <summary>
        /// Checks if a monster exists in the room and if it's still alive.
        /// </summary>
        /// <returns>True if a monster exists and is alive, otherwise false.</returns>
        public bool IsMonster()
        {
            return Monster != null && Monster.MonsterHealth > 0;
        }

        /// <summary>
        /// Removes the monster from the room by setting it to null.
        /// </summary>
        public void RemoveMonster()
        {
            Monster = null; // Sets the monster to null, removing it
        }

        /// <summary>
        /// Checks if the monster is visible (exists and hidden).
        /// </summary>
        /// <returns>True if the monster is visible, otherwise false.</returns>
        public bool IsMonsterVisible()
        {
            return Monster != null && isMonsterHidden;
        }

        /// <summary>
        /// Hides the monster in the room.
        /// </summary>
        public void HideMonster()
        {
            isMonsterHidden = false;
        }

        /// <summary>
        /// Resets the monster's visibility to hidden, making it appear again.
        /// </summary>
        public void ResetMonster()
        { 
            isMonsterHidden = true; // Resets the visibility flag to true
        }
    }
}
