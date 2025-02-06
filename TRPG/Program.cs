namespace TRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("소환사의 협곡에 오신 것을 환영합니다.");
            Console.WriteLine("닉네임을 정해주세요.");
            Console.WriteLine();
            Console.Write(">>> ");
            String Playername = Console.ReadLine();

            Champion missfortune = new Champion("미스 포춘", 120, 100, 100, 50);

            Champion Teemo = new Champion("티모", 110, 120, 110, 40);

            Champion Vladimir = new Champion("블라디미르", 140, 100, 40, 60);

            string input = Console.ReadLine();

            Player player; if (String.Compare(input,"1"))
            {
                player = new Player(Playername, missfortune);
            }

        }
    }
}
