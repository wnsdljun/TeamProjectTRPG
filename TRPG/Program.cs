using System.Numerics;

namespace TRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerName = "";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("소환사의 협곡에 오신 것을 환영합니다.");
                Console.WriteLine("닉네임을 정해주세요.");
                Console.Write(">>> ");
                playerName = Console.ReadLine();

                while (true)
                {
                    Console.WriteLine($"\n닉네임을 {playerName}(으)로 하시겠습니까?");
                    Console.WriteLine("1. 네");
                    Console.WriteLine("2. 아니오");
                    Console.Write("\n>>> ");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (input == "2")
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                        Console.ReadLine();
                    }
                }
                if (!string.IsNullOrWhiteSpace(playerName))
                {
                    break;
                }
            }

            Champion selectedChampion = null;
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

            Player player = new Player(playerName, selectedChampion);
            Console.WriteLine($"\n플레이어 '{player.PlayerName}'이(가) '{player.Championclass.Name}' 챔피언으로 확정되었습니다!");
            Console.WriteLine("엔터 키를 눌러 메인 메뉴로 이동합니다.");
            Console.ReadLine();

            Inven inven = new Inven();
            Shop shop = new Shop();
            Dungeon dungeon = new Dungeon();

            bool exitMenu = false;
            while (!exitMenu)
            {
                Console.Clear();
                Console.WriteLine("메인 메뉴를 선택하세요:");
                Console.WriteLine("1. 스테이터스 확인");
                Console.WriteLine("2. 인벤토리 확인");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 협곡");
                Console.WriteLine("0. 종료");
                Console.Write("\n>>> ");
                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        ShowStatus(player);
                        break;
                    case "2":
                        inven.ShowInven(player);
                        break;
                    case "3":
                        shop.ShowShop(player, inven);
                        break;
                    case "4":
<<<<<<< HEAD
                        // 협곡 기능을 호출합니다.
                        dungeon.DungeonStart();
                        dungeon.DungeonForward();
                        Console.WriteLine("\n엔터 키를 눌러 메인 메뉴로 돌아갑니다.");
                        Console.ReadLine();
=======
                        dungeon.DungeonStart();
>>>>>>> GH_Dev_Fix
                        break;
                    case "0":
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 엔터 키를 눌러 메인 메뉴로 돌아갑니다.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        static void ShowStatus(Player player)
            {
                Console.Clear();
                Console.WriteLine("===== 플레이어 스테이터스 =====");
                Console.WriteLine($"플레이어 이름: {player.PlayerName}");
                Console.WriteLine($"챔피언: {player.Championclass.Name}");
                Console.WriteLine($"레벨: {player.Level}");
                Console.WriteLine($"경험치: {player.Exp}");
                Console.WriteLine($"골드: {player.Gold}");
                Console.WriteLine();
                Console.WriteLine("--- 챔피언 스탯 ---");
                Console.WriteLine($"HP: {player.Championclass.hp}");
                Console.WriteLine($"MP: {player.Championclass.mp}");
                Console.WriteLine($"ATK: {player.Championclass.atk}");
                Console.WriteLine($"DEF: {player.Championclass.def}");
                Console.WriteLine("=============================");
                Console.WriteLine("엔터 키를 눌러 메인 메뉴로 돌아갑니다.");
                Console.ReadLine();
            }
    }

}


