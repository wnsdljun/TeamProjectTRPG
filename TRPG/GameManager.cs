using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class GameManager
    {
        public Player player ;
        public Champion selectedChampion;
        private static GameManager instance = null;
        // 2. thread-safe를 위한 lock 객체
        private static readonly object lockObject = new object();
        public List<InvenItem> inventoryItems { get; set; } = new List<InvenItem>();

        public string playerName = "";

        
        private GameManager()
        {
            // 초기화 코드
        }
        // 4. public static 프로퍼티 (인스턴스 접근용)
        public static GameManager Instance
        {
            get
            {
                // Double-check locking
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new GameManager();
                        }
                    }
                }
                return instance;
            }
        }


        public  void Chi_Champion()
        {
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

                Console.WriteLine();
                selectedChampion.DisplaySkillInfo();
                Thread.Sleep(5000);

                UI ui_ConfirmChmp = new UI(new List<UIElement>
                {
                    new($"{selectedChampion.Name}(을)를 선택하셨습니다."),
                    new(),
                    new(),
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

            while (selectedChampion == null)
            {
                Console.Clear();
                Console.WriteLine("챔피언을 선택하세요.");
                Console.WriteLine("1. 미스 포춘\n2. 티모\n3. 블라디미르");
                Console.Write("\n>>> ");
                string championChoice = Console.ReadLine();

                Champion tempChampion = championChoice switch
                {
                    "1" => new MissFortune(),
                    "2" => new Teemo(),
                    "3" => new Vladimir(),
                    _ => null
                };

                if (tempChampion != null)
                {
                    Console.Clear();
                    Console.WriteLine($"{tempChampion.Name} 챔피언을 선택하셨습니다.\n");

                    tempChampion.DisplaySkillInfo();

                    Console.WriteLine("\n이 챔피언을 선택하시겠습니까?");
                    Console.WriteLine("1. 네\n2. 아니오");
                    Console.Write("\n>>> ");
                    string confirmChoice = Console.ReadLine();

                    if (confirmChoice == "1")
                    {
                        selectedChampion = tempChampion;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 선택입니다. 다시 입력해주세요.");
                    Console.ReadLine();
                }
            }

            player = new Player(playerName, selectedChampion);
            Console.WriteLine($"\n플레이어 '{player.PlayerName}'이(가) '{player.Championclass.Name}' 챔피언으로 확정되었습니다!");

            //플레이어랑 챔피언을 인스턴스를 만들어야지
            //player =new Player(playerName, selectedChampion);
        }

    }
}
