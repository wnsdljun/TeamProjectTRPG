namespace TRPG
{
    internal class SampleClass
    {
        /*
        public static void ShowSample()
        {

            //사용법 1: 콘솔 창에 표시할 정보를 이런 느낌으로 입력합니다.
            //ColorString 은 한 줄에 해당하는 정보를 담고 있습니다.
            //정보가 담겨있는 줄을 리스트로 만듭니다. 아래와 같이 쓰면 보기가 좋습니다.

            List<ColorString> sample = new List<ColorString>
            {
                new ColorString("인벤토리", ConsoleColor.Green, ConsoleColor.Black),
                new ColorString("인벤토리를 볼 수 있읍니다."),
                new ColorString(),
                new ColorString("1. 선택 가능한 옵션", tip: "1번 옵션에 대한 설명입니다.", selectable:true),
                new ColorString("2. 선택 가능한 옵션", tip: "2번 옵션에 대한 설명입니다.", selectable:true),
                new ColorString("3. 선택 가능한 옵션", ConsoleColor.Blue, ConsoleColor.Red , tip: "3번 옵션에 대한 설명입니다.", selectable:true),
                new ColorString("4. 색깔 입히기", selectable: true, lineChange: false),
                new ColorString("으히힝", selectable:true, lineChange: true)
            };

            //사용법 2: UIDesign 객체를 하나 만듭니다.
            //그리고 생성자에 아까 만든 리스트를 넣어줍니다.
            UIDesign uIDesign = new UIDesign(sample);

            //사용법 3: 콘솔 창에 표시해주는 함수를 호출합니다.
            uIDesign.WriteAll();

            //사용법 4: 유저 입력을 받도록 uIDesign으로 제어를 넘겨줍니다.
            int input = uIDesign.PlayerUIControl();

            //사용법 5: 이제 int 형으로 반환된 값을 갖고 놀면 됩니다.

            Console.Clear();

            Console.WriteLine(input);
        }
        */

        public static void ShowSample2()
        {
            UI ui = new UI(new List<UIElement>
            {
                new("텍스 트"),
                new("샘플?입니다.",ConsoleColor.Green, ConsoleColor.Red),
                new("색을지정할수있는", new List<Tuple<int,ConsoleColor,ConsoleColor>> {
                    new(1, ConsoleColor.Red, ConsoleColor.Green),
                    new(2, ConsoleColor.Green, ConsoleColor.Red)
                }),
                new("색을지정할수있는선택가능한", new List<Tuple<int,ConsoleColor,ConsoleColor>> {
                    new(7, ConsoleColor.Red, ConsoleColor.Green),
                    new(8, ConsoleColor.Green, ConsoleColor.Red)
                }, selectable: true,tip: "선택가능한첫번째의설명"),
                new("그냥선택만되는", tip: "그냥선택가능한두번째의설명", selectable: true)

            });

            ui.WriteAll();
            ui.UserUIControl();
        }

        public static void SampleScene()
        {
            //최초 시작 화면의 샘플 씬
            string playerName = "";



            while (true)
            {
                UI ui_Welcome = new UI(new List<UIElement>
                {
                    new("소환사의 협곡에 오신 것을 환영합니다."),
                    new("닉네임을 입력해 주십시오.")
                });

                ui_Welcome.WriteAll();
                playerName = ui_Welcome.GetUserInput("닉네임으로 사용할 문자열 입력을 받습니다.");

                UI ui_ConfirmNick = new UI(new List<UIElement>
                {
                    new($"닉네임을 {playerName}(으)로 하시겠습니까?"),
                    new(),
                    new("네",selectable:true, tip:$"{playerName}을 닉네임으로 확정합니다."),
                    new("아니오",selectable:true, tip:"닉네임을 다시 입력합니다."),
                });


                ui_ConfirmNick.WriteAll();
                int input = ui_ConfirmNick.UserUIControl();

                if (input == 0) break; //0번 선택시 - 네

            }
            ////////////////////////////////////////////////////

            //챔피언 선택 화면
            Champion selectedChampion;

            while (true)
            {
                UI ui_SelectChmp = new UI(new List<UIElement>
                {
                    new("챔피언을 선택하여 주십시오."),
                    new(),
                    new("1. 티모",selectable: true ,tip: "버섯깔기!"),
                    new("2. 미스 포춘",selectable: true ,tip: "미스 포춘 쿠키"),
                    new("3. 블라디미르",selectable: true ,tip: "블라디미르")
                });

                ui_SelectChmp.WriteAll();
                int input = ui_SelectChmp.UserUIControl();

                selectedChampion = input switch
                {
                    0 => new Teemo(),
                    1 => new MissFortune(),
                    2 => new Vladimir(),
                    _ => throw new Exception()
                };

                UI ui_ConfirmChmp = new UI(new List<UIElement>
                {
                    new($"{selectedChampion.Name}(을)를 선택하셨습니다."),
                    new(),
                    // skill info 
                    new(),
                    new("이 챔피언을 사용하시겠습니까?"),
                    new(),
                    new("네",selectable: true ,tip: $"{selectedChampion.Name}을(를) 챔피언으로 확정합니다."),
                    new("아니오",selectable: true ,tip: "챔피언을 다시 선택합니다."),
                });

                ui_ConfirmChmp.WriteAll();
                input = ui_ConfirmChmp.UserUIControl();

                if (input == 0) break;
            }

            BattleSystem bs = new BattleSystem(//참조를 전달);



        }
    }
}
