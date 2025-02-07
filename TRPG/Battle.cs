using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class Battle
    {
        BattleEnemies battleEnemies = new BattleEnemies();
        private Enemyskill enemyskill = new Enemyskill();
    }
    internal class BattleSystem : Battle
    {
        int StageWave = 1;
        List<Enemy> enemies;
        public void BattleStart()
        {
            Console.WriteLine("적과 조우 했다!");

            while (true)
            {
                PlayerTurn();
                EnemyTurn();
            }
        }
        public void PlayerTurn() 
        { }
        public void EnemyTurn() 
        { }
        public void StageSet()
        {
            switch (StageWave)
            {
                case 1:
                    vatenemies = battleEnemies.wave1;
                    break;
                case 2:
                    battleEnemies.wave2;
                    break;
                case 3:
                    battleEnemies.wave3;
                    break;
                case 4:
                    battleEnemies.wave4;
                    break;
                case 5:
                    battleEnemies.wave5;
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
                enemyfactory.MeleeMinion,
            };

            wave1 = new List<Enemy>
            {
                enemyfactory.MeleeMinion,
                enemyfactory.CasterMinion
            };

            wave1 = new List<Enemy>
            {
                enemyfactory.MeleeMinion,
                enemyfactory.MeleeMinion,
                enemyfactory.CasterMinion
            };

            wave1 = new List<Enemy>
            {
                enemyfactory.SuperMinion,
                enemyfactory.MeleeMinion,
                enemyfactory.CasterMinion
            };

            wave1 = new List<Enemy>
            {
                enemyfactory.TurretTower
            };
        }
    }
}
