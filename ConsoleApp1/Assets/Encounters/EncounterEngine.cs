using ConsoleApp1.Assets.Enemies;
using ConsoleApp1.Assets.Models;
using ConsoleApp1.Assets.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Assets.Encounters
{
    public static class EncounterEngine
    {
        public static void Encounter1()
        {
            Console.WriteLine("Wake");
            Typewriter.Write("........", 200);
            Typewriter.Write("You open your eyes. You feel groggy, and have no bearing of how long you've slept.");
            Typewriter.Write("You look around and see gray cobblestone walls. It's cold and dimly lit.");
            Console.WriteLine("");
            Typewriter.Write("You lay with your back against the wall,");
            Typewriter.Write("turning your head to your left you see a wooden door which is the only way in or out of the room.");
            Typewriter.Write("A lit torch hangs off the wall, blinding you to see any further out of the door.");
            Console.WriteLine("");
            Typewriter.Write("Off your ankle hangs a chain, connected to the cobblestone wall.");

            Typewriter.Write("It appears loose... Try to break free from the wall? [Y]/[n].");
            var input = Console.ReadLine();
            if (input.ToString().ToLower().Equals("y"))
            {
                Typewriter.Write("You turn and grab onto the chain; using the wall as leverage you break yourself free.");
            }
            else
            {
                Typewriter.Write("You are still chained to the wall.");
                Encounter1();
            }
        } 

        public static void Encounter2(Player.Player player)
        {
            Console.Clear();
            Console.WriteLine(AsciiArt.Sword(player));


            Typewriter.Write("You stand and take a great stretch, your body feels weak and your muscles atrophied");
            Typewriter.Write("You have no idea why you are here, but you want to know why, and how to get out safely.");
            Console.WriteLine("");
            Typewriter.Write("As you head out of the room, you see a body lying in the area outside of the door.");
            Typewriter.Write("There is a [Rusty Sword] next to the body.  Pick it up? [Y]/[n]");

            var starterWeapon = new Weapon()
            {
                Name = "Rusty Sword",
                Type = WeaponType.Sword,
                MinDamage = 1,
                MaxDamage = 4,
            };

            var pickUpSwordInput = Console.ReadLine();
            if (pickUpSwordInput.ToString().ToLower().Equals("y"))
            {
                Typewriter.Write($"You equip {starterWeapon.Name}. Damage: ({starterWeapon.MinDamage} - {starterWeapon.MaxDamage})!");
                player.Weapon = starterWeapon;
            }
            else
            {
                Typewriter.Write("You leave the sword alone");
            }
        }

        public static void GenerateSpecialItem(Player.Player player)
        {
            Random r = new Random();
            int specialItemFoundProc = r.Next(0, 10);

            if (specialItemFoundProc < 3)
            {
                SpecialEncounter1(player);

            }
            if (specialItemFoundProc >= 3 && specialItemFoundProc <= 8)
            {
                SpecialEncounter2(player);
            }
        }

        

        public static void GenerateItem(Player.Player player)
        {
            Random r = new Random();
            int randomWeaponProc = r.Next(0, 10);            

            switch (randomWeaponProc)
            {
                case 1:
                case 10:
                case 6:
                    {
                        if (randomWeaponProc == 6 && player.PlayerUpgradePaths.CurrentLuckValue < 1)
                        {
                            Typewriter.Write("You see nothing of interest.");
                            break;
                        }
                        var weapon = new Weapon(player, true);
                        Typewriter.Write($"You found a [{weapon.Name}]   Damage: {weapon.MinDamage} - {weapon.MaxDamage}!");
                        Typewriter.Write($"Do you want to replace your {player.Weapon.Name}? [Y]/[n]");
                        var acceptWeaponInput = Console.ReadLine();
                        if (acceptWeaponInput.ToString().ToLower().Equals("y"))
                        {
                            player.Weapon = weapon;
                        }
                        break;
                    }
                case 2:
                case 12:
                case 4:
                case 14:
                case 7:
                    {
                        if (randomWeaponProc == 7 && player.PlayerUpgradePaths.CurrentLuckValue < 1)
                        {
                            Typewriter.Write("You see nothing of interest.");
                            break;
                        }
                        Typewriter.Write($"You found a healing potion! Your health has been replenished.");
                        player.CurrentHP = player.MaxHP;
                        break;
                    }
                case 3:
                case 13:
                case 5:
                case 15:
                case 8:
                    {
                        if (randomWeaponProc == 8 && player.PlayerUpgradePaths.CurrentLuckValue < 1)
                        {
                            Typewriter.Write("You see nothing of interest.");
                            break;
                        }
                        Typewriter.Write($"You found a mana potion! Your mana has been replenished.");
                        player.CurrentMana = player.MaxMana;
                        break;
                    }
                default:
                    Typewriter.Write("You see nothing of interest.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        public static void GenerateEncounter(Player.Player player)
        {
            Random r = new Random();
            Typewriter.Write("You look around...");
            int enemyEncounterChecker = r.Next(0, 2);
            if (enemyEncounterChecker == 1)
            {
                Typewriter.Write("There is an enemy!");
                Console.WriteLine("Press any key to continue...");

                Console.ReadKey();
                Console.Clear();
                
                int enemyType = r.Next(1, 7);
                var enemy = new EnemyBase(player, (EnemyType)enemyType);

                RunEncounter(player, enemy, true);
            }
        }



        private static void RunEncounter(Player.Player player, EnemyBase enemy, bool playerTurn)
        {
            Random r = new Random();
            bool endEncounter = false;
            bool hasCastRejuvination = false;
            bool hasCastLifesteal = false;
            bool hasCastFastStrike = false;
            bool hasCastPowerfulStrike = false;
            while (endEncounter == false)
            {
                Console.Clear();
                Console.WriteLine(AsciiArt.GetEnemyAscii(enemy.Type, player, enemy));
                Console.WriteLine($"You are fighting {enemy.Name}");
                if (player.CurrentHP <= 0)
                {
                    Typewriter.Write("You died!");
                    player.Died = true;
                    endEncounter = true;
                }
                else if (enemy.CurrentHP <= 0)
                {
                    //Killed Enemy
                    Typewriter.Write("The enemy died!");

                    player.ExperienceGained++;
                    if (player.ExperienceGained == player.ExperienceRequired)
                    {
                        player.LevelUp();
                        Typewriter.Write("You levelled up!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }

                    endEncounter = true;
                }
                else
                {
                    if (playerTurn)
                    {
                        PlayerTurn(player, enemy, ref playerTurn, r, ref hasCastRejuvination, ref hasCastLifesteal, ref hasCastFastStrike, ref hasCastPowerfulStrike);
                    }
                    if (enemy.CurrentHP > 0 && !playerTurn)
                    {
                        //Enemy turn
                        int dmg = r.Next(enemy.Weapon.MinDamage, enemy.Weapon.MaxDamage);
                        player.CurrentHP -= dmg;
                        Typewriter.Write($"{enemy.Name} did {dmg} Damage");
                        playerTurn = true;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

        }
        private static void PlayerTurn(Player.Player player, EnemyBase enemy, ref bool playerTurn, Random r, ref bool hasCastRejuvination, ref bool hasCastLifesteal, ref bool hasCastFastStrike, ref bool hasCastPowerfulStrike)
        {
            if ((Convert.ToDouble(player.CurrentHP) / Convert.ToDouble(player.MaxHP)) < 0.15)
            {
                Typewriter.Write("Your health is low!");
            }
            if (player.CurrentMana > 0)
            {
                Typewriter.Write("[A]ttack or [H]eal?");
                if (player.PlayerUpgradePaths.RejuvinationSpell && !hasCastRejuvination)
                {
                    Typewriter.Write("Cast [R]ejuvination");
                }
                if (player.PlayerUpgradePaths.FastStrikeSpell && !hasCastFastStrike)
                {
                    Typewriter.Write("Cast [F]ast Strike");
                }
                if (player.PlayerUpgradePaths.PowerfulStrikeSpell && !hasCastPowerfulStrike)
                {
                    Typewriter.Write("Cast [P]owerful Strike");
                }
                if (player.PlayerUpgradePaths.LifestealSpell && !hasCastLifesteal)
                {
                    Typewriter.Write("Cast [L]ifesteal");
                }
            }
            else
            {
                Typewriter.Write("You are out of mana!");
                Typewriter.Write("[A]ttack");
            }
            var input = Console.ReadLine().ToString().ToLower();
            if (input.Equals("a"))
            {
                //do damage

                int playerDamage = r.Next(player.Weapon.MinDamage, player.Weapon.MaxDamage + 1) + player.PlayerUpgradePaths.CurrentStrengthValue;
                int addlFastStrikeDamage = 0;
                int addlPowerfulStrikeDamage = 0;
                int lifeStealHealing = 0;
                if (hasCastPowerfulStrike)
                {
                    addlPowerfulStrikeDamage = r.Next(1, 5);
                }
                if (hasCastFastStrike)
                {
                    addlFastStrikeDamage = r.Next(player.Weapon.MinDamage, player.Weapon.MaxDamage + 1) + player.PlayerUpgradePaths.CurrentStrengthValue;
                    hasCastFastStrike = false;
                }
                if (hasCastLifesteal)
                {
                    lifeStealHealing = playerDamage / 2;
                }
                enemy.CurrentHP -= playerDamage;

                Typewriter.Write($"You did {playerDamage} Damage");
                if (addlPowerfulStrikeDamage > 0)
                {
                    Typewriter.Write($"[Powerful Strike] did {addlPowerfulStrikeDamage} additional damage!");
                    enemy.CurrentHP -= addlPowerfulStrikeDamage;
                }
                if (addlFastStrikeDamage > 0)
                {
                    Typewriter.Write($"[Fast Strike] did {addlFastStrikeDamage} additional damage!");
                    enemy.CurrentHP -= addlFastStrikeDamage;
                }
                if (lifeStealHealing > 0)
                {
                    Typewriter.Write($"You stole {lifeStealHealing} HP!");
                    player.LifestealHeal(lifeStealHealing);
                }
                playerTurn = false;
            }
            else if (input.Equals("h") && player.CurrentMana > 0)
            {
                //heal
                player.Heal(rejuvinationActive: hasCastRejuvination);
                Typewriter.Write($"You healed yourself. Current Health: {player.CurrentHP}");
                playerTurn = false;
            }
            else if (input.Equals("r") && player.CurrentMana > 0 && player.PlayerUpgradePaths.RejuvinationSpell)
            {
                player.CurrentMana--;
                Typewriter.Write("You cast [Rejuvination]");
                Typewriter.Write("Your healing becomes 50% more powerful!");
                hasCastRejuvination = true;
                playerTurn = false;
            }
            else if (input.Equals("f") && player.CurrentMana > 0 && player.PlayerUpgradePaths.FastStrikeSpell)
            {
                player.CurrentMana--;
                Typewriter.Write("You cast [Fast Strike]");
                Typewriter.Write("Your next attack will hit twice");
                hasCastFastStrike = true;
                playerTurn = false;
            }
            else if (input.Equals("p") && player.CurrentMana > 0 && player.PlayerUpgradePaths.PowerfulStrikeSpell)
            {
                player.CurrentMana--;
                Typewriter.Write("You cast [Powerful Strike]");
                Typewriter.Write("Your attacks will deal 1-4 additional damage");
                hasCastPowerfulStrike = true;
                playerTurn = false;
            }
            else if (input.Equals("l") && player.CurrentMana > 0 && player.PlayerUpgradePaths.LifestealSpell)
            {
                player.CurrentMana--;
                Typewriter.Write("You cast [Lifesteal]");
                Typewriter.Write("Your attacks will heal for 50% damage done.");
                hasCastLifesteal = true;
                playerTurn = false;
            }
        }


        private static void SpecialEncounter1(Player.Player player)
        {
            Console.Clear();
            Console.WriteLine(AsciiArt.GetHook1Art());
            if (player.PlayerProgression.CurrentHook == 1)
            {
                Typewriter.Write($"You found a note!");
                Typewriter.Write($"The note says: ");
                Typewriter.Write($"{player.Name}, I'm praying to the Gods you find this letter.");
                Typewriter.Write($"If you don't remember, we both were brought here after being");
                Typewriter.Write($"captured by Zalil, the high priest.");
                Typewriter.Write($" ");
                Typewriter.Write($"I tried to wake you up, but it seems your body was slower to");
                Typewriter.Write($"respond to the trauma than my own. There's more to this maze");
                Typewriter.Write($"than you might realize; but you need to keep an eye out f--");
                Typewriter.Write($"......", 200);
                Typewriter.Write($"The rest of the note is missing, you'll have to find the other part.");
                Typewriter.Write($"of the message to figure out what the stranger is trying to tell you.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine(AsciiArt.GetHook1ArtifactArt());
                Typewriter.Write($"Inside of the note is a small idol; ");
                Typewriter.Write($"carved stone with an unreadable inscription");
                Typewriter.Write($"You hold it in your palm, and feel a surge of energy flow through");
                Typewriter.Write($"your body. ");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();


                Console.Clear();
                Console.WriteLine(AsciiArt.AngelArt());

                Typewriter.Write($"A holy apparition appears before you and speaks.");
                Console.WriteLine("-----------------------------------------------------------------------");
                Typewriter.Write($"{player.Name}, it seems you have found possession of my idol.");
                Typewriter.Write($"it seems fate has allowed my powers to be of your service for the time.");
                Typewriter.Write($"Breathe deep, and focus on this icon, and allow my power to flow through");
                Typewriter.Write($"you to help guide you along your journey out of this unholy labyrinth.");


                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine(AsciiArt.UpgradePlayerAbilitiesArt(player));
                Typewriter.Write("You can select an ability to permanently upgrade.");
                Typewriter.Write("[S]trength, [E]ndurance, [W]isdom, [L]uck");
                Typewriter.Write("[1] - Rejuvination");
                Typewriter.Write("[2] - Fast Strike");
                Typewriter.Write("[3] - Powerful Strike");
                Typewriter.Write("[4] - Lifesteal");

                var upgradeInput = Console.ReadLine().ToString().ToLower();

                player.SetUpgrade(upgradeInput);


                player.PlayerProgression.CurrentHook++;
                player.PlayerProgression.HasCompletedFirstMilestone = true;
            }
        }

        private static void SpecialEncounter2(Player.Player player)
        {
            if (player.PlayerProgression.CurrentHook == 2)
            {
                Console.Clear();
                Console.WriteLine(AsciiArt.GetHook1Art());

                Typewriter.Write("You found another note!");
                Typewriter.Write("You hold the bottom of the note to the first part.");
                Typewriter.Write(" ");
                Typewriter.Write("you need to keep an eye out for Zalil's runes. I hope you have found the one I left you already.");
                Typewriter.Write("The runes will grant you the strength you'll need to defeat Zalil, if you manage to find him.");
                Typewriter.Write("The beasts in here get stronger and stronger. Manage your resources wisely, or you might not");
                Typewriter.Write("make it out at all. ");
                Typewriter.Write(" ");
                Typewriter.Write("......", 200);
                Typewriter.Write("That's the end of the note. You still have no idea who it's from though.");

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                player.PlayerProgression.CurrentHook++;
                player.PlayerProgression.HasCompletedSecondMilestone = true;
            }
        }
    }
}
