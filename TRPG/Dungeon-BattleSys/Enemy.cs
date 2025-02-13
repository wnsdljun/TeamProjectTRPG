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
        public int skillcode { get; set; }//스킬 코드
        public int exp { get; set; }//처치시 획득 경험치

        public Enemy(string Enemyname, int Hp, int Mp, int Atk, int Def, int Gold, int Exp,int skillcode)
        {
            name = Enemyname;
            this.hp = Hp;
            this.mp = Mp;
            this.atk = Atk;
            this.def = Def;
            this.gold = Gold;
            this.exp = Exp;
            this.skillcode = skillcode;
        }
    }

    internal class EnemyFactory
    {
        public Enemy MeleeMinion() => new Enemy("전사 미니언", 477, 0, 12, 1, 21, 61, 1);//매번 새로운 객체를 생성하기 위해서 () =>가 필요하다는데 과연 잘 돌아갈까?
        public Enemy CasterMinion() => new Enemy("마법사 미니언", 296, 0, 24, 1, 14, 30, 2);//체력24, 마나0, 공격력24, 방어력1, 골드14, 경험치30, 스킬코드2
        public Enemy SuperMinion() => new Enemy("슈퍼 미니언", 1600, 0, 45, 10, 60, 97, 3);
        public Enemy TurretTower() => new Enemy("포탑", 5000, 10, 82, 5, 420, 120, 11);
    }

    internal class Enemyskill
    {
        public int damage;
        Damage diedamgae = new Damage();

        public void EnemyAttack(Enemy enemy)
        {
            if (enemy.skillcode == 11)//포탑일 경우에만 강화 포격을 사용한다.
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
            diedamgae.EnemtAttackDamage(enemy, damage);
        }
        public void OnlyTurretskill(Enemy enemy)
        {
            if (enemy.mp >= 5 && enemy.hp <250)
            {
                Console.WriteLine($"{enemy.name}의 강화 포격!");
                damage = enemy.atk * 2;
                enemy.mp -= 5;
                diedamgae.EnemtAttackDamage(enemy, damage);
            }
            else
            {
                normalskill(enemy);
            }
        }
       
    }
}
