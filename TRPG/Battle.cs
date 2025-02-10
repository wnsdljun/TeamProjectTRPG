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
        public int StageWave = 1;//각 웨이브별 적을 불러오기 위한 변수
        List<Enemy> enemies;
        public void BattleStart()
        {
            Console.WriteLine("적이 나타났다! \n");
            StageSet();
            while (enemies.Exists(e => e.hp >0))
            {
                PlayerTurn();
                EnemyTurn();
            }
            if (enemies.Exists(e => e.hp > 0) == false)
            {
                StageClear();
            }
            else
            {
                GameOver();
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
                else
                {
                    Console.WriteLine($"{i + 1}. {enemies[i].name} |  사망.", ConsoleColor.Gray);//사망한 적은 회색으로 표시
                }
            }
            Console.WriteLine("\n플레이어 상태\n" +
                "\n1. 전투하기" +
                "\n2. 인벤토리" +
                "\n3. 도망가기");
            int input = int.Parse(Console.ReadLine());
            switch (input)//플레이어의 행동을 받아오는 부분
            {
                case 0://스킬 선택 메소드
                    Console.WriteLine("어떤 적을 공격하시겠습니까?");
                    int target = int.Parse(Console.ReadLine());
                    Enemy Target = enemies[target - 1];//지정한 적에게 피해를 주기 위한 지정
                    Console.WriteLine($"{Target.name}은 100의 피해를 입었다!");//디버깅용 임시 스크립트
                    Target.hp -= 500;
                    break;
                case 1://인벤토리 메소드
                    break;
                case 2://도망가기 메소드
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ResetColor();
                    break;//잘못된 입력 넣으면 턴이 넘어감
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
                //플레이어가 죽었을 때 GameOver() 메소드 호출
            }
        }
        public void GameOver()
        {
            Console.WriteLine("패배….");
        }
        public void StageClear()
        {
            Random random = new Random();
            int goldAdd = 0;
            int expAdd = 0;
            int comment = random.Next(0, 6);
            foreach (var enemy in enemies)
            {
                goldAdd += enemy.gold;
                expAdd += enemy.exp;
            }
            if (comment == 0) { Console.WriteLine("전장의 지배자!"); }
            else if (comment == 1) { Console.WriteLine("학살 중입니다."); }
            else if (comment == 2) { Console.WriteLine("도저히 막을 수 없습니다."); }
            else if (comment == 3) { Console.WriteLine("전설의 출현."); }
            else if (comment == 4) { Console.WriteLine("미쳐 날뛰고 있습니다."); }
            else { Console.WriteLine("전장의 화신!"); }
            StageWave++;
            Console.WriteLine($"골드 {goldAdd} 획득, 경험치 {expAdd} 획득\n");
            if (StageWave == 6)
            {
                DungeonClear();
            }
            else
            {
                Dungeon dungeon = new Dungeon();
                dungeon.DungeonForward();
            }

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

            wave2 = new List<Enemy>
            {
                enemyfactory.MeleeMinion(),
                enemyfactory.CasterMinion()
            };

            wave3 = new List<Enemy>
            {
                enemyfactory.MeleeMinion(),
                enemyfactory.MeleeMinion(),
                enemyfactory.CasterMinion()
            };

            wave4 = new List<Enemy>
            {
                enemyfactory.SuperMinion(),
                enemyfactory.MeleeMinion(),
                enemyfactory.CasterMinion()
            };

            wave5 = new List<Enemy>
            {
                enemyfactory.TurretTower()
            };
        }
    }
}
