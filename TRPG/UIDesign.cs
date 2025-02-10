using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    public class UIDesign
    {
        public List<ColorString> UIObject;
        private int currentSelectedLineIndex = -1; //-1이면 선택되지 않음, esc를 눌러 선택을 없애기.
        private int lastSelectedLineIndex = -1;
        private int selectableCount = 0;
        private List<ColorString> selectablesList = new List<ColorString>();

        public void Write(ColorString cs, ConsoleColor fore, ConsoleColor back)
        {
            Console.SetCursorPosition(0, cs.lineIndex);
            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;
            Console.Write(cs.str);
            //if (cs.lineChange) Console.Write("\b");
            Console.ResetColor();
        }
        public void WriteAll()
        {
            Console.Clear();
            foreach (var v in UIObject)
            {
                Console.BackgroundColor = v.backColor;
                Console.ForegroundColor = v.foreColor;
                Console.Write(v.str);
                Console.ResetColor();
                if (v.lineChange) Console.Write('\n');
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
                if (key == ConsoleKey.Enter) return ConfirmAnim(currentSelectedLineIndex);
                if (currentSelectedLineIndex != -1 && key == ConsoleKey.Escape)
                {
                    selectablesList[currentSelectedLineIndex].IsSelected = false;
                    currentSelectedLineIndex = -1;
                    lastSelectedLineIndex = -1;
                }
            }
        }

        public UIDesign(List<ColorString> uIObject)
        {
            UIObject = uIObject;
            int j = 0;
            for (int i = 0; i < UIObject.Count; i++)
            {
                UIObject[i].lineIndex = i;
                //그리고 이벤트 구독
                UIObject[i].SelectedChange += SelectedStateChanged;

                if (UIObject[i].isSelectable)
                {
                    selectableCount++;
                    UIObject[i].selectableIndex = j++;
                    selectablesList.Add(UIObject[i]);
                }
                //각 줄이 활성 상태에 따라 스스로 색을 바꿈.
            }
        }

        private void MoveSelection(int direction)
        {
            lastSelectedLineIndex = currentSelectedLineIndex;
            if (currentSelectedLineIndex == -1) //아무것도 선택되지 않았을경우
            {
                if (direction == -1) //윗방향키 누르면 거꾸로, 밑에서 위로.
                {
                    currentSelectedLineIndex = 0;
                }
                else if (direction == 1)
                {
                    currentSelectedLineIndex = selectableCount - 1;
                }
            }
            //선택이 있는 경우. 일반적인 상황.
            currentSelectedLineIndex = (currentSelectedLineIndex + direction + selectableCount) % selectableCount;
            UpdateSelecedState();
        }

        private void UpdateSelecedState()
        {
            if (currentSelectedLineIndex != -1) UIObject[selectablesList[currentSelectedLineIndex].lineIndex].IsSelected = true;
            if (lastSelectedLineIndex != -1) UIObject[selectablesList[lastSelectedLineIndex].lineIndex].IsSelected = false;

        }

        private void SelectedStateChanged(object? obj, EventArgs e)
        {
            if (obj is ColorString o)
            {
                //활성 상태가 바뀌었으니 그에 맞게 다시 색 입혀줌.
                Console.SetCursorPosition(0, o.lineIndex);
                if (o.IsSelected)
                {
                    Write(o, ConsoleColor.DarkBlue, ConsoleColor.Yellow);
                }
                else
                {
                    Write(o, o.foreColor, o.backColor);
                }
                //Console.Write(o.str);
                //if (o.lineChange) Console.Write("\b");
                //Console.ResetColor();
            }
        }
        private int ConfirmAnim(int returnValue)
        {
            int blinkCount = 3;
            int blinkTime = 200;
            ConsoleColor confirmForeColor = ConsoleColor.Black;
            ConsoleColor confirmBackColor = ConsoleColor.Green;
            ColorString cs = selectablesList[currentSelectedLineIndex];
            bool b = false;
            for (int i = 0; i < blinkCount * 2 - 1; i++)
            {
                if (b)
                {
                    b = false;
                    Write(cs, cs.foreColor, cs.backColor);
                }
                else
                {
                    b = true;
                    Write(cs, confirmForeColor, confirmBackColor);
                }
                Thread.Sleep(blinkTime / 2);
            }
            Thread.Sleep(blinkTime * 2);
            return returnValue;
        }
    }
}
