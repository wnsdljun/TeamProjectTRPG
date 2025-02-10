using System;
//
namespace TRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SampleClass.SampleScene();
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

        }
    }
}






