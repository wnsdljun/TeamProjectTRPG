namespace TRPG
{
    internal class UI
    {
        public void WriteColor(List<ColorString> str)
        {
            foreach (var s in str)
            {
                WriteColor(str);
            }
        }
        public void WriteColor(ColorString colorString)
        {
            if (!colorString.isSelectable)
            {
                Console.BackgroundColor = colorString.backColor;
                Console.ForegroundColor = colorString.foreColor;
                Console.Write(colorString.str);
                Console.ResetColor();
                return;
            }
            if (colorString.isSelected)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(colorString.str);
                Console.ResetColor();
                return;
            }
            else
            {
                Console.BackgroundColor = colorString.backColor;
                Console.ForegroundColor = colorString.foreColor;
                Console.Write(colorString.str);
                Console.ResetColor();
                return;
            }
        }
    }

    public class UIDesign
    {
        public List<ColorString> UIObject;
        private int currentSelectdLineIndex = -1; //-1이면 선택되지 않음, esc를 눌러 선택을 없애기.
        private int lastSelectedLineIndex = -1;
        private int[] selectableIndex;

        public void Write()
        {

        }

        public int PlayerUIControl()
        {
            //사용자 방향키 입력으로 항목을 선택하는 부분
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow) MoveSelection(-1);
                if (key == ConsoleKey.DownArrow) MoveSelection(1);
                //if (key == ConsoleKey.RightArrow) ;
                //if (key == ConsoleKey.LeftArrow) ;
                //if (key == ConsoleKey.Enter) ;
                //if (key == ConsoleKey.Escape) ;
            }
        }

        public UIDesign(List<ColorString> uIObject)
        {
            UIObject = uIObject;
            int selectableCount = 0;
            foreach (var obj in UIObject) //선택 가능한 줄의 갯수
            {
                if (obj.isSelectable) selectableCount++;
            }
            selectableIndex = new int[selectableCount]; //선택 가능한 줄 갯수로 배열 초기화.
            int j = 0;
            for (int i = 0; i < UIObject.Count; i++)
            {
                if (UIObject[i].isSelectable) selectableIndex[j++] = i; //선택 가능한 줄을 배열에 저장. 인덱스에 실제 줄 위치가 들어있는 형태.
            }
        }

        private void MoveSelection(int direction)
        {
            if (currentSelectdLineIndex == -1) //아무것도 선택되지 않았을경우
            {
                if (direction == -1) //윗방향키 누르면 거꾸로, 밑에서 위로.
                {
                    currentSelectdLineIndex = selectableIndex.Length - 1;
                }
                else if (direction == 1)
                {
                    currentSelectdLineIndex = 0;
                }
            }
            //선택이 있는 경우. 일반적인 상황.
            if (currentSelectdLineIndex == 0) //첫번째 줄일때 거꾸로 가게
            {
                lastSelectedLineIndex = currentSelectdLineIndex;
                currentSelectdLineIndex = selectableIndex.Length - 1;
            }
            else if (currentSelectdLineIndex == selectableIndex.Length - 1) //마지막 줄에 있었으니까
            {
                lastSelectedLineIndex = currentSelectdLineIndex;
                currentSelectdLineIndex = 0;
            }

        }

        private void UpdateSelecedState()
        {
            int index = selectableIndex[currentSelectdLineIndex];
            if (currentSelectdLineIndex != -1) UIObject[index].isSelected = true;
        }

    }

    /// <summary>
    /// ui를 만들때 필요한 데이터가 담겨있는 구조체.
    /// </summary>
    public struct ColorString
    {
        public ConsoleColor backColor;
        public ConsoleColor foreColor;
        public string str;
        public string tip;
        public bool isSelectable;
        public bool isSelected { get; set; }
        public bool showTip;
        public bool lineChange;

        /// <summary>
        /// 정보를 담아 객체를 생성합니다.
        /// </summary>
        /// <param name="str">보여지는 부분입니다.</param>
        /// <param name="backColor">str의 배경 색을 지정합니다.</param>
        /// <param name="textColor">str의 글자 색을 지정합니다.</param>
        /// <param name="selectable">str은 선택 가능.</param>
        /// <param name="selected">내부적으로 사용됩니다.</param>
        /// <param name="tip">하단에 설명을 표시합니다. string.</param>
        /// <param name="showTip">설명을 보여줄 지 여부입니다.</param>
        /// <param name="lineChange">기본값은 줄 바꿈이 일어납니다.</param>
        public ColorString
            (
            string str,
            ConsoleColor? backColor = null,
            ConsoleColor? textColor = null,
            bool selectable = false,
            bool selected = false,
            string tip = "지정된 설명이 없습니다.",
            bool showTip = false,
            bool lineChange = true)
        {
            this.str = str + (lineChange ? "\n" : "");
            this.tip = tip;
            this.backColor = backColor ?? Console.BackgroundColor;
            this.foreColor = textColor ?? Console.ForegroundColor;
            /*
             * 텍스트만 넣으면 기본 색으로 출력하게 하려고 했으나, 컴파일 타임 상수여야 한다는 에러 발생.
             * 이에 대한 해결책: null을 할당하면 되지 않을까? 그리고 런타임에서 이 구조체를 new 하면 그때는 런타임 상수니까 되지 않을까?
             * ?? 연산자로 null일때 콘솔의 기본 색상 값을 넣으면 되지 않을까?
             * 
             */
            this.isSelectable = selectable;
            this.isSelected = selected;
            this.showTip = showTip;
            this.lineChange = lineChange;
        }

        /// <summary>
        /// 줄 한칸을 띄웁니다.
        /// </summary>
        public ColorString()
        {
            str = "\n";
            this.tip = "";
            this.backColor = Console.BackgroundColor;
            this.foreColor = Console.ForegroundColor;
            this.isSelectable = false;
            this.isSelected = false;
            this.lineChange = false;
            this.showTip = false;
        }
    }
}
