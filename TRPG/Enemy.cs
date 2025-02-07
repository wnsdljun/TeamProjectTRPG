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
        public Enemy MeleeMinion() => new Enemy("전사 미니언", 47, 0, 12, 1, 21, 1);//매번 새로운 객체를 생성하기 위해서 () =>가 필요하다는데 과연 잘 돌아갈까?
        public Enemy CasterMinion() => new Enemy("마법사 미니언", 29, 0, 24, 1, 14, 2);//체력24, 마나0, 공격력24, 방어력1, 골드14, 스킬코드2
        public Enemy SuperMinion() => new Enemy("슈퍼 미니언", 160, 0, 47, 10, 60, 3);
        public Enemy TurretTower() => new Enemy("포탑", 500, 0, 18, 5, 420, 11);
    }

    internal class Enemyskill
    {
        public int damage;

        public void EnemyAttack(Enemy enemy)
        {
            if (enemy.skillcode == 11)
            {
                OnlyTurretskill(enemy);
            }
            else
            {
                normalskill(enemy);
            }
        }
        public void normalskill(Enemy enemy)
        {
            Console.WriteLine($"{enemy.name}의 공격!");
            damage = enemy.atk;
            Damage(enemy);
        }
        public void OnlyTurretskill(Enemy enemy)
        {
            if (enemy.mp >= 5 && enemy.hp <250)
            {
                Console.WriteLine($"{enemy.name}의 강화 포격!");
                damage = enemy.atk * 2;
                enemy.mp -= 5;
                Damage(enemy);
            }
            else
            {
                normalskill(enemy);
            }
        }
        public void Damage(Enemy enemy)
        {
            Random random = new Random();
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"플레이어는 {Randomdamage}의 피해를 입었다!");
        }
    }
}
