using System;

namespace TRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SampleClass.SampleScene();

            string playerName = "";

            bool Main_01 = false;
            while (!false)

            bool nameConfirmed = false;
            while (!nameConfirmed)
            {
                // 반복문장
                {
                    Console.Clear();
                    Console.WriteLine("소환사의 협곡에 오신 것을 환영합니다.");
                    Console.WriteLine("닉네임을 정해주세요.");
                    Console.Write(">>> ");
                }
                playerName = Console.ReadLine();
                bool Main_02 = false;


                if (!string.IsNullOrEmpty(playerName))
                {
                    while (!Main_02)
                    {
                        //반복문장
                        {
                            Console.Clear();
                            Console.WriteLine($"\n닉네임을 {playerName}(으)로 하시겠습니까?");
                            Console.WriteLine("1. 네");
                            Console.WriteLine("2. 아니오");
                            Console.Write("\n>>> ");
                        }

                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            Console.Clear();
                            Main_01 = true;
                            break;
                        }
                        else if (input == "2")
                        {
                            Console.Clear();
                            break;

                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                            Thread.Sleep(1000);
                            //Console.ReadLine();
                        }

                // 닉네임이 공백이면 다시 입력받음
                if (string.IsNullOrWhiteSpace(playerName))
                {

            bool nameConfirmed = false;
            while (!nameConfirmed)
            {
                Console.Clear();
                Console.WriteLine("소환사의 협곡에 오신 것을 환영합니다.");
                Console.WriteLine("닉네임을 정해주세요.");
                Console.Write(">>> ");
                playerName = Console.ReadLine();

                // 닉네임이 공백이면 다시 입력받음
                if (string.IsNullOrWhiteSpace(playerName))
                {

                    Console.WriteLine("닉네임을 올바르게 입력해주세요.");
                    Console.ReadLine();
                    continue;
                }

                bool confirmationValid = false;
                while (!confirmationValid)
                {
                    Console.Clear();
                    Console.WriteLine($"닉네임을 '{playerName}'(으)로 하시겠습니까?");
                    Console.WriteLine("1. 네");
                    Console.WriteLine("2. 아니오");
                    Console.Write("\n>>> ");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        confirmationValid = true;
                        nameConfirmed = true;
                    }
                    else if (input == "2")
                    {
                        confirmationValid = true;
                        // nameConfirmed는 false로 남으므로, 외부 루프가 다시 실행되어 닉네임 입력을 다시 받음.
                    }
                    else
                    {
                        Console.WriteLine("잘못된 선택입니다. 다시 입력해주세요.");
                        Console.ReadLine(); // 잠시 대기 후 다시 확인 입력을 받음.

                    }

                }


                else
                {
                    Console.WriteLine("잘못된 문자입니다 다시입력해주세요");
                    Thread.Sleep(1000);
                }
                //if (!string.IsNullOrWhiteSpace(playerName))
                //{
                //    break;
                //}

            }

            // 챔피언 선택 및 스킬 설명 표시
            Champion selectedChampion = null;
            while (selectedChampion == null)
            {
                Console.Clear();
                Console.WriteLine("챔피언을 선택하세요.");
                Console.WriteLine("1. 미스 포춘");
                Console.WriteLine("2. 티모");
                Console.WriteLine("3. 블라디미르");
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
                    bool validConfirmation = false;
                    while (!validConfirmation)
                    {
                        Console.Clear();
                        Console.WriteLine($"{tempChampion.Name} 챔피언을 선택하셨습니다.\n");

                        // 스킬 설명 출력
                        tempChampion.DisplaySkillInfo();

                        Console.WriteLine("\n이 챔피언을 선택하시겠습니까?");
                        Console.WriteLine("1. 네");
                        Console.WriteLine("2. 아니오");
                        Console.Write("\n>>> ");
                        string confirmChoice = Console.ReadLine();

                        if (confirmChoice == "1")
                        {
                            selectedChampion = tempChampion;
                            validConfirmation = true;
                        }
                        else if (confirmChoice == "2")
                        {
                            validConfirmation = true;
                            // 선택 취소 시 외부 루프로 돌아가 다시 챔피언 선택을 받음.
                        }
                        else
                        {
                            Console.WriteLine("잘못된 선택입니다. 다시 입력해주세요.");
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 선택입니다. 다시 입력해주세요.");
                    Console.ReadLine();
                }
            }

            // Player 객체 생성 및 최종 확정 메시지 출력
            Player player = new Player(playerName, selectedChampion);
            Console.WriteLine($"\n플레이어 '{player.PlayerName}'이(가) '{player.Championclass.Name}' 챔피언으로 확정되었습니다!");
            Console.WriteLine("엔터 키를 눌러 종료합니다.");
            Console.ReadLine();
        }
    }
}






