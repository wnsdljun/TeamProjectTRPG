namespace TRPG
{
    internal class Inven
    {
        //private GameManager gameManager;

        public Inven()
        {
           // this.gameManager = manager;
        }

        public void ShowInven(Player _player)
        {

            bool bool_showinven = false;
            while (!bool_showinven)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("인벤토리");
                Console.ResetColor();
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

                Item_list_show(GameManager.Instance.inventoryItems);

                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");


                //그럼 가방에서 삭제를 안하는시스템? > ok

                int input;
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 0:
                            //나가기 
                            bool_showinven = true;
                            break;
                        case 1:
                            //장착관리 
                            Install_item(_player);

                            break;

                        default:
                            Console.WriteLine("아이템을 가방에서 가져오는 도중에 오류가 발생했습니다");
                            Thread.Sleep(1000);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("숫자를 입력하세요");
                    Thread.Sleep(1000);
                }
            }


        }

        private void Install_item(Player _player)
        {
            bool bool_1 = false;
            while (!bool_1)
            {
                Console.Clear();
                Item_list_show(GameManager.Instance.inventoryItems);
                Console.WriteLine("장착하거나 해제하고 싶은 아이템 이름을 입력해주세요 (나가기 :0):");
                Console.Write(">>>");
                string answer = Console.ReadLine();
                int number;
                if (!string.IsNullOrEmpty(answer) && GameManager.Instance.inventoryItems.Any(x => x.itemName == answer))
                {
                    var item_Find = GameManager.Instance.inventoryItems.Find(x => x.itemName == answer);

                    //장착
                    if (item_Find.Installed == false)
                    {
                        //장착하면 E 버튼 생성 
                        item_Find.Installed = true;
                        //아이템 스텟에 추가    
                        StatusSetting(item_Find,'+');
                    }
                    else  // 해제
                    {
                        //해제하면 E버튼 없애기
                        item_Find.Installed = false;
                        //아이템 스텟 해제
                        StatusSetting(item_Find,'-');
                    }


                }
                else if (int.Parse(answer) ==0)
                {
                    bool_1 = true;
                }
                else
                {
                    Console.WriteLine("잘못된 문자 입니다 다시 입력해주세요");
                    Thread.Sleep(1000);
                }
            }
        }

        private static void Item_list_show(List<InvenItem> inven_list)
        {
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("============================================================");
            Console.WriteLine($"{"이름",-17}{"종류",-10}{"가격",-5}{"HP",-5}{"MP",-6}{"공격력",-7}{"방어력",-4}");

            foreach (var x in inven_list)
            {
                IStatus status = x;
                string install = x.Installed ? "E" : " ";

                if (install == "E")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[{install}]{x.itemName,-14}{x.itemType,-10}{x.itemPrice,-8}{status.hp,-6}{status.mp,-6}{status.atk,-8}{status.def,-6}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"[{install}]{x.itemName,-14}{x.itemType,-10}{x.itemPrice,-8}{status.hp,-6}{status.mp,-6}{status.atk,-8}{status.def,-6}");
                }

            }
            Console.WriteLine("============================================================");
        }


        /// <summary>
        /// 스텟을 줄이기
        /// </summary>
        /// <param name="itemName"></param>
        public void ItemDelete(string itemName)
        {
            InvenItem foundItem = GameManager.Instance.inventoryItems.Find(Item => Item.itemName == itemName);
            //스텟을 감소시키기
            StatusSetting(foundItem,'-');
            //삭제
            //items.Remove(foundItem);
        }

        /// <summary>
        /// 가방에 아이템 추가 
        /// </summary>
        /// <param name="_item"></param>
        public void ItemAdd(InvenItem _item)
        {
            GameManager.Instance.inventoryItems.Add(_item);
        }
        public void ItemAdd(bool installed, string itemName, int itemPrice, ItemType itemType, int hp, int mp, int atk, int def)
        {
            InvenItem newItem_inven = new InvenItem(installed, itemName, itemPrice, itemType, hp, mp, atk, def);
            GameManager.Instance.inventoryItems.Add(newItem_inven);
        }
        /// <summary>
        /// 아이템에 대한 수치마큼 스텟에서  '+' or '-'
        /// </summary>
        /// <param name="foundItem"></param>
        public void StatusSetting(InvenItem foundItem,char _char)
        {
            //player의 스텟이 구성되면 그 구성된 수치에서 제외시켜주기 
            if (_char == '+')
            {
                GameManager.Instance.selectedChampion.hp +=foundItem.hp;
                GameManager.Instance.selectedChampion.mp += foundItem.mp;
                GameManager.Instance.selectedChampion.atk += foundItem.atk;
                GameManager.Instance.selectedChampion.def +=foundItem.def;
            }
            else if (_char == '-')
            {
                GameManager.Instance.selectedChampion.hp -= foundItem.hp;
                GameManager.Instance.selectedChampion.mp -= foundItem.mp;
                GameManager.Instance.selectedChampion.atk -= foundItem.atk;
                GameManager.Instance.selectedChampion.def -= foundItem.def;
            }
            else
            {

            }

        }




    }
}
