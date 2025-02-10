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
        public BattleEnemies battleEnemies;
        int damage;

        public void EnemtAttackDamage(Enemy enemy, int damage)
        {
            Random random = new Random();
            damage = 100 / (100 + player.Championclass.def) * enemy.atk;
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"플레이어는 {Randomdamage}의 피해를 입었다!\n");
            player.Championclass.hp -= Randomdamage;
        }
        public void PlayerAttackDamage(string name, Enemy enemy)
        {
            Random random = new Random();
            damage = 100 / (100 + enemy.def) * player.Championclass.atk;
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"{player.PlayerName}이 기본 공격을 사용합니다. (데미지: {Randomdamage})");
            enemy.hp -= Randomdamage;
        }

        public void PlayerAllSkillDamage(string name)
        {
            foreach (var enemy in battleEnemies.enemies)
            {
                Random random = new Random();
                damage = 100 / (100 + enemy.def) * player.Championclass.atk;
                int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
                Console.WriteLine($"{player.PlayerName}이 스킬을 사용합니다. (데미지: {Randomdamage})");
                enemy.hp -= Randomdamage;
            }
            //Random random = new Random();
            //damage = 100 / (100 + player.Championclass.def);
            //int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            //Console.WriteLine($"{player.PlayerName}이 스킬을 사용합니다. (데미지: {Randomdamage})");

        }
    }
}
