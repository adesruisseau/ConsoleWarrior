using ConsoleApp1.Assets.Player;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Assets.Models
{
    public class Weapon
    {
        public string Name { get; set; }
        public WeaponType Type { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public int Attack()
        {
            Random r = new Random();
            int response = r.Next(MinDamage, MaxDamage + 1);
            return response;
        }

        public Weapon()
        {

        }

        public Weapon(WeaponType type)
        {
            if (type == WeaponType.Unarmed)
            {
                Name = "Unarmed";
                Type = WeaponType.Unarmed;
                MinDamage = 1; 
                MaxDamage = 1;
            }
        }

        public Weapon(Player.Player player, bool random = false)
        {
            Random r = new Random();
            int weaponTypeSelector = r.Next(0, 3);
            Type = (WeaponType)weaponTypeSelector;
            Name = WeaponNamePrefixes[r.Next(0, WeaponNamePrefixes.Count)] + " " + Type.ToString();

            // Adjust these multipliers as needed for balance
            double damageMultiplier = 0.5 + (player.Level * 0.1);
            MinDamage = Math.Max(1, (int)(damageMultiplier * player.Level));
            MaxDamage = Math.Max(1, (int)((damageMultiplier + 0.5) * player.Level));
        }

        public Weapon(Player.Player player, bool random = false, bool isEnemyWeapon = true)
        {
            Random r = new Random();
            int weaponTypeSelector = r.Next(0, 3);
            Type = (WeaponType)weaponTypeSelector;
            Name = WeaponNamePrefixes[r.Next(0, WeaponNamePrefixes.Count)] + " " + Type.ToString();

            // Adjust these multipliers as needed for balance
            double damageMultiplier = 0.4 + (player.Level * 0.08);
            MinDamage = Math.Max(1, (int)(damageMultiplier * player.Level));
            MaxDamage = Math.Max(1, (int)((damageMultiplier + 0.3) * player.Level));
        }

        private List<string> WeaponNamePrefixes = new List<string>()
        {
            "Rusty", "Shiny", "Dull", "Great", "Heavy", "Bloody"
        };
    }

    public enum WeaponType
    {
        Sword,
        Axe,
        Mace,
        Unarmed
    }


}