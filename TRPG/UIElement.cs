namespace TRPG
{
    public class UIElement
    {
        private List<Tuple<char, ConsoleColor, ConsoleColor>> coloredChar = new List<Tuple<char, ConsoleColor, ConsoleColor>>();
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
                coloredChar.Add(new Tuple<char, ConsoleColor, ConsoleColor>(c, back ??= Console.BackgroundColor, fore ??= Console.ForegroundColor));
            }
            isSelectable = selectable;
            if (selectable) StateChange += HighlightChanged;
            this.tip = tip;
        }

        public UIElement(string text, List<Tuple<int, ConsoleColor, ConsoleColor>> colorIndex, bool selectable = false, string tip = "지정된 설명이 없습니다.")
        {
            Tuple<char, ConsoleColor, ConsoleColor> tuple;
            int i = 0;
            int j = 0;
            foreach (char c in text)
            {
                if (j < colorIndex.Count && colorIndex[j].Item1 == i++) //색을 바꿀 인덱스
                {
                    tuple = new(c, colorIndex[j].Item2, colorIndex[j].Item3);
                    j++;
                }
                else
                {
                    tuple = new(c, Console.BackgroundColor, Console.ForegroundColor);
                }
                coloredChar.Add(tuple);
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
            foreach (var (c, back, fore) in coloredChar)
            {
                Console.BackgroundColor = back;
                Console.ForegroundColor = fore;
                Console.Write(c);
                Console.ResetColor();
            }
        }
        public void WriteOverrideColor(ConsoleColor _back, ConsoleColor _fore)
        {
            Console.SetCursorPosition(0, lineIndex);
            foreach (var (c, back, fore) in coloredChar)
            {
                Console.BackgroundColor = _back;
                Console.ForegroundColor = _fore;
                Console.Write(c);
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
}
