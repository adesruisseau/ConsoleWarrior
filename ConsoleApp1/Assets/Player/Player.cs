using ConsoleApp1.Assets.Models;
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
        public int CurrentHP { get; set; }
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
            return false;
        }

        public int Heal(bool rejuvinationActive = false)
        {
            Random r = new Random();
            int healedAmount = r.Next(1 + Level, (Level * 2) + (MaxHP / 2));
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

            MaxMana = (MaxMana + (Level / 2)) + PlayerUpgradePaths.CurrentWisdomValue;
            CurrentMana = MaxMana;

            ExperienceRequired = Level;
            ExperienceGained = 0;
            return Level;
        }

        public void SetUpgrade(string input)
        {
            if (input.Equals("s"))
            {
                PlayerUpgradePaths.CurrentStrengthValue++;
                Typewriter.Write("You upgraded your strength!");
            }
            if (input.Equals("e"))
            {
                PlayerUpgradePaths.CurrentEnduranceValue++;
                Typewriter.Write("You upgraded your endurance!");
            }
            if (input.Equals("w"))
            {
                PlayerUpgradePaths.CurrentWisdomValue++;
                Typewriter.Write("You upgraded your wisdom!");
            }
            if (input.Equals("l"))
            {
                PlayerUpgradePaths.CurrentLuckValue++;
                Typewriter.Write("You upgraded your luck!");
            }
            if (input.Equals("1"))
            {
                PlayerUpgradePaths.RejuvinationSpell = true;
                Typewriter.Write("You can now cast [Rejuvination]");
            }
            if (input.Equals("2"))
            {
                PlayerUpgradePaths.FastStrikeSpell = true;
                Typewriter.Write("You can now cast [Fast Strike]");
            }
            if (input.Equals("3"))
            {
                PlayerUpgradePaths.PowerfulStrikeSpell = true;
                Typewriter.Write("You can now cast [Powerful Strike]");
            }
            if (input.Equals("4"))
            {
                PlayerUpgradePaths.LifestealSpell = true;
                Typewriter.Write("You can now cast [Lifesteal]");
            }
        }
    }

    public class PlayerProgression
    {
        public int CurrentHook { get; set; } = 1;

        public int ReceiveFirstHookAtLevel { get; set; } = 3;
        public int ReceiveSecondHookAtLevel { get; set; } = 6;
        public int ReceiveThirdHookAtLevel { get; set; } = 10;

        public bool HasCompletedFirstMilestone { get; set; } = false;
        public bool HasCompletedSecondMilestone { get; set; } = false;
        public bool HasCompletedThirdMilestone { get; set; } = false;
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
