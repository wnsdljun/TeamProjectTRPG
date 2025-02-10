using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class Dungeon
    {
        public void DungeonStart()
        {
            int input = 1;
            Console.WriteLine("협곡에 오신 것을 환영합니다." +
                "\n앞으로 나아가시겠습니까?" +
                "\n\n1. 들어가기" +
                "\n2. 나가기");
            switch(input)
            {
                case 1:
                    Console.WriteLine("협곡으로 들어갑니다.");
                    break;
                case 2:
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
                    Console.WriteLine("적을 만났습니다. 전투를 시작합니다.");
                    break;
                case 1:
                    Console.WriteLine("인벤토리를 엽니다.");
                    break;
                case 2:
                    Console.WriteLine("휴식을 취합니다.");
                    break;
                case 3:
                    Console.WriteLine("협곡을 빠져나갑니다.");
                    break;
            }
        }
        public void DungeonEnd()
        {
            Console.WriteLine("협곡을 빠져나가셨습니다.");
        }
    }
}
