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
        public int Gold { get; set; } = 1500;

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
            return 200 + (Level - 1) * 100;
        }
        public void LevelUp()
        {
            Exp -= GetRequiredExp();
            Level++;
            //레벨업시 챔피언의 능력치 상승
            Championclass.LevelUpAbility();
            Console.WriteLine($"{Championclass.Name}이(가) 레벨업 했습니다! (Lv.{Level})");
        }
    }
}
