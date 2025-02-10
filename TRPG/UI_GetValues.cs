using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    public partial class UI
    {
        public string GetUserInput(string inputGuide = "기본 가이드: 문자열 반환" )
        {
            while (true)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 3); //밑에서 3번째줄
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.WindowHeight - 3);
                Console.WriteLine(inputGuide);
                Console.SetCursorPosition(0, Console.WindowHeight - 2); //밑에서 2번째줄
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                Console.Write(">>>");
                Console.CursorVisible = true;
                string input = Console.ReadLine() ?? ""; //입력 동시에 null 검사

                if (string.IsNullOrWhiteSpace(input)) //빈 문자열
                {
                    inputGuide = "뭐라도 입력을 해 봐...";
                    continue;
                }
                else
                {
                    return input.Trim(); //좌, 우 공백 제거
                }
            }
        }
    }
}
