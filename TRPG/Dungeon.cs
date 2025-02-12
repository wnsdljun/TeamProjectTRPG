namespace TRPG
{
    internal class Dungeon
    {
        public BattleSystem battleSystem = new BattleSystem();
        public void DungeonStart()
        {
            bool Turn = true;
            while (Turn)
            {
                Console.Clear();
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
                            GameManager.Instance.dungeon.battleSystem = new();//새로운 배틀시스템 생성 enemies를 초기화 시킨다. 없으면 이전 적들이 남아있음(죽어도)
                            battleSystem.BattleStart();
                            Turn = false;
                            break;
                        case 2:
                            DungeonEnd();
                            Turn = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
        public void DungeonForward()
        {
            bool Turn = true;
            while (Turn)
            {
                int input = 0;
                Console.WriteLine("적이 곧 몰려옵니다. 어떻게 하시겠습니까?" +
                    "\n\n1. 전진하기" +
                    "\n2. 인벤토리" +
                    "\n3. 휴식하기" +
                    "\n4. 나가기");
                if (int.TryParse(Console.ReadLine(), out input) && input < 5 && 0 < input)
                {
                    switch (input)
                    {
                        case 1:
                            battleSystem.BattleStart(false);
                            Turn = false;
                            break;
                        case 2:
                            //인벤토리

                            break;
                        case 3://휴식
                            int input2;
                            Console.WriteLine("골드를 지불해 체력을 회복 시킵니다. 회복하시겠습니까?\n비용: 100골드\n");
                            Console.WriteLine("================================================\n");
                            Console.WriteLine($"보유 골드: {GameManager.Instance.player.Gold}골드");
                            Console.WriteLine("1. 회복하기\n2. 나가기");
                            if (int.TryParse(Console.ReadLine(), out input2) && input2 == 1)
                            {
                                if (input2 == 1)
                                {
                                    if (GameManager.Instance.player.Gold >= 100)
                                    {
                                        GameManager.Instance.player.Gold -= 100;
                                        GameManager.Instance.player.Championclass.hp += 300;
                                        GameManager.Instance.player.Championclass.mp += 100;
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
                                    if (GameManager.Instance.player.Championclass.mp > GameManager.Instance.player.Championclass.MaxMp)
                                    {
                                        GameManager.Instance.player.Championclass.mp = GameManager.Instance.player.Championclass.MaxMp;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                            }
                            break;
                        case 4:
                            DungeonEnd();
                            Turn = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
        public void DungeonEnd()
        {
            Console.WriteLine("협곡을 빠져나가셨습니다.");//스테이터스 창으로 이동
            battleSystem.StageWave = 1;
            GameManager.Instance.player.Championclass.hp = GameManager.Instance.player.Championclass.MaxHp;
            GameManager.Instance.player.Championclass.mp = GameManager.Instance.player.Championclass.MaxMp;
            GameManager.Instance.MainMenu();
        }
    }
}
