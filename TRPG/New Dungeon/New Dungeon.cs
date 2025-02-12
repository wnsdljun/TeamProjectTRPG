namespace TRPG
{
    internal class New_Dungeon
    {
        public New_BattleSystem battleSystem;
        public New_Dungeon()
        {
            battleSystem = new New_BattleSystem();
        }
        public void ui_Lobby()
        {
            UI ui_DungeonLobby = new UI(new List<UIElement>
            {
                new("협곡에 오신 것을 환영합니다."),
                new("앞으로 나아가시겠습니까?"),
                new(),
                new("1. 들어가기",selectable: true ,tip: "협곡에 입장합니다."),
                new("2. 나가기",selectable: true ,tip: "마을로 돌아갑니다.")
            });

            UI ui_DungeonLobbyExit = new UI(new List<UIElement>
            {
                new("마을로 돌아갑니다."),
            });

            ui_DungeonLobby.WriteAll();
            int input = ui_DungeonLobby.UserUIControl();

            if (input == 0)
            {
                GameManager.Instance.dungeon.battleSystem = new();
                battleSystem.BattleStart();
            }

            ui_DungeonLobbyExit.WriteAll("마을로 돌아가는중...", 5900);
            return;
        }

        public static void ui_Rest()
        {
            //휴식하기
            int restCost = 100;
            bool canRest = GameManager.Instance.player.Gold >= restCost;
            UIElement temp = new UIElement("1. 네", null, canRest ? null : ConsoleColor.Red, selectable: true, tip: canRest ? $"{restCost} 골드를 지불하여 체력을 모두 회복합니다." : "골드가 부족합니다.");
            while (true)
            {
                UI ui_Rest = new UI(new List<UIElement>
                {
                    new("골드를 지불해 체력을 회복시킵니다."),
                    new(),
                    new("회복하시겠습니까?"),
                    new($"[비용: {restCost} 골드]"),
                    new(),
                    temp,
                    new("2. 아니오",selectable: true ,tip: "회복하지 않습니다.")
                });

                ui_Rest.WriteAll();
                ui_Rest.WriteAtBottom("골드가 부족하여 쉴 수 없습니다.");
                int input = ui_Rest.UserUIControl();

                if (input == 1) return;
                else
                {
                    if (canRest) //돈이 충분. 쉬기
                    {
                        GameManager.Instance.player.Gold -= restCost;
                        GameManager.Instance.player.Championclass.hp = GameManager.Instance.player.Championclass.MaxHp;
                        GameManager.Instance.player.Championclass.mp = GameManager.Instance.player.Championclass.MaxMp;

                        ui_Rest.WriteAll("충분히 쉰 것 같다.", 3000);
                        return;
                    }
                    else
                    {
                        new UI(new List<UIElement>
                        {
                            new("돈 없으면 돌아가!")
                        }).WriteAll("돌아가는 중...", 2500);
                        return;
                    }
                }
            }//while 끝
        }

        public void DungeonEnd()
        {

        }
    }
}
