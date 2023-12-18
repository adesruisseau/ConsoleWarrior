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
            int specialItemFoundProc = r.Next(0, 11);

            if (specialItemFoundProc < 2)
            {
                SpecialEncounter1(player);

            }
            if (specialItemFoundProc > 2 && specialItemFoundProc <= 4)
            {
                SpecialEncounter2(player);
            }
            if (specialItemFoundProc > 4 && specialItemFoundProc <= 6)
            {
                SpecialEncounter3(player);
            }
            if (specialItemFoundProc > 6 && specialItemFoundProc <= 8)
            {
                SpecialEncounter4(player);
            }
            if (specialItemFoundProc > 8 && specialItemFoundProc <= 10)
            {
                SpecialEncounter5(player);
            }
        }

        

        public static void GenerateItem(Player.Player player)
        {
            Random r = new Random();
            int randomItemProc = r.Next(0, 100);            

            if (randomItemProc <= 30) //30% max chance of finding a weapon (Base [10%] + 2 Luck Upgrades)
            {
                if ((player.PlayerUpgradePaths.CurrentLuckValue < 1 && randomItemProc < 20)
                    || (player.PlayerUpgradePaths.CurrentLuckValue < 2 && randomItemProc <= 30))
                {
                    var weapon = new Weapon(player, true);
                    Typewriter.Write($"You found a [{weapon.Name}]   Damage: {weapon.MinDamage} - {weapon.MaxDamage}!");
                    Typewriter.Write($"Do you want to replace your {player.Weapon.Name}? [Y]/[n]");
                    var acceptWeaponInput = Console.ReadLine();
                    if (acceptWeaponInput.ToString().ToLower().Equals("y"))
                    {
                        player.Weapon = weapon;
                    }
            }
                
            }
            else if (randomItemProc > 30 && randomItemProc <= 65)
            {
                if (player.CurrentHP != player.MaxHP
                    && ((player.PlayerUpgradePaths.CurrentLuckValue < 1 && randomItemProc < 45)
                    || (player.PlayerUpgradePaths.CurrentLuckValue < 2 && randomItemProc < 55)))
                {
                    Typewriter.Write($"You found a healing potion! Your health has been replenished.");
                    player.CurrentHP = player.MaxHP;
                }
                else
                {
                    Typewriter.Write("You see nothing of interest.");
                }
                
            }
            else if (randomItemProc > 65)
            {
                if (player.CurrentMana != player.MaxMana
                       && ((player.PlayerUpgradePaths.CurrentLuckValue < 1 && randomItemProc < 80)
                       || (player.PlayerUpgradePaths.CurrentLuckValue < 2 && randomItemProc < 90)))
                {
                    Typewriter.Write($"You found a mana potion! Your mana has been replenished.");
                    player.CurrentMana = player.MaxMana;
                }
                else
                {
                    Typewriter.Write("You see nothing of interest.");
                }
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
                var enemy = new Enemy(player, (EnemyType)enemyType);

                RunEncounter(player, enemy, true);
            }
        }



        private static void RunEncounter(Player.Player player, Enemy enemy, bool playerTurn)
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
        private static void PlayerTurn(Player.Player player, Enemy enemy, ref bool playerTurn, Random r, ref bool hasCastRejuvination, ref bool hasCastLifesteal, ref bool hasCastFastStrike, ref bool hasCastPowerfulStrike)
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
                Typewriter.Write($"Breathe deep, focus on this icon, and allow my power to flow through");
                Typewriter.Write($"you to help guide you along your journey out of this unholy labyrinth.");
                Console.WriteLine("");
                Typewriter.Write("Your health and mana were fully replenished.");
                player.CurrentHP = player.MaxHP;
                player.CurrentMana = player.MaxMana;

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine(AsciiArt.UpgradePlayerAbilitiesArt(player));


                UpgradePlayerAbilities(player);

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

        private static void SpecialEncounter3(Player.Player player)
        {
            if (player.PlayerProgression.CurrentHook == 3)
            {
                Console.Clear();
                Console.WriteLine(AsciiArt.GetHook1ArtifactArt());
                Typewriter.Write($"The holy apparition appears before you again and speaks.");
                Console.WriteLine("-----------------------------------------------------------------------");
                Typewriter.Write($"{player.Name}, it seems you have found possession of another idol.");
                Typewriter.Write($"Breathe deep, focus on this icon, and allow my power to flow through you.");

                Console.WriteLine("");
                Typewriter.Write("Your health and mana were fully replenished.");
                player.CurrentHP = player.MaxHP;
                player.CurrentMana = player.MaxMana;

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine(AsciiArt.UpgradePlayerAbilitiesArt(player));

                UpgradePlayerAbilities(player);


                player.PlayerProgression.CurrentHook++;
                player.PlayerProgression.HasCompletedThirdMilestone = true;
            }
        }

        private static void SpecialEncounter4(Player.Player player)
        {
            if (player.PlayerProgression.CurrentHook == 4)
            {
                Console.Clear();
                Console.WriteLine(AsciiArt.DeadBodyArt());
                Typewriter.Write("You find the dead body of a woman, slumped against a wall.");
                Typewriter.Write(" ");
                Typewriter.Write("A note is laying beside her right arm, and another idol lies in the palm of her left.");
                Console.WriteLine("-----------------------------------------------------------------------");
                Typewriter.Write($"{player.Name}, I can feel Zalil is close. His powerful monsters have been relentlessly");
                Typewriter.Write("attacking me. The onslaught is too much. I lie here writing this note to you, after recovering");
                Typewriter.Write("yet another artifact. I pray you find this, and bring honor to my death. Avenge me, great warrior");
                Typewriter.Write("and escape. For both of us.");
                Typewriter.Write("......", 200);
                Typewriter.Write("That's the end of the note.");

                Typewriter.Write("......", 100);
                Typewriter.Write("You pick up the idol.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine(AsciiArt.GetHook1ArtifactArt());
                Typewriter.Write($"The holy apparition appears before you again and speaks.");
                Console.WriteLine("-----------------------------------------------------------------------");
                Typewriter.Write($"{player.Name}, it seems you have found possession of another idol.");
                Typewriter.Write($"Breathe deep, focus on this icon, and allow my power to flow through you.");

                Console.WriteLine("");
                Typewriter.Write("Your health and mana were fully replenished.");
                player.CurrentHP = player.MaxHP;
                player.CurrentMana = player.MaxMana;

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.WriteLine(AsciiArt.UpgradePlayerAbilitiesArt(player));

                UpgradePlayerAbilities(player);


                player.PlayerProgression.CurrentHook++;
                player.PlayerProgression.HasCompletedFourthMilestone = true;
            }
        }

        private static void SpecialEncounter5(Player.Player player)
        {
            if (player.PlayerProgression.CurrentHook == 5)
            {
                Console.Clear();
                Console.WriteLine(AsciiArt.FinalRoom());
                Typewriter.Write("Suddenly, you come face to face with a man.");
                Typewriter.Write("You instantly recognize him; Zalil, the high priest.");
                Typewriter.Write("Memories come flooding back and you recall him coming to the homestead where you and your tribe lived.");
                Console.WriteLine("");
                Typewriter.Write("Sickness was plaguing your land, more and more of your friends and family were becoming ill.");
                Typewriter.Write("Many died, and the priest had come to the town to bless your people and cure their ailments.");
                Typewriter.Write("Zalil, carried the dead away and promised peaceful burial in crypts.");
                Console.WriteLine("");
                Typewriter.Write("You were skeptical though, because it seemed like after the appearance of Zalil, the death became more frequent.");
                Typewriter.Write("You and your wife were beginning to fall ill too, heavily sedated, Zalil took you from home, which must be");
                Typewriter.Write("how you ended up here.");
                Typewriter.Write("......", 200);
                Typewriter.Write("My wife...");

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine(AsciiArt.Zalil());
                Typewriter.Write($"Zalil speaks");
                Typewriter.Write("......", 200);
                Typewriter.Write($"Hello {player.Name}, I must say I'm a bit surprised to see you here.");
                Typewriter.Write("After I'd finished experimenting on you, I imagined you'd be too weak to find your way through these");
                Typewriter.Write("halls.  Especially with my monsters, or perhaps I should say your friends who have been quite hungry");
                Typewriter.Write(" ");

                SpeakWithZalil(player);

                Console.Clear();
                Console.WriteLine(AsciiArt.AngelArt());
                Console.WriteLine("The holy apparition appears again.");
                Typewriter.Write($"Kill Zalil, {player.Name}");
                Typewriter.Write("Take my idols and hold strong. The power flowing through you alone will not be enough, so give it your all.");
                Typewriter.Write("The power of the idols has healed you!");
                player.CurrentHP = player.MaxHP;
                Typewriter.Write("The power of the idols has restored your mana!");
                player.CurrentMana = player.MaxMana;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine(AsciiArt.UpgradePlayerAbilitiesArt(player));

                UpgradePlayerAbilities(player);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();


                var zalil = Enemy.Zalil();

                ZalilEncounter(player, zalil, true);
                player.PlayerProgression.CurrentHook++;
                player.PlayerProgression.HasCompletedFifthMilestone = true;
            }
        }


        private static void UpgradePlayerAbilities(Player.Player player)
        {
            bool completedUpgrade = false;
            while (!completedUpgrade)
            {
                Typewriter.Write("Please make your selection.");
                var upgradeInput = Console.ReadLine().ToString().ToLower();
                completedUpgrade = player.SetUpgrade(upgradeInput);
            }
        }


        private static void SpeakWithZalil(Player.Player player)
        {


            bool askedAboutFamily = false;
            bool askedAboutFriends = false;

            bool completedTalk = false;
            {
                while (!completedTalk)
                {
                    Console.WriteLine("-----------------------------------------------------------------------");
                    if (!askedAboutFriends)
                    {
                        Console.WriteLine("[1] What did you do to my people.");
                    }
                    if (!askedAboutFamily)
                    {
                        Console.WriteLine("[2] Where is my wife.");
                    }
                    
                    
                    Console.WriteLine("[3] Enough talk; Time to Die!");
                    Typewriter.Write("Please make your selection.");
                    var input = Console.ReadLine().ToString().ToLower();

                    if (input.Equals("1"))
                    {
                        Typewriter.Write("What did you do to my people?");
                        Typewriter.Write("---------------------------------------");
                        Typewriter.Write("Well, I had my fun with them alright.");
                        Typewriter.Write("You see, I am a priest, but the Gods I pray to are not the same as yours.");
                        Typewriter.Write("I need willing subjects, who will easily do my bidding. So I trained in magic to summon the dead and");
                        Typewriter.Write("reanimate corpses, sometimes completely transforming the people who once were, into something");
                        Typewriter.Write("much more beautiful.");
                        Typewriter.Write("Your friends are dead, I hope that is abundantly clear. Your town is vacant, for now. ");
                        Typewriter.Write("Once I'm finished with you, we will march from your town to the next, ridding this world of all");
                        Typewriter.Write("life and filling it with my monsters.");
                    }
                    else if (input.Equals("2"))
                    {
                        Typewriter.Write("Where is my wife?");
                        Typewriter.Write("---------------------------------------");
                        Typewriter.Write("You're eager to see your wife hmm? Wouldn't it be easier if I told you she was dead with your friends?");
                        Typewriter.Write(" 'Come here woman!' ---");
                        Typewriter.Write("You see your wife is quite beautiful isn't she? How lucky you are- or were.");
                        Typewriter.Write("---      You hear the scratching sound of chains dragging against the stone floor.");
                        Typewriter.Write("         Your wife walks into the room, and when you see her, your heart screams.");
                        Typewriter.Write("         Her head hangs to the ground, unable to make eye contact.");
                        Typewriter.Write("          She wears drab clothing and chains and is covered in blood, dirt, and grime.");
                        Typewriter.Write(" ");
                        Typewriter.Write("         You take a step towards her, but Zalil cuts you off to speak-");
                        Typewriter.Write("");
                        Typewriter.Write("Yes... I guess you could say I've neglected to care for her");
                        Typewriter.Write("but I have plans for her soon.");
                        Typewriter.Write("You want her back, don't you?");
                        Typewriter.Write("......", 200);
                        Typewriter.Write($"Well, what are you waiting for {player.Name}? I'm ready to kill you too.");
                    }
                    else if (input.Equals("3"))
                    {
                        completedTalk = true;
                    }
                }
            }
        }

        private static void ZalilEncounter(Player.Player player, Enemy enemy, bool playerTurn)
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
                Console.WriteLine(AsciiArt.ZalilCombat(player, enemy));
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
                        var attackProc = r.Next(0, 6);
                        if (attackProc < 3)
                        {
                            //Enemy turn
                            int dmg = r.Next(enemy.Weapon.MinDamage, enemy.Weapon.MaxDamage);
                            player.CurrentHP -= dmg;
                            Typewriter.Write($"{enemy.Name} did {dmg} Damage");
                            playerTurn = true;
                        }
                        else if (attackProc == 3)
                        {
                            Typewriter.Write("Zalil cast [Paralyze]!");
                            Typewriter.Write("You cannot move!");
                        }
                        else if (attackProc == 4 && enemy.CurrentHP < enemy.MaxHP)
                        {
                            int heal = r.Next(20, 50);
                            Typewriter.Write($"Zalil healed himself {heal} points!");
                            enemy.CurrentHP += heal;
                            playerTurn = true;
                        }
                        else if (attackProc == 5)
                        {
                            int dmg = r.Next(enemy.Weapon.MinDamage, enemy.Weapon.MaxDamage);
                            player.CurrentHP -= dmg;
                            Typewriter.Write($"{enemy.Name} cast [Soul Arrow] and did {dmg} Damage");
                            playerTurn = true;
                        }
                        else if (attackProc == 6)
                        {
                            Typewriter.Write($"{enemy.Name} cast [Burst of Speed]!");
                            int check = r.Next(0, 2);
                            if (check == 0)
                            {
                                int dmg = r.Next(enemy.Weapon.MinDamage, enemy.Weapon.MaxDamage);
                                player.CurrentHP -= dmg;
                                Typewriter.Write($"{enemy.Name} did {dmg} Damage!");
                                playerTurn = true;

                                int dmg2 = r.Next(enemy.Weapon.MinDamage, enemy.Weapon.MaxDamage);
                                player.CurrentHP -= dmg2;
                                Typewriter.Write($"{enemy.Name} cast [Soul Arrow] and did {dmg} Damage!");
                                playerTurn = true;
                            }
                            if (check == 1)
                            {
                                int dmg = r.Next(enemy.Weapon.MinDamage, enemy.Weapon.MaxDamage);
                                player.CurrentHP -= dmg;
                                Typewriter.Write($"{enemy.Name} cast [Soul Arrow] and did {dmg} Damage!");
                                playerTurn = true;

                                int heal = r.Next(20, 50);
                                Typewriter.Write($"Zalil healed himself {heal} points!");
                                enemy.CurrentHP += heal;
                                playerTurn = true;
                            }
                        }
                        else
                        {
                            Typewriter.Write($"Zalil is plotting to attack.");
                            playerTurn = true;
                        }

                        
                        
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

        }
    }
}
