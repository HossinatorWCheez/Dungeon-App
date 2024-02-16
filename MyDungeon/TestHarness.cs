﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using WMPLib;

namespace MyDungeon
{
    internal class TestHarness
    {
        static void Main(string[] args)
        {
            WindowsMediaPlayer myplayer = new WindowsMediaPlayer();
            myplayer.URL = "C:\\Zelda.mp4"; //Credit: https://www.youtube.com/watch?v=ecnb7qOl4Pc&list=RDcGufy1PAeTU&index=4  *OST Remastered*
            myplayer.controls.play();

            #region Title / Introduction
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@"Your Journey Begins....\n
                                             _                                   
                                            | |                                   
                                          __| |_   _ _ __   __ _  ___  ___  _ __  
                                         / _` | | | | '_ \ / _` |/ _ \/ _ \| '_ \ 
                                        | (_| | |_| | | | | (_| |  __/ (_) | | | |
                                         \__,_|\__,_|_| |_|\__, |\___|\___/|_| |_|
                                                            __/ |                 
                                                           |___/ https://ascii.co.uk/art/helmet
                                   _________________________________________________________
                                 /|     -_-                                             _-  |\
                                / |_-_- _                                         -_- _-   -| \   
                                  |                            _-  _--                      | 
                                  |                            ,                            |
                                  |      .-'````````'.        '(`        .-'```````'-.      |
                                  |    .` |           `.      `)'      .` |           `.    |          
                                  |   /   |   ()        \      U      /   |    ()       \   |
                                  |  |    |    ;         | o   T   o |    |    ;         |  |
                                  |  |    |     ;        |  .  |  .  |    |    ;         |  |
                                  |  |    |     ;        |   . | .   |    |    ;         |  |
                                  |  |    |     ;        |    .|.    |    |    ;         |  |
                                  |  |    |____;_________|     |     |    |____;_________|  |  
                                  |  |   /  __ ;   -     |     !     |   /     `'() _ -  |  |
                                  |  |  / __  ()        -|        -  |  /  __--      -   |  |
                                  |  | /        __-- _   |   _- _ -  | /        __--_    |  |
                                  |__|/__________________|___________|/__________________|__|
                                 /             -__-                 -_-__-     _ -       _-_ \
                                /   -_- _ -             _- _---                       -_-  -_ \"); Console.ResetColor();
            #endregion

            #region Player Setup

            //=============================== PLAYER CREATION & RACE SELECTION ===============================\\

            Console.Write("\nCreate a name for your character: ");
            string userName = Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@$"Welcome to the dungeon {userName}!\n
       ___________________
      /.-------+-+-------.\
     //        :|:     :::\\
    //         :|:       ::\\
   //          :|:       :::\\
  //           :|:       ::::\\
 //            :|:         :::\\
//             :|:          :::\\
||     _______/:|:\_______   ::||
||    /.-----.\:|:/.-----.\ :.:||
||   ((       ))|((       ))  :||
||    \\_    //:|:\\    _//   :||
||:     \\  (( :|: ))  //     :||
||::     \\  \\:|://  //     ::||
||::      \\  \\_//  //     :::||
||::       \\  `-'  //     ::::||
||::        ))     ((     :::::||
||::       //       \\   ::::::|| 
\\::      //         \\ ::::::://
 \\______//           \\______// 
  `------'             `------'https://ascii.co.uk/art/helmet"); Console.ResetColor();
            Console.WriteLine("Select a Race for your character: ");
            
            List<Race> races = Enum.GetValues<Race>().ToList();
            int index = 1;
            foreach (Race item in races)
            {
                Console.WriteLine($"{index++}) {item}");
            }
            Console.WriteLine();

            int.TryParse(Console.ReadLine(), out int choice);
            Race userRace = races[choice - 1];
            Console.Clear();

            Console.WriteLine($"Selected Race: {userRace}");

            List<Weapon> starterList = new List<Weapon>
            {
            new Weapon("Assassin's Blade", 3, 8, 10, false, WeaponType.Dagger, 0),
            new Weapon("Viking Sword", 2, 10, 3, false, WeaponType.Sword,0 ),
            new Weapon("Battle Axe", 3, 8, 10, false, WeaponType.Axe, 0),

            };
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"\nChoose a weapon for your player:
                           ___
                          ( ((
                           ) ))
  .::.                    / /(
 'M .-;-.-.-.-.-.-.-.-.-/| ((::::::::::::::::::::::::::::::::::::::::::::::.._
(J ( ( ( ( ( ( ( ( ( ( ( |  )) -=== https://ascii.co.uk/art/helmet ===-      _.>
 `P `-;-`-`-`-`-`-`-`-`-\| ((::::::::::::::::::::::::::::::::::::::::::::::''
  `::'                    \ \(
                           ) ))
                          (_(("); Console.ResetColor();
            for (int i = 0; i < starterList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {starterList[i].ToString()}\n");
            }

            int userInput;
            bool validInput = false;

            do
            {
                Console.Write("Enter the number corresponding to your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out userInput) && userInput >= 1 && userInput <= starterList.Count)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

            } while (!validInput);

            Weapon selectedWeapon = starterList[userInput - 1];
            Console.Clear();
            Console.WriteLine($"You've chosen the {selectedWeapon.Name}!\nYour Character Below!!!");

            Player player = new Player(userName, 60, 10, 70, userRace, selectedWeapon);
            Console.WriteLine(player);
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Main Game Loop

            myplayer.controls.stop();
            myplayer.URL = "C:\\Battle Music.mp4";
            myplayer.controls.play();
            bool exit = false;//if true, quit the whole game
            do
            {
                //Generate a monster
                Monster monster = Monster.GetMonster();
                //Generate a room
                string room = GetRoom();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"You enter a new room...");
                Console.ResetColor();
                Console.WriteLine(room);
                Console.WriteLine("\nIn this room...");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(monster.Name);
                Console.ResetColor();
                #region Encounter loop
                bool newRoom = false;
                do
                {
                    #region MENU
                    //Prompt the user
                    Console.Write("\nPlease choose an action:\n" +
                                        "A) Attack\n" +
                                        "R) Run away\n" +
                                        "P) Player Info\n" +
                                        "M) Monster Info\n" +
                                        "S) Shop\n" +
                                        "X) Exit\n");

                    string userChoice = Console.ReadKey(true).Key.ToString();
                    Console.Clear();

                    switch (userChoice)
                    {
                        case "A":
                            Console.WriteLine("ATTACK!");
                            bool deadMonster = Combat.DoBattle(player, monster);
                            newRoom = deadMonster;
                            break;

                        case "R":
                            Console.WriteLine("Run away!!!");
                            Console.WriteLine($"{monster.Name} attacks you as you run like a coward...");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            newRoom = true;
                            break;

                        case "P":
                            Console.WriteLine("Behold, a gamer...");
                            Console.WriteLine($"{player}");
                            break;

                        case "M":
                            //Console.WriteLine("Monster Stuff");
                            //show monster info
                            Console.WriteLine(monster);
                            break;
                        case "S":
                            #region Weapon Shop
                            List<Weapon> weaponsList = new List<Weapon>
                            {
                                new Weapon("Rapier", 6, 12, 10, false, WeaponType.Sword,20),
                                new Weapon("Claymore", 9, 12, 5, true, WeaponType.Sword, 24),
                                new Weapon("Knights Sword", 10, 15, 7, true, WeaponType.Sword, 28),
                                new Weapon("Dane Axe", 12, 15, 10, true, WeaponType.Axe, 32),
                                new Weapon("Halberd Axe", 9, 19, 10, true, WeaponType.Axe, 41),
                                new Weapon("War Hammer", 8, 17, 7, true, WeaponType.Hammer, 34),
                                new Weapon("Lucerne Hammer", 10, 19, 10, true, WeaponType.Hammer, 39),
                                new Weapon("Bow", 2, 5, 3, true, WeaponType.Ranged, 9),
                                new Weapon("Crossbow", 5, 10, 5, true, WeaponType.Ranged, 18),
                                new Weapon("Musket", 10, 20, 15, true, WeaponType.Ranged, 37),
                                new Weapon("Geralt's Silver Sword", 30, 40, 20, false, WeaponType.Legendary,69),
                                new Weapon("Gravity Hammer", 49, 50, 0, true, WeaponType.Legendary,78),
                            };
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(@"Welcome to the Shop!!!
 __________________________________________________________________________
|: : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : : |
| : : : : : : : : : : : : : : : :_________________________: : : : : : : : :|
|: : : : : : : : : : : : : : : _)                         (_ : : : : : : : |
| : : : : : : : : : : : : : : )_ :    -Dungeon Shop-    :  _( : : : : : : :|
|: : Elevator  : : : :__________)_________________________(__________  : : |
| _____________ : _ :/ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ\: _ :|
||  _________  | /_\ '.Z.'.Z.'.Z.'.Z.'.Z.'.Z.'.Z.'.Z.'.Z.'.Z.'.Z.'.Z.' /_\ |
|| |    |    | |:=|=: |Swords * Hammers  _________ Axes * Legendary | :=|=:|
|| |    |    | | : : :|   ______    _  .'         '.  _    ______   |: : : |
|| |    |    | |======| .' ,|,  '. /_\ |           | /_\ .'  ,|, '. |======|
|| |    |    |:|Lounge| | ;;;;;  | =|= |           | =|= |  ;;;;; | |Death!|
|| |    |    | |<---  | |_';;;'_n|     |  n______  |     |$_';;;'_| |  --->|
|| |    |    | |      | |_|-;-|__|     |-|_______|-|     |__|-;-|_| |      |
|| |    |    | |      | |________|     |           |     |________| |      |
|| |    |    | |      |                |           |                |      |
||_|____|____|_|______|________________|           |________________|______|");
                            Console.ResetColor();
                            for (int i = 0; i < weaponsList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {weaponsList[i].ToString()}\n");
                            }

                            int userPurchase;
                            bool validPurchase = false;

                            do
                            {
                                Console.Write("Enter the number corresponding to your choice: ");
                                string input = Console.ReadLine();

                                if (int.TryParse(input, out userPurchase) && userPurchase >= 1 && userPurchase <= weaponsList.Count)
                                {
                                    validPurchase = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number.");
                                }

                            } while (!validPurchase);

                            Weapon purchasedWeapon = weaponsList[userPurchase - 1];
                            if (player.Score >= purchasedWeapon.Cost)
                            {
                                player.Score -= purchasedWeapon.Cost;
                                player.EquippedWeapon = purchasedWeapon;
                                Console.WriteLine($"You've chosen the {purchasedWeapon.Name}!");
                            }
                            else
                            {
                                Console.WriteLine("You do not have enough score to afford this weapon brokie");
                            }
                            break;
                        #endregion
                        case "X":
                            myplayer.controls.stop();
                            myplayer.URL = "C:\\Game Over Man!.mp3";
                            myplayer.controls.play();
                            Console.WriteLine("No one likes a quitter.");
                            exit = true;
                            break;

                        default:
                            #region Invalid Input
                            Console.WriteLine("You have made a grave error. Wanna try again?\a");
                            #endregion
                            break;
                    }

                    #endregion

                    #region Check Player Life
                    if (player.Life <= 0)
                    {
                        myplayer.controls.stop();
                        myplayer.URL = "C:\\Death.mp4";
                        myplayer.controls.play();
                        Console.WriteLine("Dude... You died!");
                        exit = true; //End the game
                    }
                    #endregion 
                } while (!newRoom && !exit);//While both newRoom and exit is not true keep looping
                #endregion
            } while (!exit);//While exit is not true keep looping

            #endregion

            #region Outro
            //Final Score, end the story
            Console.WriteLine($"You defeated {player.Score} monster(s).");
            //Main(args); restart the app?
            Console.ReadKey(true);
            #endregion
        }

        private static string GetRoom()
        {
            string[] rooms =
            {
                "Inside you a bleak room made of stone, you notice a drop in temperature. The walls are lined with bloodied hand prints and various other bloody streaks.", //0
                "Inside you notice a comfortable fireplace that is lit. There is a dinner table bloodied with various puddles of blood and streak marks. The unfinished meals remain, moldy and malodorous.", //1
                "Inside you see a dimly lit room filled with cobbwebs, you see figures caught and wrapped within the webbing. You can't make out the details but the figures are human sized.", //2
                "Inside the room appears empty with nothing but chains and shackles dangling freely and anchored to the wall.", //3
                "Inside you see tons of rusted and warped weapons and a massive anvil, as you get close the weapons forge ignites", //4
            };
            Random rand = new Random();

            int index = rand.Next(rooms.Length);

            string room = rooms[index];

            return room;

            //refactoring -> rewriting code
            //return rooms[new Random().Next(rooms.Length)];
        }
    } 
}