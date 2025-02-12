namespace TRPG
{
    //internal class Battle
    //{
    //    public BattleEnemies battleEnemies = new BattleEnemies(); 
    //    public Enemyskill enemyskill = new Enemyskill();
    //}
    internal class BattleSystem //: Battle
    {
        //public BattleEnemies battleEnemies = new BattleEnemies();
        public Enemyskill enemyskill = new Enemyskill();
        public int StageWave = 1;//각 웨이브별 적을 불러오기 위한 변수
        public bool bool_stage = false;
        public List<Enemy> enemies;
        public Enemy Target;
        public BattleEnemies battleEnemies;
        public void BattleStart(bool bool_stage)
        {
            Console.WriteLine("적이 나타났습니다. \n");
            if (bool_stage)
            {
                StageWave= 1;
                battleEnemies = new BattleEnemies();
            }
            StageSet(battleEnemies, StageWave);
            while (enemies.Exists(e => e.hp > 0))
            {
                PlayerTurn();
                EnemyTurn();
            }
            if (enemies.Exists(e => e.hp > 0) == false)
            {
                StageClear(ref bool_stage);
            }
        }
        public void PlayerTurn()
        {
            bool Turn = true;
            while (Turn)
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
                    $"HP: {GameManager.Instance.selectedChampion.hp} " +
                    $"MP: {GameManager.Instance.selectedChampion.mp}" +
                    "\n1. 전투하기" +
                    "\n2. 도망가기");
                int input;
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)//플레이어의 행동을 받아오는 부분
                    {
                        case 1://스킬 선택 메소드
                            PlayerAttack();
                            Turn = false;
                            break;
                        case 2://도망가기 메소드
                            GameManager.Instance.dungeon.DungeonEnd();
                            Turn = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ResetColor();
                }
            }
        }

        public void PlayerAttack()
        {
            bool Turn = true;
            while (Turn)
            {
                Console.WriteLine("1. 기본 공격" +
                "\n2. Q스킬" +
                "\n3. W스킬" +
                "\n4. E스킬");
                int input;
                Enemy enemy;
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1:
                            TargetingReset();
                            //enemy = Targeting();
                            GameManager.Instance.selectedChampion.BaseAttack(Target);
                            Turn = false;
                            break;
                        case 2:
                            if (GameManager.Instance.selectedChampion.SkillLevelQ != 0)
                            {
                                TargetingReset();
                                //enemy = Targeting();
                                GameManager.Instance.selectedChampion.UseSkill_Q(Target, enemies);
                                Turn = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("스킬을 배우지 않았습니다.");
                                Console.ResetColor();
                            }
                            break;
                        case 3:
                            if (GameManager.Instance.selectedChampion.SkillLevelW != 0)
                            {
                                TargetingReset();
                                GameManager.Instance.selectedChampion.UseSkill_W(Target, enemies);
                                Turn = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("스킬을 배우지 않았습니다.");
                                Console.ResetColor();
                            }
                            break;
                        case 4:
                            if (GameManager.Instance.selectedChampion.SkillLevelE != 0)
                            {
                                TargetingReset();
                                GameManager.Instance.selectedChampion.UseSkill_E(Target, enemies);
                                Turn = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("스킬을 배우지 않았습니다.");
                                Console.ResetColor();
                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ResetColor();
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
                if (GameManager.Instance.player.Championclass.hp <= 0)
                {
                    GameOver();
                    break;
                }
            }
        }
        public Enemy Targeting()
        {
            Console.WriteLine("공격할 적을 선택하세요.");
            int target;
            if (int.TryParse(Console.ReadLine(), out target) && enemies.Count >= target && target > 0)
            {
                if (enemies[target - 1].hp >= 0)
                {
                    Enemy Target = enemies[target - 1];//지정한 적에게 피해를 주기 위한 지정
                    return Target;
                }
                else if (enemies[target - 1].hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("이미 죽은 적입니다.");
                    Console.ResetColor();
                    return null;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ResetColor();
                    return null;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("잘못된 입력입니다.");
                Console.ResetColor();
                return null;
            }

        }
        public void TargetingReset()
        {
            while (true)
            {
                Target = Targeting();
                if (Target != null)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        public void GameOver()
        {
            StageWave = 1;
            GameManager.Instance.player.Gold /= 2;
            Console.WriteLine("패배….");
            Console.WriteLine($"골드를 절반 잃었습니다. 남은 골드는 {GameManager.Instance.player.Gold}입니다.");
            Console.WriteLine("엔터를 누르시면 메인 메뉴로 돌아갑니다.");
            Console.ReadLine();
            GameManager.Instance.MainMenu();
        }
        public void StageClear(ref bool bool_stage)
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
            GameManager.Instance.player.Gold += goldAdd;
            if (comment == 0) { Console.WriteLine("전장의 지배자!"); }
            else if (comment == 1) { Console.WriteLine("학살 중입니다."); }
            else if (comment == 2) { Console.WriteLine("도저히 막을 수 없습니다."); }
            else if (comment == 3) { Console.WriteLine("전설의 출현."); }
            else if (comment == 4) { Console.WriteLine("미쳐 날뛰고 있습니다."); }
            else { Console.WriteLine("전장의 화신!"); }
            StageWave++;
            bool_stage = true;
            Console.WriteLine($"골드 {goldAdd} 획득! 경험치 {expAdd} 획득!\n");
            GameManager.Instance.player.GainExp(expAdd);
            if (StageWave == 6)
            {
                DungeonClear();
            }
            else
            {

                GameManager.Instance.dungeon.DungeonForward();
            }

        }
        public void DungeonClear()
        {
            StageWave = 1;
            Console.WriteLine("승리!");
            Console.WriteLine("엔터를 누르시면 메인 메뉴로 돌아갑니다.");
            Console.ReadLine();
            GameManager.Instance.MainMenu();
        }
        public void StageSet(BattleEnemies battleEnemies, int stageWave)
        {
            switch (stageWave)//웨이브 마다 리스트에 들어가는 적 배치
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

                enemyfactory.MeleeMinion()
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
