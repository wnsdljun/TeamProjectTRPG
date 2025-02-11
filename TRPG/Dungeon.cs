using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class Dungeon
    {
        public BattleSystem battleSystem = new BattleSystem();
        public void DungeonStart()
        {
            int input;
            Console.WriteLine("협곡에 오신 것을 환영합니다." +
                "\n앞으로 나아가시겠습니까?" +
                "\n\n1. 들어가기" +
                "\n2. 나가기");
            if (int.TryParse(Console.ReadLine(), out input))
            {
                switch (input)
                {
                    case 1:
                        Console.WriteLine("협곡으로 들어갑니다.");
                        battleSystem.BattleStart();
                        break;
                    case 2:
                        DungeonEnd();
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }
        }
        public void DungeonForward()
        {
            int input = 0;
            Console.WriteLine("적이 곳 몰려옵니다. 어떻게 하시겠습니까?" +
                "\n\n1. 전진하기" +
                "\n2. 인벤토리" +
                "\n3. 휴식하기" +
                "\n4. 나가기");
            if (int.TryParse(Console.ReadLine(), out input) && input < 5 && 0 < input)
            {
                switch (input)
                {
                    case 1:
                        battleSystem.BattleStart();
                        break;
                    case 2:
                        //인벤토리

                        break;
                    case 3://휴식
                        int input2;
                        Console.WriteLine("골드를 지불해 체력을 회복 시킵니다. 회복하시겠습니까?\n비용: 100골드\n");
                        Console.WriteLine("================================================\n");
                        Console.WriteLine("1. 회복하기\n2. 나가기");
                        if (int.TryParse(Console.ReadLine(), out input2) && input2 == 1 || input2 == 2)
                        {
                            if (input2 == 1)
                            {
                                if (GameManager.Instance.player.Gold >= 100)
                                {
                                    GameManager.Instance.player.Gold -= 100;
                                    GameManager.Instance.player.Championclass.hp += 300;
                                }
                                else
                                {
                                    Console.WriteLine("골드가 부족합니다.");
                                    return;
                                }
                                if (GameManager.Instance.player.Championclass.hp > GameManager.Instance.player.Championclass.MaxHp)
                                {
                                    GameManager.Instance.player.Championclass.hp = GameManager.Instance.player.Championclass.MaxHp;
                                }
                            }
                            else
                            {
                                DungeonForward();
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            return;
                        }
                        break;
                    case 4:
                        DungeonEnd();
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }
        }
        public void DungeonEnd()
        {
            Console.WriteLine("협곡을 빠져나가셨습니다.");//스테이터스 창으로 이동
            battleSystem.StageWave = 1;
            GameManager.Instance.MainMenu();
        }
    }
}
