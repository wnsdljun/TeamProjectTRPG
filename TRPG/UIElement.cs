namespace TRPG
{
    public class UIElement
    {
        private List<UIChar> coloredChar = new List<UIChar>();
        private string tip;
        public event EventHandler? StateChange;
        private bool IsHighlighted; //이거 추가하니까 stackoverflow 없어짐
        public bool isHighlighted
        {
            get => IsHighlighted;
            set
            {
                if (IsHighlighted != value)
                {
                    IsHighlighted = value;
                    StateChange?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public bool isSelectable;
        public int lineIndex;
        public UIElement(string text, ConsoleColor? back = null, ConsoleColor? fore = null, bool selectable = false, string tip = "지정된 설명이 없습니다.")
        {
            foreach (char c in text)
            {
                coloredChar.Add(new UIChar(c, back ??= Console.BackgroundColor, fore ??= Console.ForegroundColor));
            }
            isSelectable = selectable;
            if (selectable) StateChange += HighlightChanged;
            this.tip = tip;
        }

        public UIElement(string text, List<UIColorIndex> colorIndex, bool selectable = false, string tip = "지정된 설명이 없습니다.")
        {
            UIChar uIChar;
            int i = 0;
            int j = 0;
            foreach (char c in text)
            {
                if (j < colorIndex.Count && colorIndex[j].index == i++) //색을 바꿀 인덱스
                {
                    uIChar = new(c, colorIndex[j].backColor, colorIndex[j].foreColor);
                    j++;
                }
                else
                {
                    uIChar = new(c, Console.BackgroundColor, Console.ForegroundColor);
                }
                coloredChar.Add(uIChar);
            }
            isSelectable = selectable;
            if (selectable) StateChange += HighlightChanged;
            this.tip = tip;
        }

        public UIElement()
        {
            tip = "";
        }


        public void Write()
        {
            Console.SetCursorPosition(0, lineIndex);
            foreach (var cha in coloredChar)
            {
                Console.BackgroundColor = cha.backColor;
                Console.ForegroundColor = cha.foreColor;
                Console.Write(cha.ch);
                Console.ResetColor();
            }
        }
        public void WriteOverrideColor(ConsoleColor _back, ConsoleColor _fore)
        {
            Console.SetCursorPosition(0, lineIndex);
            foreach (var cha in coloredChar)
            {
                Console.BackgroundColor = _back;
                Console.ForegroundColor = _fore;
                Console.Write(cha.ch);
                Console.ResetColor();
            }
        }
        private void HighlightChanged(object? o, EventArgs e) //하이라이트 바뀌었으니 다시 출력
        {
            if (isHighlighted)
            {
                //하이라이트 됨.
                WriteOverrideColor(ConsoleColor.Yellow, ConsoleColor.Green);

                Console.SetCursorPosition(0, Console.WindowHeight - 2); //지우고 다시 쓰기
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                Console.Write(tip);
            }
            else
            {
                //아님.
                Write();
            }
        }
    }

    public class UIChar
    {
        public char ch;
        public ConsoleColor backColor;
        public ConsoleColor foreColor;

        public UIChar(char c, ConsoleColor back, ConsoleColor fore) 
        { 
            ch = c;
            this.backColor = back;
            this.foreColor = fore;
        }
    }

    public class UIColorIndex
    {
        public int index { get; }
        public ConsoleColor backColor;
        public ConsoleColor foreColor;
        public UIColorIndex(int index, ConsoleColor back, ConsoleColor fore)
        {
            this.index = index;
            this.backColor = back;
            this.foreColor = fore;
        }
    }
}
