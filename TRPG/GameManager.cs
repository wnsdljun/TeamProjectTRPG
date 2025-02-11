using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class GameManager
    {
        public Player player;
        public Inven inven;
        public Shop shop;
        public Champion selectedChampion;
        public Dungeon dungeon = new Dungeon();
        public List<InvenItem> inventoryItems;
        public List<ShopItem> items_list_shop;
        private static GameManager instance = null;

        public string playerName = "";


        public static GameManager Instance
        {
            get
            {
                // null 체크 후 새 인스턴스 생성
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        // private 생성자
        private GameManager()
        {
            inventoryItems = new List<InvenItem>();
            items_list_shop = new List<ShopItem>();
            player = new Player();
            shop = new Shop();
            inven = new Inven();
            
            // 다른 초기화 코드
        }

        public void Chi_Champion()
        {
            //플레이어 선택 화먀
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


            player.GetPlayer(playerName, selectedChampion);
            Console.WriteLine($"\n플레이어 '{this.player.PlayerName}'이(가) '{this.player.Championclass.Name}' 챔피언으로 확정되었습니다!");




            //플레이어랑 챔피언을 인스턴스를 만들어야지
            //player =new Player(playerName, selectedChampion);
        }

        public void MainMenu()
        {
            //Player player = new Player();
            //Inven inven = new Inven();
            //Shop shop = new Shop();

            //메인메뉴?
            bool exitMenu = false;
            while (!exitMenu)
            {
                UI ui_MainMenu = new UI(new List<UIElement>
                {
                    new("메인 메뉴를 선택하세요"),
                    new(),
                    new("1. 스테이터스 확인",selectable: true ,tip: ""),
                    new("2. 인벤토리 확인",selectable: true ,tip: ""),
                    new("3. 상점",selectable: true ,tip: ""),
                    new("4. 협곡",selectable: true ,tip: ""),
                    new(),
                    new("종료",selectable: true ,tip: "")
                });
                ui_MainMenu.WriteAll();
                int menuChoice = ui_MainMenu.UserUIControl();

                switch (menuChoice)
                {
                    case 0:
                        Program.ShowStatus(player);
                        break;
                    case 1:
                        inven.ShowInven(player);
                        break;
                    case 2:
                        shop.ShowShop(player, inven);
                        break;
                    case 3:
                        dungeon.DungeonStart();
                        break;
                    case 4:
                        //goto myloc;
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 엔터 키를 눌러 메인 메뉴로 돌아갑니다.");
                        Console.ReadLine();
                        break;
                }



            }// whil
        }
    }
}
