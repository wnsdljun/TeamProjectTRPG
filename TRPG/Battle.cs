using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class Battle
    {
        public BattleEnemies battleEnemies = new BattleEnemies();
        public Enemyskill enemyskill = new Enemyskill();
    }
    internal class BattleSystem : Battle
    {
        public int StageWave = 1;
        List<Enemy> enemies;
        public void BattleStart()
        {
            Console.WriteLine("적이 나타났다!");
            StageSet();
            while (true)
            {
                PlayerTurn();
                EnemyTurn();
            }
        }
        public void PlayerTurn()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].hp > 0)
                {
                    Console.WriteLine($"{i + 1}. {enemies[i].name} | HP: {enemies[i].hp}");
                }
            }   
        }
        public void EnemyTurn()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.hp > 0)
                {
                    enemyskill.EnemyAttack(enemy); //EnemyAttack() 공격 멘트가 나오고 이어지는 Damage() 에서 피해량 멘트가 나옴.
                }
            }
        }
        public void StageSet()
        {

            switch (StageWave)
            {
                case 1:
                    enemies = battleEnemies.wave1;
                    break;
                case 2:
                    enemies = battleEnemies.wave2;
                    break;
                case 3:
                    enemies = battleEnemies.wave3;
                    break;
                case 4:
                    enemies = battleEnemies.wave4;
                    break;
                case 5:
                    enemies = battleEnemies.wave5;
                    break;
            }
        }
    }
    internal class BattleEnemies
    {
        EnemyFactory enemyfactory = new EnemyFactory();
        public List<Enemy> wave1 { get; set; }
        public List<Enemy> wave2 { get; set; }
        public List<Enemy> wave3 { get; set; }
        public List<Enemy> wave4 { get; set; }
        public List<Enemy> wave5 { get; set; }

        public BattleEnemies()
        {
            wave1 = new List<Enemy>
            {
                enemyfactory.MeleeMinion(),
            };

            wave1 = new List<Enemy>
            {
                enemyfactory.MeleeMinion(),
                enemyfactory.CasterMinion()
            };

            wave1 = new List<Enemy>
            {
                enemyfactory.MeleeMinion(),
                enemyfactory.MeleeMinion(),
                enemyfactory.CasterMinion()
            };

            wave1 = new List<Enemy>
            {
                enemyfactory.SuperMinion(),
                enemyfactory.MeleeMinion(),
                enemyfactory.CasterMinion()
            };

            wave1 = new List<Enemy>
            {
                enemyfactory.TurretTower()
            };
        }
    }
}
