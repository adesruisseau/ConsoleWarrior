using ConsoleApp1.Assets.Models;
using ConsoleApp1.Assets.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Assets.Player
{
    public class Player
    {
        public string Name { get; set; } = "";
        public int CurrentHP { get; set; } = 9;
        public int MaxHP { get; set; } = 9;
        public int CurrentMana { get; set; }
        public int MaxMana { get; set; }
        public int Level { get; set; } = 1;

        public Weapon Weapon { get; set; }

        public int ExperienceRequired { get; set; }
        public int ExperienceGained { get; set; }

        public bool Died { get; set; }

        public PlayerProgression PlayerProgression { get; set; } = new PlayerProgression();

        public PlayerUpgradePaths PlayerUpgradePaths { get; set; } = new PlayerUpgradePaths();

        public bool HasSpecialEncounterPending()
        {
            if (Level >= PlayerProgression.ReceiveFirstHookAtLevel && !PlayerProgression.HasCompletedFirstMilestone)
            {
                return true;
            }
            if (Level >= PlayerProgression.ReceiveSecondHookAtLevel && !PlayerProgression.HasCompletedSecondMilestone)
            {
                return true;
            }
            if (Level >= PlayerProgression.ReceiveThirdHookAtLevel && !PlayerProgression.HasCompletedThirdMilestone)
            {
                return true;
            }
            if (Level >= PlayerProgression.ReceiveFourthHookAtLevel && !PlayerProgression.HasCompletedFourthMilestone)
            {
                return true;
            }
            if (Level >= PlayerProgression.ReceiveFifthHookAtLevel && !PlayerProgression.HasCompletedFifthMilestone)
            {
                return true;
            }
            return false;
        }

        public int Heal(bool rejuvinationActive = false)
        {
            Random r = new Random();
            int healedAmount = r.Next(1 + Level, (Level * 2) + (int)Math.Ceiling((double)(MaxHP / 2)));
            if (rejuvinationActive)
            {
                healedAmount = healedAmount + (int)(healedAmount * .5);
            }
            CurrentHP = healedAmount + CurrentHP > MaxHP ? MaxHP : healedAmount + CurrentHP;
            Typewriter.Write($"You healed for {healedAmount}");
            CurrentMana--;
            return healedAmount;
        }

        public int LifestealHeal(int healedAmount)
        {
            CurrentHP = healedAmount + CurrentHP > MaxHP ? MaxHP : healedAmount + CurrentHP; 
            return healedAmount;
        }

        public int LevelUp()
        {
            Level++;
            MaxHP += (Level * 2) + PlayerUpgradePaths.CurrentEnduranceValue;
            CurrentHP = MaxHP;

            MaxMana = (MaxMana + (int)Math.Ceiling((double)(Level / 2))) + PlayerUpgradePaths.CurrentWisdomValue;
            CurrentMana = MaxMana;

            ExperienceRequired = Level;
            ExperienceGained = 0;
            return Level;
        }

        public bool SetUpgrade(string input)
        {
            var response = true;
            if (input.Equals("s") && PlayerUpgradePaths.CurrentStrengthValue < PlayerUpgradePaths.MaxStrengthValue)
            {
                PlayerUpgradePaths.CurrentStrengthValue++;
                Typewriter.Write("You upgraded your strength!");
            }
            else if (input.Equals("e") && PlayerUpgradePaths.CurrentEnduranceValue < PlayerUpgradePaths.MaxEnduranceValue)
            {
                PlayerUpgradePaths.CurrentEnduranceValue++;
                Typewriter.Write("You upgraded your endurance!");
                CurrentHP += (int)Math.Ceiling((MaxHP * .1));
                MaxHP += (int)Math.Ceiling((MaxHP * .1));
            }
            else if (input.Equals("w") && PlayerUpgradePaths.CurrentWisdomValue < PlayerUpgradePaths.MaxWisdomValue)
            {
                PlayerUpgradePaths.CurrentWisdomValue++;
                Typewriter.Write("You upgraded your wisdom!");
                CurrentMana += 2;
                MaxMana += 2;
            }
            else if (input.Equals("l") && PlayerUpgradePaths.CurrentLuckValue < PlayerUpgradePaths.MaxLuckValue)
            {
                PlayerUpgradePaths.CurrentLuckValue++;
                Typewriter.Write("You upgraded your luck!");
            }
            else if (input.Equals("1") && !PlayerUpgradePaths.RejuvinationSpell)
            {
                PlayerUpgradePaths.RejuvinationSpell = true;
                Typewriter.Write("You can now cast [Rejuvination]");
            }
            else if (input.Equals("2") && !PlayerUpgradePaths.FastStrikeSpell)
            {
                PlayerUpgradePaths.FastStrikeSpell = true;
                Typewriter.Write("You can now cast [Fast Strike]");
            }
            else if (input.Equals("3") && !PlayerUpgradePaths.PowerfulStrikeSpell)
            {
                PlayerUpgradePaths.PowerfulStrikeSpell = true;
                Typewriter.Write("You can now cast [Powerful Strike]");
            }
            else if (input.Equals("4") && !PlayerUpgradePaths.LifestealSpell)
            {
                PlayerUpgradePaths.LifestealSpell = true;
                Typewriter.Write("You can now cast [Lifesteal]");
            }
            else
            {
                response = false;
            }
            return response;
        }

        public static Player CreatePlayer(string name)
        {
            Player player = new Player()
            {
                Name = name,
                Level = 1,
                MaxHP = 9,
                CurrentHP = 9,
                CurrentMana = 1,
                MaxMana = 1,
                Weapon = new Weapon(WeaponType.Unarmed),
                ExperienceRequired = 1,
                ExperienceGained = 0
            };
            if (name.Equals("skip"))
            {
                var starterWeapon = new Weapon()
                {
                    Name = "Rusty Sword",
                    Type = WeaponType.Sword,
                    MinDamage = 1,
                    MaxDamage = 4,
                };
                player.Weapon = starterWeapon;
                RoomEngine.GenerateNextArea(player);
            }
            if (name.Equals("cheater"))
            {
                var starterWeapon = new Weapon()
                {
                    Name = "Rusty Sword",
                    Type = WeaponType.Sword,
                    MinDamage = 1,
                    MaxDamage = 4,
                };
                player.Weapon = starterWeapon;
                player.PlayerUpgradePaths.RejuvinationSpell = true;
                player.PlayerUpgradePaths.FastStrikeSpell = true;
                player.PlayerUpgradePaths.PowerfulStrikeSpell = true;
                player.PlayerUpgradePaths.LifestealSpell = true;
                RoomEngine.GenerateNextArea(player);
            }

            return player;
        }

    }

    


    public class PlayerProgression
    {
        public int CurrentHook { get; set; } = 1;

        public int ReceiveFirstHookAtLevel { get; set; } = 3;
        public int ReceiveSecondHookAtLevel { get; set; } = 5;
        public int ReceiveThirdHookAtLevel { get; set; } = 6;
        public int ReceiveFourthHookAtLevel { get; set; } = 8;
        public int ReceiveFifthHookAtLevel { get; set; } = 10;

        public bool HasCompletedFirstMilestone { get; set; } = false;
        public bool HasCompletedSecondMilestone { get; set; } = false;
        public bool HasCompletedThirdMilestone { get; set; } = false;
        public bool HasCompletedFourthMilestone { get; set; } = false;
        public bool HasCompletedFifthMilestone { get; set; } = false;
    }

    public class PlayerUpgradePaths
    {
        public int CurrentStrengthValue { get; set; } = 0;
        public int MaxStrengthValue { get; set; } = 3;

        public int CurrentEnduranceValue { get; set; } = 0;
        public int MaxEnduranceValue { get; set; } = 3;

        public int CurrentWisdomValue { get; set; } = 0;
        public int MaxWisdomValue { get; set; } = 3;

        public int CurrentLuckValue { get; set; } = 0;
        public int MaxLuckValue { get; set; } = 3;

        public bool RejuvinationSpell { get; set; } = false;
        public bool FastStrikeSpell { get; set; } = false;
        public bool PowerfulStrikeSpell { get; set; } = false;
        public bool LifestealSpell { get; set; } = false;
    }
}
