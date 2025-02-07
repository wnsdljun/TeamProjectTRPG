﻿using System;
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
        public int StageWave = 1;//각 웨이브별 적을 불러오기 위한 변수
        List<Enemy> enemies;
        public void BattleStart()
        {
            Console.WriteLine("적이 나타났다! \n");
            StageSet();
            while (true)
            {
                PlayerTurn();
                EnemyTurn();
            }
        }
        public void PlayerTurn()
        {
            int input = 0;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].hp > 0)
                {
                    Console.WriteLine($"{i + 1}. {enemies[i].name} | HP: {enemies[i].hp}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"{i + 1}. {enemies[i].name} |  사망");//사망한 적은 회색으로 표시
                    Console.ResetColor();
                }
            }
            Console.WriteLine("\n\n플레이어 상태" +
                "\n1. 전투하기" +
                "\n2. 인벤토리" +
                "\n3. 도망가기");

            switch (input)//플레이어의 행동을 받아오는 부분
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ResetColor();
                    break;
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
        public void GameOver()
        {
            Console.WriteLine("패배…");
        }
        public void StageClear()
        {
            Console.WriteLine("전장의 지배자!");
            StageWave++;
        }
        public void DungeonClear()
        {
            Console.WriteLine("승리!");
        }
        public void StageSet()
        {

            switch (StageWave)//웨이브 마다 리스트에 들어가는 적 배치
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

        public BattleEnemies()// 웨이브별 적 배치도
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
