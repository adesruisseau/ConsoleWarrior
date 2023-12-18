using ConsoleApp1.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Assets.Enemies
{
    public class Enemy
    {
        public string Name { get; set; }
        public EnemyType Type { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int Level { get; set; }
        public Weapon Weapon { get; set; }

        public Enemy(Player.Player player, EnemyType type)
        {
            Random r = new Random();
            int level = r.Next(player.Level - 2, player.Level + 1);
            if (level < 0)
            {
                level = 1;
            }

            if (level <= 3)
            {
                Name = $"Weak {type}";
            }
            if (level > 3 && level <= 7)
            {
                Name = $"Average {type}";
            }
            if (level > 7)
            {
                Name = $"Powerful {type}";
            }

            
            Type = type;
            MaxHP = 9 + (2 * level + 3);
            CurrentHP = MaxHP;
            Level = level;
            Weapon = new Weapon(player, true, true);
        }
        
        public Enemy() { }

        public static Enemy Zalil()
        {
            var response = new Enemy()
            {
                Name = "Zalil",
                Type = EnemyType.Vampire,
                CurrentHP = 400,
                MaxHP = 400,
                Level = 12,
                Weapon = new Weapon()
                {
                    Name = "Staff of Death",
                    MinDamage = 18,
                    MaxDamage = 20,
                    Type = WeaponType.Mace
                }
            };
            return response;
        }
    }

    

    

    public enum EnemyType
    {
        Vampire = 1,
        Skeleton = 2,
        Goblin = 3,
        Minotaur = 4,
        Ghost = 5,
        Spider = 6
    }
}
