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
            int input = 1;
            Console.WriteLine("협곡에 오신 것을 환영합니다." +
                "\n앞으로 나아가시겠습니까?" +
                "\n\n1. 들어가기" +
                "\n2. 나가기");
            switch(input)
            {
                case 0:
                    Console.WriteLine("협곡으로 들어갑니다.");
                    break;
                case 1:
                    Console.WriteLine("협곡을 빠져나갑니다.");
                    break;
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
            switch (input)
            {
                case 0:
                    battleSystem.BattleStart();
                    break;
                case 1:
                  
                    break;
                case 2:
                   
                    break;
                case 3:

                    break;
            }
        }
        public void DungeonEnd()
        {
            Console.WriteLine("협곡을 빠져나가셨습니다.");
        }
    }
}
