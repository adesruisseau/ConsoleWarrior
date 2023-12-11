using ConsoleApp1.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Assets.Enemies
{
    public class EnemyBase
    {
        public string Name { get; set; }
        public EnemyType Type { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int Level { get; set; }
        public Weapon Weapon { get; set; }

        public EnemyBase(Player.Player player, EnemyType type)
        {
            Random r = new Random();
            int level = r.Next(player.Level - 1, player.Level + 1);

            Name = type.ToString();
            Type = type;
            MaxHP = r.Next(player.MaxHP / 2, player.MaxHP);
            CurrentHP = MaxHP;
            Level = level;
            Weapon = new Weapon(player, true, true);
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
