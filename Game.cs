using System;
using System.Collections.Generic;
using System.Linq;
using EasyDungeon;

namespace Dungeon
{
    /// <summary>
    /// Manages the main game logic, including player interactions and room navigation.
    /// </summary>
    internal class Game
    {   
        /// <summary>
        /// Represents the player in the game.
        /// </summary>
        private Player player;

        /// <summary>
        /// List of rooms that will make up the dungeon.
        /// </summary>
        private List<Room> rooms = new List<Room>();

        /// <summary>
        /// Tracks the index of the current room the player is in.
        /// </summary>
        private int currentRoomIndex = 0;

        /// <summary>
        /// Initialises a new instance of the <see cref="Game"/> class with a default player.
        /// </summary>
        public Game()
        {
            // Creates a player with a default name and health
            player = new Player("defaultName", 100);
        }

        /// <summary>
        /// Prompts the player to enter a valid name containing letters only.
        /// </summary>
        /// <returns>A valid player name.</returns>
        private string GetPlayerName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please input your name: ");
                    string playerName = Console.ReadLine();

                    // Check if the name is empty or null
                    if (string.IsNullOrEmpty(playerName))
                    {
                        throw new FormatException();
                    }

                    // Check if the name contains only letters
                    if (!(playerName.All(char.IsLetter)))
                    {
                        throw new FormatException();
                    }
                    return playerName;
                }
                catch (FormatException)
                {   
                    // Inform the player that the name must contain letters only
                    Console.WriteLine("The name should only contain letters. Please try again.");
                }

                catch (Exception)
                {
                    // Catch any unexpected errors
                    Console.WriteLine("An unexpected error occured. Please try again. ");
                }
            }
        }

        /// <summary>
        /// Initialises the game world, including rooms and monsters.
        /// </summary>
        public void Initialise()
        {   
            // Get the player's name and set up their health
            string playerName = GetPlayerName();
            int Health = 100;
            player = new Player(playerName, Health);

            // Create and add monsters to the dungeon rooms
            Monster monster1 = new Monster("stone golem", 100, 20);
            Monster monster2 = new Monster("shadow wraith", 100, 60);

            // Add rooms to the dungeon with descriptions and items or monsters
            rooms.Add(new Room("a very dark and cold room.", "leather armour"));
            rooms.Add(new Room("a huge room filled with statues.", "torch", monster1));
            rooms.Add(new Room("a well lit but eerie room.", "iron sword"));
            rooms.Add(new Room("a small room with a mountain painting.", "", monster2));
            rooms.Add(new Room("a hidden cellar with barrels of strange liquid", "health potion"));
            rooms.Add(new Room("a ruined library with scattered, dust-covered books.", "poisonous flower"));
        }

        /// <summary>
        /// Starts the game loop, handling player choices and interactions.
        /// </summary>
        public void Start()
        {

            Console.WriteLine("Welcome to Dungeon Explorer!");
            Initialise();

            bool playing = true;

            // Main game loop
            while (playing)
            {   
                // Get the current room based on the room index
                Room currentRoom = rooms[currentRoomIndex];

                // Checks if there is still a monster in the room and prompts the player to fight
                if (currentRoom.IsMonsterVisible())
                {   
                    
                    Console.WriteLine($"You have encountered a {currentRoom.Monster.Name}.");
                    Console.WriteLine("Are you ready for the fight? (yes/no)");

                    while (true) 
                    {
                            // Read the player's choice to fight or not
                            string choice = Console.ReadLine().ToLower();

                            if (choice == "yes")
                            {   
                                // Proceed with the fight
                                Monster monster = currentRoom.Monster;
                                int monsterHP = monster.MonsterHealth;
                                if (monsterHP != 0)
                                {
                                    monster.Fight(player);
                                    currentRoom.RemoveMonster();
                                    break;
                                }
                                
                            }
                            else if (choice == "no") 
                            {   
                                // Player decides not to fight
                                Console.WriteLine("You have decided not to fight.");
                                currentRoom.HideMonster();
                                break;

                            }
                            else
                            {
                                // In case of invalid input
                                Console.WriteLine("Unknown command, please try again. (yes/no)");
                            }
                    }
                }

                // Ask the player for their next move
                Console.WriteLine("Please choose your next move. (stats, description, pickup, nextRoom, previousRoom, quit)");
                string nextMove = Console.ReadLine().ToLower();

                if (nextMove == "pickup")
                {   
                    // Pick up an item if available
                    if (!string.IsNullOrEmpty(currentRoom.Item))
                    {
                        Console.WriteLine($"You picked up: {currentRoom.Item}.");
                        player.PickUpItem(currentRoom.Item);
                        Console.WriteLine("");
                        currentRoom.RemoveItem();
                    }
                    else
                    {
                        Console.WriteLine("There are no items to pick up in this room.");
                    }
                }
                else if (nextMove == "stats")
                {
                    // Show the player's stats
                    Console.WriteLine($"The player {player.Name} has {player.Health} HP.");
                    Console.WriteLine($"Inventory: {player.GetInventoryContents()}");
                    Console.WriteLine("");
                }
                else if (nextMove == "description")
                {
                    // Show the room's description and items
                    Console.WriteLine($"You are in {currentRoom.GetDescription()}");
                    Console.WriteLine($"This room has {currentRoom.Items()} in it.");
                    Console.WriteLine("");
                }
                else if (nextMove == "nextroom")
                {   
                    // Move to the next room if possible
                    if (currentRoomIndex < rooms.Count - 1)
                    {
                        currentRoomIndex++;
                        rooms[currentRoomIndex].ResetMonster();
                        Console.WriteLine("You entered the next room.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("You have arrived at the dungeon's exit door.");
                        Console.WriteLine("You cannot go further.");
                        Console.WriteLine("");
                    }
                }
                else if (nextMove == "quit")
                {
                    // Quit the game
                    playing = false;
                    Console.WriteLine("You have decided to quit.");
                }
                else if (nextMove == "previousroom")
                {
                    // Move the previous room if possible
                    if (currentRoomIndex == 0)
                    {
                        Console.WriteLine("You have arrived at the dungeon's entry door.");
                        Console.WriteLine("You cannot go further.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        currentRoomIndex--;
                        rooms[currentRoomIndex].ResetMonster();
                        Console.WriteLine("You entered the previous room.");
                        Console.WriteLine("");
                    }
                }
                else
                {
                    // Handle invalid commands
                    Console.WriteLine("Invalid command, please try again.");
                    Console.WriteLine("");
                }      
            }
        }
    }
}

