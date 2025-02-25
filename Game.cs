using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EasyDungeon;

namespace Dice
{
    internal class Game
    {   
        private Player player;
        private List<Room> rooms = new List<Room>();
        private int currentRoomIndex = 0;
        public Game()
        {
            player = new Player("defaultName", 100);

        }

        private string GetPlayerName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please input your name: ");
                    string playerName = Console.ReadLine();
                    if (string.IsNullOrEmpty(playerName))
                    {
                        throw new FormatException();
                    }
                    if (!(playerName.All(char.IsLetter)))
                    {
                        throw new FormatException();
                    }
                    return playerName;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The name should only contain letters. Please try again.");
                }

                catch (Exception)
                {
                    Console.WriteLine("An unexpected error occured. Please try again. ");
                }
            }
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Dungeon Explorer!");
            string playerName = GetPlayerName();
            int Health = 100;
            player = new Player(playerName, Health);
            Monster monster1 = new Monster("minion", 100, 20);
            Monster monster2 = new Monster("fire flower", 100, 60); 
            rooms.Add(new Room("a very dark and cold room.", "health potion"));
            rooms.Add(new Room("a huge room filled with statues.", "torch", monster1));
            rooms.Add(new Room("a well lit but eerie room.", "iron sword", monster2));
            rooms.Add(new Room("a small room with a mountain painting.", ""));
            bool playing = true;
            while (playing)
            {
                Room currentRoom = rooms[currentRoomIndex];
                if(currentRoom.IsMonster())
                {   
                    
                    Console.WriteLine($"You have encountered a {currentRoom.Monster.Name}.");
                    Console.WriteLine("Are you ready for the fight? (yes/no)");
                    while (true) 
                    {
                            string choice = Console.ReadLine().ToLower();
                            if (choice == "yes")
                            {
                                Monster monster = currentRoom.Monster;
                                int monsterHP = monster.MonsterHealth;
                                if (monsterHP != 0)
                                {
                                    monster.Fight(player);
                                break;
                                }
                                
                            }
                            else if (choice == "no") 
                            {   
                                Console.WriteLine("You have decided not to fight.");
                                currentRoom.RemoveMonster();
                                break;

                            }
                            else
                            {
                            Console.WriteLine("Unknown command, please try again. (yes/no)");
                            }
                    }
                }
                Console.WriteLine("Please choose your next move. (stats, description, pickup, nextRoom, quit)");
                string nextMove = Console.ReadLine().ToLower();
                if (nextMove == "pickup")
                {
                    if (!string.IsNullOrEmpty(currentRoom.Item))
                    {
                        player.PickUpItem(currentRoom.Item);
                        Console.WriteLine($"You picked up: {currentRoom.Item}");
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
                    Console.WriteLine($"The player {player.Name} has {player.Health} HP");
                    Console.WriteLine($"Inventory: {player.InventoryContents()}");
                    Console.WriteLine("");
                }
                else if (nextMove == "description")
                {
                    Console.WriteLine($"You are in {currentRoom.GetDescription()}");
                    Console.WriteLine($"This room has {currentRoom.Items()} in it.");
                    Console.WriteLine("");
                }
                else if (nextMove == "nextroom")
                {
                    if (currentRoomIndex < rooms.Count - 1)
                    {
                        currentRoomIndex++;
                        Console.WriteLine("You entered the next room.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("You have arrived at the dungeon's exit door.");
                    }
                }
                else if (nextMove == "quit")
                {
                    playing = false;
                    Console.WriteLine("You have decided to quit.");
                }
                else
                {
                    Console.WriteLine("Invalid command, please try again.");
                    Console.WriteLine("");
                }      
            }
        }
    }
}