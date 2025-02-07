namespace TRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("소환사의 협곡에 오신 것을 환영합니다.");
                Console.WriteLine("닉네임을 정해주세요.");
                Console.WriteLine();
                Console.Write(">>> ");
                String Playername = Console.ReadLine();

                while (true)
                {
                    Console.WriteLine($"\n닉네임을 {Playername}으로 하시겠습니까?");
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
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    }                   
                }
                if (Playername != null)
                {
                    break;
                }

            }
            Champion selectedChampion = null;
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("챔피언을 선택하세요.");
                Console.WriteLine("1. 미스 포춘\n2. 티모\n3. 블라디미르");
                Console.Write("\n>>> ");
                string championchoice = Console.ReadLine();

                if (championchoice == "1")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("1. 미스 포춘");
                        Console.WriteLine("\n스킬 1.한 발에 두 놈: 순차적으로 미니언 2마리에게 데미지를 입힌다. 만약 첫번째 미니언이 죽는다면 두번째 미니언에게는 추가데미지가 들어간다.");
                        Console.WriteLine("\n스킬 2.활보: 미스 포춘의 공격력이 한턴동안 공격력이 증가하고 기본공격을 사용한다.");
                        Console.WriteLine("\n스킬 3.총알은 비를 타고: 상대 미니언 전체에게 광역데미지를 준다.");
                        Console.WriteLine("\n 정말로 미스 포춘으로 하시겠습니까?");
                        Console.WriteLine("1. 네\n2. 아니오");
                        Console.Write("\n>>> ");
                        string confirmChoice = Console.ReadLine();

                        if (confirmChoice == "1")
                        {
                            selectedChampion = new Champion("미스 포춘", 120, 100, 100, 50);
                            break;
                        }
                        else if (confirmChoice == "2")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                            Console.ReadLine();
                            continue;
                        }
                    }
                }
                else if (championchoice == "2")
                {
                    while (true)  
                    {
                        Console.Clear();
                        Console.WriteLine("2. 티모");
                        Console.WriteLine("\n스킬 1. 맹독 다트: 미니언에게 독을 묻혀 지속적인 데미지를 준다.");
                        Console.WriteLine("\n스킬 2. 유격전투: 한 턴 동안 은신하고 다음 상대 공격을 무시한다.");
                        Console.WriteLine("\n스킬 3. 유독성 함정: 필드에 버섯을 설치해 광역데미지를 입힌다.");
                        Console.WriteLine("\n정말로 티모로 하시겠습니까?");
                        Console.WriteLine("1. 네\n2. 아니오");
                        Console.Write("\n>>> ");
                        string confirmChoice = Console.ReadLine();

                        if (confirmChoice == "1")
                        {
                            selectedChampion = new Champion("티모", 110, 120, 110, 40);
                            break;
                        }
                        else if (confirmChoice == "2")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                            Console.ReadLine();
                            continue;
                        }
                    }
                }
                else if (championchoice == "3")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("3. 블라디미르");
                        Console.WriteLine("\n스킬 1. 수혈: 적에게 피해를 주고 자신의 체력을 회복한다.");
                        Console.WriteLine("\n스킬 2. 피의 웅덩이: 다음 턴 상대방의 공격을 무시한다.");
                        Console.WriteLine("\n스킬 3. 선혈의 파도: 적 전체에게 광역 피해를 입힌다.");
                        Console.WriteLine("\n정말로 블라디미르로 하시겠습니까?");
                        Console.WriteLine("1. 네\n2. 아니오");
                        Console.Write("\n>>> ");
                        string confirmChoice = Console.ReadLine();

                        if (confirmChoice == "1")
                        {
                            selectedChampion = new Champion("블라디미르", 140, 100, 40, 60);
                            break;
                        }
                        else if (confirmChoice == "2")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                            Console.ReadLine();
                            continue;
                        }
                    }                   
                }
                else
                {
                    Console.WriteLine("잘못된 선택입니다. 다시 입력해주세요.");
                    Console.ReadLine();
                }
                if (selectedChampion != null)
                {
                    break;
                }
            }
            }
        }
    }

