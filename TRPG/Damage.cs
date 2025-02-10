using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TRPG
{
    internal class Damage
    {
        public Player player;
        public BattleSystem battleSystem;
        int damage;

        public void EnemtAttackDamage(Enemy enemy, int damage)
        {
            Random random = new Random();
            damage = 100 / (100 + player.Championclass.def) * enemy.atk;
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"자신은 {Randomdamage}의 피해를 입었습니다.\n");
            player.Championclass.hp -= Randomdamage;
        }
        public void PlayerAttackDamage(string name, Enemy enemy)
        {
            Random random = new Random();
            damage = 100 / (100 + enemy.def) * player.Championclass.atk;
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"{player.PlayerName}이 기본 공격을 사용합니다. \n{enemy.name}은 {Randomdamage}의 피해를 받았습니다.)");
            enemy.hp -= Randomdamage;
        }
        public void PlayerAllSkillDamage(int NewDamage)
        {
            foreach (var enemy in battleSystem.enemies)
            {
                if (enemy.hp > 0)
                {
                    Random random = new Random();
                    damage = NewDamage;
                    int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
                    Console.WriteLine($"{enemy.name}은 {Randomdamage}의 피해를 받았습니다.)");
                    enemy.hp -= Randomdamage;
                }
            }
        }
        public void PlayerSkillDamage(int NewDamage, Enemy enemy)
        {
            Random random = new Random();
            damage = NewDamage;
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"{enemy.name}은 {Randomdamage}의 피해를 받았습니다.)");
            enemy.hp -= Randomdamage;
        }
    }
}
