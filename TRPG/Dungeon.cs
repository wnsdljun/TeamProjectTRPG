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
            Console.WriteLine("협곡에 오신 것을 환영합니다." +
                "\n앞으로 나아가시겠습니까?" +
                "\n\n1. 전진하기" +
                "\n2. 돌아가기");

        }
        public void DungeonEnd()
        {
            Console.WriteLine("협곡을 빠져나가셨습니다.");
        }
    }
}
