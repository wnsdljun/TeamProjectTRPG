namespace TRPG
{
    internal class New_BattleSystem
    {
        public BattleEnemies battleEnemies = new BattleEnemies();
        public Enemyskill enemyskill = new Enemyskill();
        public int StageWave = 1;//각 웨이브별 적을 불러오기 위한 변수
        public List<Enemy> enemies;
        public Enemy Target;
        public int Turn = 1; //몇번째 턴인지 보여주기용

        public void BattleStart()
        {
            while (enemies.Exists(e => e.hp > 0)) //살아있는 적이 있음.
            {
                PlayerTurn();
                EnemyTurn();
            }
            //살아있는 적이 없으면 반복문 빠져나옴.

        }

        public void PlayerTurn()
        {
            ui_Battle();
        }
        public void EnemyTurn()
        {

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
                ui.AddElement(new UIElement($"Hp: {GameManager.Instance.selectedChampion.hp} / {GameManager.Instance.selectedChampion.MaxHp}"));
                ui.AddElement(new UIElement($"Mp: {GameManager.Instance.selectedChampion.mp} / {GameManager.Instance.selectedChampion.MaxMp}"));
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
                        break;
                }
                if (attacked) return; //적을 공격했으니까 돌아가기.
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
                ui.AddElement(new UIElement($"Hp: {GameManager.Instance.selectedChampion.hp} / {GameManager.Instance.selectedChampion.MaxHp}"));
                ui.AddElement(new UIElement($"Mp: {GameManager.Instance.selectedChampion.mp} / {GameManager.Instance.selectedChampion.MaxMp}"));
                ui.AddElement(new UIElement());
                ui.AddElement(new UIElement("[행동 선택]"));
                ui.AddElement(new UIElement("\t다른 동작을 선택할래요", selectable: true, tip: "적을 공격하지 않고 다른 행동을 취합니다."));


                ui.WriteAll();
                int input = ui.UserUIControl();

                if (input < list.Count - 2) //스킬 선택
                {
                    attackedEnemy = ui_BattleAttackSkill(list[input], input); //적 공격하고 공격 여부 받아옴.
                    if (attackedEnemy) return true; //적을 공격했다면 돌아가기
                    else continue;//다른 적을 선택하기로 하고 돌아왔으니까 반복문 다시.
                }
                else return false; //다른 동작을 할거니까 돌아가기
            }
        }

        public bool ui_BattleAttackSkill(UIElement element, int enemyIndex)
        {
            UI ui = new UI(new List<UIElement>
            {
                new($"협곡 - 스테이지 {StageWave} | 턴 {Turn}",null,ConsoleColor.Yellow),
                new("[공격 중!]"),
                new(),
                element,
                new("[무슨 스킬로 공격?]"),
            });

            ui.AddElement(new UIElement()); //빈칸
            ui.AddElement(new UIElement("\t평타"));
            ui.AddElement(new UIElement("\tQ 스킬"));
            ui.AddElement(new UIElement("\tW 스킬"));
            ui.AddElement(new UIElement("\tE 스킬"));
            ui.AddElement(new UIElement());
            ui.AddElement(new UIElement("\t다른 적을 선택할래요", selectable: true, tip: "다른 적을 선택합니다."));


            ui.WriteAll();
            int input = ui.UserUIControl();

            switch (input)
            {
                case 0:
                    //평타
                    return true;
                case 1: //Q

                    return true;
                case 2: //W

                    return true;
                case 3: //E

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
