using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class Enemy : IStatus
    {
        public string? name { get; set; }
        public int hp { get; set; }
        public int mp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int gold { get; set; }//처치시 획득 골드
        public int skillcode { get; set; }//처치시 획득 경험치

        public Enemy(string Enemyname, int Hp, int Mp, int Atk, int Def, int Gold, int skillcode)
        {
            name = Enemyname;
            this.hp = Hp;
            this.mp = Mp;
            this.atk = Atk;
            this.def = Def;
            this.gold = Gold;
            this.skillcode = skillcode;
        }
    }

    internal class EnemyFactory
    {
        Enemy MeleeMinion = new Enemy("전사 미니언", 47, 0, 12, 1, 21, 1);
        Enemy CasterMinion = new Enemy("마법사 미니언", 29, 0, 24, 1, 14, 2);
        Enemy SuperMinion = new Enemy("슈퍼 미니언", 160, 0, 47, 10, 60, 3);
        Enemy TurretTower = new Enemy("포탑", 500, 0, 18, 5, 420, 11);
    }

    internal class Enemyskill
    {
        public int damage;
        public void normalskill(Enemy enemy)
        {
            Console.WriteLine($"{enemy.name}의 공격!");
            damage = enemy.atk;
        }
        public void OnlyTurretskill(Enemy enemy)
        {
            if (enemy.skillcode == 11)
            {
                if (enemy.mp >= 5)
                {
                    Console.WriteLine($"{enemy.name}의 강화 공격!");
                    damage = enemy.atk * 2;
                    Damage(enemy);
                }
                else
                {
                    Console.WriteLine($"{enemy.name}의 공격!");
                    damage = enemy.atk;
                    Damage(enemy);
                }
            }
            else
            {
                Console.WriteLine($"{enemy.name}의 공격!");
                damage = enemy.atk;
                Damage(enemy);
            }
        }
        public void Damage(Enemy enemy)
        {
            Random random = new Random();
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"플레이어를 {Randomdamage}의 피해를 입었다!");
        }
    }
}
