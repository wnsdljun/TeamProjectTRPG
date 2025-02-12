using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace TRPG
{
    internal class Player
    {
        public string PlayerName { get; private set; }
        public int Level { get; set; } = 1;
        public int Exp { get; set; } = 0;
        public int Gold { get; set; } = 4500;
        public Champion Championclass { get; private set; }

        //public Player() { }
        public Player()
        {

        }

        public void GetPlayer(string playerName, Champion champion)
        {

            PlayerName = playerName;
            Championclass = champion;

        }


        //경험치 획득 및 레벨업
        public void GainExp(int amount)
        {
            Exp += amount;
            Console.WriteLine($"현재 경험치: {Exp}");

            while (Exp >= GetRequiredExp())
            {
                LevelUp();
            }
        }
        private int GetRequiredExp()
        {
            return 50 + ((Level - 1) * 100);
        }
        public void LevelUp()
        {
            Exp -= GetRequiredExp();
            Level++;
            //레벨업시 챔피언의 능력치 상승
            Championclass.LevelUpAbility();
            Console.WriteLine($"{Championclass.Name}이(가) 레벨업 했습니다! (Lv.{Level})");
            //레벨업시 스킬레벨 증가

            bool bool_skill = false;
            while (!bool_skill)
            {
                Console.WriteLine($"어떤 스킬을 찍으시겠습니까? Q = 1 / W = 2 / E = 3");
                Console.Write(">>>");

                int skillnum;
                if (int.TryParse(Console.ReadLine(), out skillnum))
                {
                    switch (skillnum)
                    {
                        case 1:
                            GameManager.Instance.selectedChampion.LevelUpSkillQ();
                            Console.WriteLine("Q스킬을 배웠습니다");
                            Thread.Sleep(1000);
                            bool_skill= true;
                            break;
                        case 2:
                            GameManager.Instance.selectedChampion.LevelUpSkillW();
                            Console.WriteLine("W스킬을 배웠습니다");
                            Thread.Sleep(1000);
                            bool_skill = true;
                            break;
                        case 3:
                            GameManager.Instance.selectedChampion.LevelUpSkillE();
                            Console.WriteLine("E스킬을 배웠습니다");
                            Thread.Sleep(1000);
                            bool_skill = true;
                            break;

                        default:
                            Console.WriteLine("잘못된 입력입니다");
                            Thread.Sleep(1000);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 숫자입니다 다시입력하세요 ");
                    Thread.Sleep(1000);
                }

            }
        }
    }
}
