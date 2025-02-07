namespace TRPG
{
    internal class SampleClass
    {
        public static void ShowSample()
        {
            List<ColorString> sample = new List<ColorString>
            {
                new ColorString("인벤토리", ConsoleColor.Green, ConsoleColor.Black),
                new ColorString("인벤토리를 볼 수 있읍니다."),
                new ColorString(),
                new ColorString("1. 선택 가능한 옵션",tip: "1번 옵션에 대한 설명입니다.", selectable:true),
                new ColorString("2. 선택 가능한 옵션",tip: "2번 옵션에 대한 설명입니다.", selectable:true),
                new ColorString("3. 선택 가능한 옵션",tip: "3번 옵션에 대한 설명입니다.", selectable:true)
            };
            sample.show
        }
    }
}
