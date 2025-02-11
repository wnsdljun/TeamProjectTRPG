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

        public static void ShowInven()
        {
            while (true)
            {
                UI ui_ShowInven = new UI(new List<UIElement>
                {
                    new("인벤토리",Console.BackgroundColor,ConsoleColor.Yellow),
                    new("보유 중인 아이템을 관리할 수 있습니다."),
                    new()
                });

                ui_ShowInven.AddElement(GetInvenListUI(GameManager.Instance.inventoryItems, false));
                ui_ShowInven.AddElement(new UIElement());
                ui_ShowInven.AddElement(new UIElement("장착관리", selectable: true, tip: "아이템을 장착하거나 장착 해제합니다."));
                ui_ShowInven.AddElement(new UIElement("나가기", selectable: true, tip: "돌아갑니다."));

                ui_ShowInven.WriteAll();
                int input = ui_ShowInven.UserUIControl();

                if (input == 0) InvenManage(); //장착관리
                else return;
            }


        }
        public static void InvenManage()
        {
            while (true)
            {
                UI ui_ShowInven = new UI(new List<UIElement>
                {
                    new("인벤토리 - 장착 관리",Console.BackgroundColor,ConsoleColor.Yellow),
                    new("장착하거나 해제할 아이템을 선택해 주세요."),
                    new()
                });

                List<UIElement> itemList = GetInvenListUI(GameManager.Instance.inventoryItems, true);

                ui_ShowInven.AddElement(itemList);
                ui_ShowInven.AddElement(new UIElement());
                ui_ShowInven.AddElement(new UIElement("나가기", selectable: true, tip: "돌아갑니다."));

                ui_ShowInven.WriteAll();
                int input = ui_ShowInven.UserUIControl();

                if (input < itemList.Count - 3) //아이템을 선택, 고정 크기 3만큼 빼서 indexOutOdRange 해결
                {
                    if (GameManager.Instance.inventoryItems[input].Installed)
                    {
                        GameManager.Instance.inventoryItems[input].Installed = false;
                        GameManager.Instance.inven.StatusSetting(GameManager.Instance.inventoryItems[input], '-');
                    }
                    else
                    {
                        GameManager.Instance.inventoryItems[input].Installed = true;
                        GameManager.Instance.inven.StatusSetting(GameManager.Instance.inventoryItems[input], '+');
                    }
                }
                else //나가기를 선택
                {
                    return;
                }
            }
        }
        public static List<UIElement> GetInvenListUI(List<InvenItem> inven_list, bool selectable)
        {
            var list = new List<UIElement>
            {
                new("[아이템 목록]"),
                new(new string('=', Console.WindowWidth))
            };

            foreach (var x in inven_list)
            {
                IStatus status = x;
                UIElement elem = new UIElement
                    (
                    $"[{(x.Installed ? "E" : " ")}]{x.itemName,-14}{x.itemType,-10}{x.itemPrice,-8}{status.hp,-6}{status.mp,-6}{status.atk,-8}{status.def,-6}",
                    Console.BackgroundColor,
                    x.Installed ? ConsoleColor.Red : Console.ForegroundColor,
                    selectable: selectable
                    );

                list.Add(elem);

            }
            list.Add(new UIElement(new string('=', Console.WindowWidth)));

            return list;
        }


        public static void ShowShop()
        {
            while (true)
            {
                UI ui_ShowShop = new UI(new List<UIElement>
                {
                    new("상점",Console.BackgroundColor,ConsoleColor.Yellow),
                    new("필요한 아이템을 얻을 수 있는 상점입니다."),
                    new()
                });

                ui_ShowShop.AddElement(GetShopListUI(GameManager.Instance.items_list_shop, false));
                ui_ShowShop.AddElement(new UIElement());
                ui_ShowShop.AddElement(new UIElement("아이템 구매", selectable: true, tip: "아이템을 구매합니다."));
                ui_ShowShop.AddElement(new UIElement("나가기", selectable: true, tip: "돌아갑니다."));

                ui_ShowShop.WriteAll();
                int input = ui_ShowShop.UserUIControl();

                if (input == 0) buyShop(); //구매모드
                else return;
            }
        }
        public static void buyShop()
        {
            while (true)
            {
                UI ui_ShowShop = new UI(new List<UIElement>
                {
                    new("상점 - 아이템 구입",Console.BackgroundColor,ConsoleColor.Yellow),
                    new("구매하실 아이템을 선택 후 엔터"),
                    new(),
                    new($"[보유한 골드] : {GameManager.Instance.player.Gold} G"),
                    new()
                });

                List<UIElement> itemList = GetShopListUI(GameManager.Instance.items_list_shop, true);
                ui_ShowShop.AddElement(itemList);
                ui_ShowShop.AddElement(new UIElement());
                ui_ShowShop.AddElement(new UIElement("나가기", selectable: true, tip: "돌아갑니다."));

                ui_ShowShop.WriteAll();
                int input = ui_ShowShop.UserUIControl();

                if (input < itemList.Count - 3) //아이템을 선택, 고정 크기 3만큼 빼서 indexOutOdRange 해결
                {
                    ShopItem shopItem = GameManager.Instance.items_list_shop[input];
                    if (!shopItem.purchase)
                    {
                        if (shopItem.itemPrice <= GameManager.Instance.player.Gold)
                        {
                            BuyShopConfirm(shopItem);
                            continue;
                        }
                        Console.SetCursorPosition(0, Console.WindowHeight - 2);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, Console.WindowHeight - 2);
                        Console.Write("돈 더 내놔!");
                        Thread.Sleep(2500);
                        continue;
                    }
                    Console.SetCursorPosition(0, Console.WindowHeight - 2);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.WindowHeight - 2);
                    Console.Write("이미 구입한 아이템입니다.");
                    Thread.Sleep(2500);
                    continue;


                }
                else //나가기를 선택
                {
                    return;
                }
            }
        }
        public static List<UIElement> GetShopListUI(List<ShopItem> items_list_shop, bool selectable)
        {
            var list = new List<UIElement>
            {
                new("[아이템 목록]"),
                new(new string('=', Console.WindowWidth))
            };

            foreach (var x in items_list_shop)
            {
                IStatus status = x;
                UIElement elem = new UIElement
                    (
                    $"{(x.purchase ? "[구매완료]" : x.itemPrice > GameManager.Instance.player.Gold ? "[너무 비쌉니다!]" : "")}{x.itemName,-14}{x.itemType,-10}{x.itemPrice,-8}{status.hp,-6}{status.mp,-6}{status.atk,-8}{status.def,-6}",
                    Console.BackgroundColor,
                    x.purchase || x.itemPrice > GameManager.Instance.player.Gold ? ConsoleColor.Red : Console.ForegroundColor,
                    selectable: selectable
                    );

                list.Add(elem);

            }
            list.Add(new UIElement(new string('=', Console.WindowWidth)));

            return list;
        }

        public static void BuyShopConfirm(ShopItem Buyitem)
        {
            UI ui_ShowShop = new UI(new List<UIElement>
                {
                    new("상점 - 아이템 구입 확인",Console.BackgroundColor,ConsoleColor.Yellow),
                    new(),
                    new("아래 아이템을 선택하셨습니다. 구매를 확정하시겠습니까?"),
                    new(),
                    new($"{Buyitem.itemName,-14}{Buyitem.itemType,-10}{Buyitem.itemPrice,-8}{Buyitem.hp,-6}{Buyitem.mp,-6}{Buyitem.atk,-8}{Buyitem.def,-6}"),
                    new(),
                    new($"거래 후 [ {GameManager.Instance.player.Gold - Buyitem.itemPrice} G ] 만큼 남습니다."),
                    new(),
                    new("네",selectable:true),
                    new("아니오",selectable:true),
                });

            ui_ShowShop.WriteAll();
            int input = ui_ShowShop.UserUIControl();

            if (input == 1) return;
            else
            {
                GameManager.Instance.player.Gold -= Buyitem.itemPrice;
                Buyitem.purchase = true;
                GameManager.Instance.inven.ItemAdd(false, Buyitem.itemName, Buyitem.itemPrice, Buyitem.itemType, Buyitem.hp, Buyitem.mp, Buyitem.atk, Buyitem.def);
            }
        }
    }
}
