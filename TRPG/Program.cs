using System.Numerics;

namespace TRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager.Instance.SplashScreen();
            GameManager.Instance.shop.ShopItem_Add();
            GameManager.Instance.inven.BaseItemAdd();
            GameManager.Instance.Chi_Champion();

            GameManager.Instance.MainMenu();


        }
        public static void ShowStatus(Player player)
            {
                Console.Clear();
                Console.WriteLine("===== 플레이어 스테이터스 =====");
                Console.WriteLine($"플레이어 이름: {player.PlayerName}");
                Console.WriteLine($"챔피언: {player.Championclass.Name}");
                Console.WriteLine($"레벨: {player.Level}");
                Console.WriteLine($"경험치: {player.Exp}");
                Console.WriteLine($"골드: {player.Gold}");
                Console.WriteLine();
                Console.WriteLine("--- 챔피언 스탯 ---");
                Console.WriteLine($"HP: {player.Championclass.hp}/{player.Championclass.MaxHp}");
                Console.WriteLine($"MP: {player.Championclass.mp}/{player.Championclass.MaxMp}");
                Console.WriteLine($"ATK: {player.Championclass.atk}");
                Console.WriteLine($"DEF: {player.Championclass.def}");
                Console.WriteLine("=============================");
                Console.WriteLine("엔터 키를 눌러 메인 메뉴로 돌아갑니다.");
                Console.ReadLine();
            }
    }

}


