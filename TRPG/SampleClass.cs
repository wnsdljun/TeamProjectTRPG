namespace TRPG
{
    internal class SampleClass
    {
        public static void ShowSample2()
        {
            UI ui = new UI(new List<UIElement>
            {
                new("텍스 트"),
                new("샘플?입니다.",ConsoleColor.Green, ConsoleColor.Red),
                new("색을지정할수있는", new List<UIColorIndex>
                {
                    new(1, ConsoleColor.Red, ConsoleColor.Green),
                    new(2, ConsoleColor.Green, ConsoleColor.Red)
                }),
                new("색을지정할수있는선택가능한", new List<UIColorIndex>
                {
                    new(7, ConsoleColor.Red, ConsoleColor.Green),
                    new(8, ConsoleColor.Green, ConsoleColor.Red)
                }, selectable: true,tip: "선택가능한첫번째의설명"),
                new("그냥선택만되는", tip: "그냥선택가능한두번째의설명", selectable: true)

            });

            ui.WriteAll();
            ui.UserUIControl();
        }

        public static void SampleScene()
        {
            //최초 시작 화면의 샘플 씬
            string playerName = "";

            while (true)
            {
                UI ui_Welcome = new UI(new List<UIElement>
                {
                    new("소환사의 협곡에 오신 것을 환영합니다."),
                    new("닉네임을 입력해 주십시오.")
                });

                ui_Welcome.WriteAll();
                playerName = ui_Welcome.GetUserInput("닉네임으로 사용할 문자열 입력을 받습니다.");

                UI ui_ConfirmNick = new UI(new List<UIElement>
                {
                    new($"닉네임을 {playerName}(으)로 하시겠습니까?"),
                    new(),
                    new("네",selectable:true, tip:$"{playerName}을 닉네임으로 확정합니다."),
                    new("아니오",selectable:true, tip:"닉네임을 다시 입력합니다."),
                });


                ui_ConfirmNick.WriteAll();
                int input = ui_ConfirmNick.UserUIControl();

                if (input == 0) break; //0번 선택시 - 네

            }
        ////////////////////////////////////////////////////

        //챔피언 선택 화면
        myloc:
            Champion selectedChampion;

            while (true)
            {
                UI ui_SelectChmp = new UI(new List<UIElement>
                {
                    new("챔피언을 선택하여 주십시오."),
                    new(),
                    new("1. 티모",selectable: true ,tip: "버섯깔기!"),
                    new("2. 미스 포춘",selectable: true ,tip: "미스 포춘 쿠키"),
                    new("3. 블라디미르",selectable: true ,tip: "블라디미르")
                });

                ui_SelectChmp.WriteAll();
                int input = ui_SelectChmp.UserUIControl();

                selectedChampion = input switch
                {
                    0 => new Teemo(),
                    1 => new MissFortune(),
                    2 => new Vladimir(),
                    _ => throw new Exception()
                };

                UI ui_ConfirmChmp = new UI(new List<UIElement>
                {
                    new($"{selectedChampion.Name}(을)를 선택하셨습니다."),
                    new(),
                    new($"===== {selectedChampion.Name} 스킬 설명 ====="),
                    new(selectedChampion.skillInfoQ),
                    new(selectedChampion.skillInfoQDetail),
                    new(selectedChampion.skillInfoW),
                    new(selectedChampion.skillInfoWDetail),
                    new(selectedChampion.skillInfoE),
                    new(selectedChampion.skillInfoEDetail),
                    new("================================"),
                    new(),
                    new("이 챔피언을 사용하시겠습니까?"),
                    new(),
                    new("네",selectable: true ,tip: $"{selectedChampion.Name}을(를) 챔피언으로 확정합니다."),
                    new("아니오",selectable: true ,tip: "챔피언을 다시 선택합니다."),
                });

                ui_ConfirmChmp.WriteAll();
                input = ui_ConfirmChmp.UserUIControl();

                if (input == 0) break;
            }


            // 챔피언 확정 멘트

            //

            //Player player = new Player();
            //Inven inven = new Inven(GameManager);
            //Shop shop = new Shop();

            ////메인메뉴?
            //bool exitMenu = false;
            //while (!exitMenu)
            //{
            //    UI ui_MainMenu = new UI(new List<UIElement>
            //    {
            //        new("메인 메뉴를 선택하세요"),
            //        new(),
            //        new("1. 스테이터스 확인",selectable: true ,tip: ""),
            //        new("2. 인벤토리 확인",selectable: true ,tip: ""),
            //        new("3. 상점",selectable: true ,tip: ""),
            //        new("4. 협곡",selectable: true ,tip: ""),
            //        new(),
            //        new("종료",selectable: true ,tip: "")
            //    });
            //    ui_MainMenu.WriteAll();
            //    int menuChoice = ui_MainMenu.UserUIControl();

            //    switch (menuChoice)
            //    {
            //        case 0:
            //            Program.ShowStatus(player);
            //            break;
            //        case 1:
            //            inven.ShowInven(player);
            //            break;
            //        case 2:
            //            shop.ShowShop(player, inven);
            //            break;
            //        case 3:
            //            Console.Clear();
            //            Console.WriteLine("협곡 기능은 아직 구현되지 않았습니다.");
            //            Console.WriteLine("엔터 키를 눌러 메인 메뉴로 돌아갑니다.");
            //            Console.ReadLine();
            //            break;
            //        case 4:
            //            //goto myloc;
            //            exitMenu = true;
            //            break;
            //        default:
            //            Console.WriteLine("잘못된 입력입니다. 엔터 키를 눌러 메인 메뉴로 돌아갑니다.");
            //            Console.ReadLine();
            //            break;
            //    }



            //}// while 의 끝

        }

        public static void SampleLobby()
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

            if (input == 1)
            {
                ui_DungeonLobbyExit.WriteAll("마을로 돌아가는중...", 2);
                return;
            }
            //else// battleSystem.BattleStart();






                
            //휴식하기
            UIElement temp = new UIElement("1. 네", selectable: true, tip: "{비용} 골드를 지불하여 체력을 모두 회복합니다.");
            while (true)
            {
                UI ui_Rest = new UI(new List<UIElement>
                {
                    new("골드를 지불해 체력을 회복시킵니다."),
                    new(),
                    new("회복하시겠습니까?"),
                    new("[비용: {비용} 골드"),
                    new(),
                    temp,
                    new("2. 아니오",selectable: true ,tip: "회복하지 않습니다.")
                });

                ui_Rest.WriteAll();
                input = ui_Rest.UserUIControl();

                if (input == 1) return;
                else
                {
                    if (GameManager.Instance.player.Gold <= 100) //돈이 부족함
                    {
                        temp = new UIElement("1. 네", Console.BackgroundColor, ConsoleColor.Red, selectable: true, tip: "골드가 부족합니다.");
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                        return;
                    }
                }
            }//while 끝
        }
    }
}
