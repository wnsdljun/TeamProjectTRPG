namespace TRPG
{
    internal class SampleClass
    {
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
            ui.PlayerUIControl();
        }
    }
}
