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
        int damage;
        public int stack = 1;

        public void EnemtAttackDamage(Enemy enemy, int damage)
        {
            Random random = new Random();
            damage = (100 / (30 + GameManager.Instance.player.Championclass.def) + 1) * enemy.atk;
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"자신은 {Randomdamage}의 피해를 입었습니다.\n");
            GameManager.Instance.player.Championclass.hp -= Randomdamage;
            Thread.Sleep(1000);
        }
        public void PlayerAttackDamage(string name, Enemy enemy)
        {
            Console.Clear();
            Random random = new Random();
            damage = 100 / (30 + enemy.def) * GameManager.Instance.player.Championclass.atk;
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"{GameManager.Instance.player.PlayerName}이(가) 기본 공격을 사용합니다. \n{enemy.name}은 {Randomdamage}의 피해를 받았습니다.\n");
            enemy.hp -= Randomdamage;
            Thread.Sleep(1000);
        }
        public void PlayerAllSkillDamage(int NewDamage, List<Enemy> enemies)
        {
            Console.Clear();
            foreach (var enemy in enemies)
            
            {
                if (enemy.hp > 0)
                {
                    Random random = new Random();
                    damage = NewDamage;
                    int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
                    Console.WriteLine($"{enemy.name}은 {Randomdamage}의 피해를 받았습니다.\n");
                    enemy.hp -= Randomdamage;
                }
            }
            Thread.Sleep(1000);
        }
        public void PlayerSkillDamage(int NewDamage, Enemy enemy)
        {
            Console.Clear();
            Random random = new Random();
            damage = NewDamage;
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"{enemy.name}은 {Randomdamage}의 피해를 받았습니다.\n");
            enemy.hp -= Randomdamage;
            Thread.Sleep(1000);
        }
        public void TeemoSkillDamage(int NewDamage, Enemy enemy)
        {
            Console.Clear();
            Random random = new Random();
            damage = NewDamage/2 * stack++;
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"{enemy.name}은 {Randomdamage}의 추가 독 피해를 받았습니다.\n");
            enemy.hp -= Randomdamage;
            if (stack >= 5)
            {
                stack = 1;
            }
            Thread.Sleep(1000);
        }
    }
}
