using System.Reflection.Metadata.Ecma335;

namespace TRPG
{
    public class UI
    {
        public List<UIElement> elements;
        List<UIElement> selectableE = new();
        int selectedLine = -1;
        int lastSelectedLine = -1;
        
        public UI(List<UIElement> elements)
        {
            int i = 0;
            foreach (UIElement element in elements)
            {
                element.lineIndex = i++;
                if (element.isSelectable) selectableE.Add(element);
            }
            this.elements = elements;
        }

        public void WriteAll()
        {
            foreach (UIElement element in elements)
            {
                element.Write();
            }
        }
        public int PlayerUIControl()
        {
            Console.CursorVisible = false;
            //사용자 방향키 입력으로 항목을 선택하는 부분
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow) MoveSelection(-1);
                if (key == ConsoleKey.DownArrow) MoveSelection(1);
                //if (key == ConsoleKey.RightArrow) ;
                //if (key == ConsoleKey.LeftArrow) ;
                if (key == ConsoleKey.Enter) return ConfirmAnim(selectedLine);
                if (selectedLine != -1 && key == ConsoleKey.Escape)
                {
                    selectableE[selectedLine].isHighlighted = false;
                    selectedLine = -1;
                    lastSelectedLine = -1;
                }
            }
        }
        private void MoveSelection(int direction)
        {
            lastSelectedLine = selectedLine;
            if (selectedLine == -1) //아무것도 선택되지 않았을경우
            {
                if (direction == -1) //윗방향키 누르면 거꾸로, 밑에서 위로.
                {
                    selectedLine = 0;
                }
                else if (direction == 1)
                {
                    selectedLine = selectableE.Count - 1;
                }
            }
            //선택이 있는 경우. 일반적인 상황.
            selectedLine = (selectedLine + direction + selectableE.Count) % selectableE.Count;

            if (selectedLine != -1) selectableE[selectedLine].isHighlighted = true;
            if (lastSelectedLine != -1) selectableE[lastSelectedLine].isHighlighted = false;
        }

        private int ConfirmAnim(int returnValue)
        {
            int blinkCount = 3;
            int blinkTime = 200;
            ConsoleColor confirmForeColor = ConsoleColor.Black;
            ConsoleColor confirmBackColor = ConsoleColor.Green;
            UIElement element = selectableE[selectedLine];
            bool b = false;
            for (int i = 0; i < blinkCount * 2 - 1; i++)
            {
                if (b)
                {
                    b = false;
                    element.Write();
                }
                else
                {
                    b = true;
                    element.WriteOverrideColor(confirmBackColor, confirmForeColor);
                }
                Thread.Sleep(blinkTime / 2);
            }
            Thread.Sleep(blinkTime * 2);
            return returnValue;
        }
    }
}
