namespace TRPG
{
    internal class New_BattleSystem
    {
        public BattleEnemies battleEnemies = new BattleEnemies();
        public Enemyskill enemyskill = new Enemyskill();
        public int StageWave = 1;//각 웨이브별 적을 불러오기 위한 변수
        public List<Enemy> enemies;
        //public Enemy Target;
        public int Turn = 1; //몇번째 턴인지 보여주기용

        bool gameover = false;
        public void BattleStart()
        {
            SetStage();
            while (enemies.Exists(e => e.hp > 0)) //살아있는 적이 있음.
            {
                PlayerTurn();
                if (gameover) return;
                gameover = EnemyTurn();
                if (gameover) return;
            }
            //살아있는 적이 없으면 반복문 빠져나옴.
            StageClear();
            bool b = ui_AskContinue();

            if (!b) return;
            //계속 진행
            BattleStart();
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
            GameManager.Instance.player.Gold += goldAdd;
            if (comment == 0) { Console.WriteLine("전장의 지배자!"); }
            else if (comment == 1) { Console.WriteLine("학살 중입니다."); }
            else if (comment == 2) { Console.WriteLine("도저히 막을 수 없습니다."); }
            else if (comment == 3) { Console.WriteLine("전설의 출현."); }
            else if (comment == 4) { Console.WriteLine("미쳐 날뛰고 있습니다."); }
            else { Console.WriteLine("전장의 화신!"); }
            Console.WriteLine($"골드 {goldAdd} 획득! 경험치 {expAdd} 획득!\n");
            GameManager.Instance.player.GainExp(expAdd);

        }
        public void PlayerTurn()
        {
            ui_Battle();
        }
        public bool EnemyTurn()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.hp > 0)
                {
                    enemyskill.EnemyAttack(enemy); //EnemyAttack() 공격 멘트가 나오고 이어지는 Damage() 에서 피해량 멘트가 나옴.
                }
                if (GameManager.Instance.player.Championclass.hp <= 0)
                {
                    return GameOver();
                }
            }
            return false;
        }
        public void SetStage()
        {
            EnemyFactory enemyFactory = new EnemyFactory();
            List<Enemy> enemies = new();
            switch (StageWave)
            {
                case 4:
                    enemies.Add(enemyFactory.SuperMinion());
                    goto case 3;
                case 3:
                    enemies.Add(enemyFactory.MeleeMinion());
                    goto case 2;
                case 2:
                    enemies.Add(enemyFactory.CasterMinion());
                    goto case 1;
                case 1:
                    enemies.Add(enemyFactory.MeleeMinion());
                    break;
                case 5:
                    enemies.Add(enemyFactory.TurretTower());
                    break;
            }
            this.enemies = enemies;
        }
        public bool GameOver()
        {
            GameManager.Instance.player.Championclass.hp = GameManager.Instance.player.Championclass.MaxHp;
            GameManager.Instance.player.Championclass.mp = GameManager.Instance.player.Championclass.MaxMp;
            UI ui = new(new List<UIElement>
                {
                    new("패배!")
                });

            ui.WriteAll("마을로 돌아갑니다.", 3000);
            return true;
        }

        public bool ui_AskContinue()
        {
            while (true)
            {
                UI ui = new UI(new List<UIElement>
                {
                    new($"협곡 - 스테이지 {StageWave} | 턴 {Turn}",null,ConsoleColor.Yellow),
                    new("[승리!]"),
                    new(),
                    new("[아래 동작 선택]"),
                    new("\t다음 스테이지",selectable: true),
                    new("\t회복하기",selectable: true),
                    new("\t더 도전하지 않고 돌아갑니다.",selectable: true),
                });

                ui.WriteAll();
                int input = ui.UserUIControl();

                if (input == 0)
                {
                    StageWave++;
                    return true;
                }
                else if (input == 1) New_Dungeon.ui_Rest();
                else
                {
                    return false;
                }
            }
        }
        public void ui_Battle()
        {
            bool attacked = false;
            while (true)
            {
                UI ui = new UI(new List<UIElement>
                {
                    new($"협곡 - 스테이지 {StageWave} | 턴 {Turn}",null,ConsoleColor.Yellow),
                    new("[전투 중!]"),
                    new(),
                    new("[눈 앞의 적]"),
                });
                var list = GetEnemyList(false);
                ui.AddElement(list); //리스트 보여주기
                ui.AddElement(new UIElement()); //빈칸
                ui.AddElement(new UIElement("[플레이어 상태]"));
                ui.AddElement(new UIElement($"Hp: {GameManager.Instance.player.Championclass.hp} / {GameManager.Instance.player.Championclass.MaxHp}"));
                ui.AddElement(new UIElement($"Mp: {GameManager.Instance.player.Championclass.mp} / {GameManager.Instance.player.Championclass.MaxMp}"));
                ui.AddElement(new UIElement());
                ui.AddElement(new UIElement("[행동 선택]"));
                ui.AddElement(new UIElement("\t공격하기", selectable: true, tip: "적을 공격합니다."));
                ui.AddElement(new UIElement("\t인벤토리", selectable: true, tip: "인벤토리를 열어 장비를 관리할 수 있습니다."));
                ui.AddElement(new UIElement());
                ui.AddElement(new UIElement("\t도망가기", selectable: true, tip: "전투를 포기하고 마을로 돌아갑니다."));

                ui.WriteAll();
                int input = ui.UserUIControl();

                switch (input)
                {
                    case 0:
                        attacked = ui_BattleAttack();
                        break;
                    case 1:
                        SampleClass.ShowInven();
                        break;
                    case 2:
                        //돔황챠
                        gameover = GameOver();
                        return;
                }
                if (attacked)
                {
                    Turn++;
                    return; //적을 공격했으니까 돌아가기.
                }
            }
        }

        public bool ui_BattleAttack()
        {
            bool attackedEnemy = false;
            while (true)
            {
                UI ui = new UI(new List<UIElement>
                {
                    new($"협곡 - 스테이지 {StageWave} | 턴 {Turn}",null,ConsoleColor.Yellow),
                    new("[공격 중!]"),
                    new(),
                    new("[공격할 적을 선택]"),
                    new("[눈 앞의 적]"),
                });

                var list = GetEnemyList(true);
                ui.AddElement(list); //리스트 보여주기
                ui.AddElement(new UIElement()); //빈칸
                ui.AddElement(new UIElement("[플레이어 상태]"));
                ui.AddElement(new UIElement($"Hp: {GameManager.Instance.player.Championclass.hp} / {GameManager.Instance.player.Championclass.MaxHp}"));
                ui.AddElement(new UIElement($"Mp: {GameManager.Instance.player.Championclass.mp} / {GameManager.Instance.player.Championclass.MaxMp}"));
                ui.AddElement(new UIElement());
                ui.AddElement(new UIElement("[행동 선택]"));
                ui.AddElement(new UIElement("\t다른 동작을 선택할래요", selectable: true, tip: "적을 공격하지 않고 다른 행동을 취합니다."));


                ui.WriteAll();
                int input = ui.UserUIControl();

                if (enemies.Count > input)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (enemies[i].hp > 0) continue;
                        else input++;
                    }
                }

                if (input < list.Count - 2) //스킬 선택
                {
                    attackedEnemy = ui_BattleAttackSkill(input); //적 공격하고 공격 여부 받아옴.
                    if (attackedEnemy) return true; //적을 공격했다면 돌아가기
                    else continue;//다른 적을 선택하기로 하고 돌아왔으니까 반복문 다시.
                }
                else return false; //다른 동작을 할거니까 돌아가기
            }
        }

        public bool ui_BattleAttackSkill(int enemyIndex)
        {
            string enemy = $"{enemies[enemyIndex].name}\t|\tHp: {enemies[enemyIndex].hp}";
            int playerMp = GameManager.Instance.player.Championclass.mp;
            int sklreqMpQ = GameManager.Instance.player.Championclass.Q_MANA_COST;
            int sklreqMpW = GameManager.Instance.player.Championclass.W_MANA_COST;
            int sklreqMpE = GameManager.Instance.player.Championclass.E_MANA_COST;
            int sklvlQ = GameManager.Instance.player.Championclass.SkillLevelQ;
            int sklvlW = GameManager.Instance.player.Championclass.SkillLevelW;
            int sklvlE = GameManager.Instance.player.Championclass.SkillLevelE;
            bool sklavblQ = sklvlQ != 0 && playerMp >= sklreqMpQ;
            bool sklavblW = sklvlW != 0 && playerMp >= sklreqMpW;
            bool sklavblE = sklvlE != 0 && playerMp >= sklreqMpE;

            UI ui = new UI(new List<UIElement>
            {
                new($"협곡 - 스테이지 {StageWave} | 턴 {Turn}",null,ConsoleColor.Yellow),
                new("[공격 중!]"),
                new(),
                new(enemy),
                new("[무슨 스킬로 공격?]"),
            });

            ui.AddElement(new UIElement()); //빈칸
            ui.AddElement(new UIElement("\t평타", selectable: true));
            ui.AddElement(new UIElement($"\tQ 스킬{(sklvlQ == 0 ? "" : $"[{sklvlQ}]")}", null, sklavblQ ? null : ConsoleColor.Red, selectable: sklavblQ));
            ui.AddElement(new UIElement($"\tW 스킬{(sklvlW == 0 ? "" : $"[{sklvlW}]")}", null, sklavblW ? null : ConsoleColor.Red, selectable: sklavblW));
            ui.AddElement(new UIElement($"\tE 스킬{(sklvlE == 0 ? "" : $"[{sklvlE}]")}", null, sklavblE ? null : ConsoleColor.Red, selectable: sklavblE));
            ui.AddElement(new UIElement());
            ui.AddElement(new UIElement("\t다른 적을 선택할래요", selectable: true, tip: "다른 적을 선택합니다."));


            ui.WriteAll();
            int input = ui.UserUIControl();

            //스킬 사용불가일때 입력받은 값에 1 더해서 인덱스 맞춤
            bool[] bools = new bool[] { sklavblQ, sklavblW, sklavblE };
            if (input != 0)
            {
                if (!sklavblQ && input == 1) input++;
                if (!sklavblW && input == 2) input++;
                if (!sklavblE && input == 3) input++;
            }

            switch (input)
            {
                case 0:
                    //평타
                    GameManager.Instance.player.Championclass.BaseAttack(enemies[enemyIndex]);
                    return true;
                case 1: //Q
                    GameManager.Instance.player.Championclass.UseSkill_Q(enemies[enemyIndex], enemies);
                    return true;
                case 2: //W
                    GameManager.Instance.player.Championclass.UseSkill_W(enemies[enemyIndex], enemies);
                    return true;
                case 3: //E
                    GameManager.Instance.player.Championclass.UseSkill_E(enemies[enemyIndex], enemies);
                    return true;
                case 4: //다른 적 선택
                    return false;
            }
            return false;
        }

        public List<UIElement> GetEnemyList(bool selectable)
        {
            List<UIElement> list = new List<UIElement>
            {
                new(new string('=', Console.WindowWidth))
            };

            foreach (Enemy enemy in enemies)
            {
                bool isEnemyAlive = enemy.hp > 0; //적 피가 0 초과면 살아있음 - true
                bool elementSelectable = selectable && isEnemyAlive; //선택할수있게 리스트를 요청해도 적이 죽었다면 선택 불가
                list.Add(new UIElement($"{enemy.name}\t|\tHp: {(isEnemyAlive ? enemy.hp : "사망")}", null, isEnemyAlive ? null : ConsoleColor.DarkGray, selectable: elementSelectable));
            }

            list.Add(new UIElement(new string('=', Console.WindowWidth)));

            //고정 2줄
            return list;
        }
    }
}
