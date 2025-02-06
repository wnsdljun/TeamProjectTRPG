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
        public int mp { get ; set ; }
        public int atk { get; set; }
        public int def { get ; set; }
        public int gold { get; set; }//처치시 획득 골드

        public Enemy(string Enemyname, int Hp, int Mp, int Atk, int Def, int Gold)
        {
            name = Enemyname;
            this.hp = Hp;
            this.mp = Mp;
            this.atk = Atk;
            this.def = Def;
            this.gold = Gold;
        }
    }

    internal class EnemyFactory
    {
        Enemy MeleeMinion = new Enemy("전사 미니언",47,0,12,1,21);
        Enemy CasterMinion = new Enemy("마법사 미니언", 29, 0, 24, 1, 14);
        Enemy SuperMinion = new Enemy("슈퍼 미니언", 160, 0, 47, 10, 60);
    }

    //internal class MeleeMinion : Enemy
    //{
    //    public MeleeMinion()
    //    {
    //        name = "전사 미니언";
    //        hp = 47;
    //        mp = 0;
    //        atk = 12;
    //        def = 1;
    //        gold = 21;
    //    }
    //}

    //internal class CasterMinion : Enemy
    //{
    //    public CasterMinion()
    //    {
    //        name = "마법사 미니언";
    //        hp = 29;
    //        mp = 0;
    //        atk = 24;
    //        def = 1;
    //        gold = 14;
    //    }
    //}

    //internal class SuperMinion : Enemy
    //{
    //    public SuperMinion()
    //    {
    //        name = "슈퍼 미니언";
    //        hp = 160;
    //        mp = 5;
    //        atk = 23;
    //        def = 10;
    //        gold = 60;
    //    }
    //}

    //internal class TurretTower : Enemy
    //{
    //    public TurretTower()
    //    {
    //        name = "포탑";
    //        hp = 500;
    //        mp = 5;
    //        atk = 18;
    //        def = 5;
    //        gold = 420;
    //    }
    //}
}
