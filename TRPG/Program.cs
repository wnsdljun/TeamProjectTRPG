using System;
//
namespace TRPG
{
    internal class Program
    {
        //Champion selectedChampion;
        static void Main(string[] args)
        {
            GameManager singleton = GameManager.Instance;
            //플레이어 + 챔피언 선택 
            singleton.Chi_Champion();

            
        }


    }
}






