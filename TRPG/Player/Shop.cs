namespace TRPG
{
    internal class Shop
    {
        
        Inven inven;

        public Shop()
        {
        }

        public void ShopItem_Add()
        {
            GameManager.Instance.items_list_shop.Add(new ShopItem(false, "삼위일체", 3000, ItemType.Weapon, 30, 0, 15, 15));
            GameManager.Instance.items_list_shop.Add(new ShopItem(false, "몰락한왕의검", 3000, ItemType.Weapon, 0, 0, 40, 0));
            GameManager.Instance.items_list_shop.Add(new ShopItem(false, "얼어붙은심장", 2000, ItemType.Armor, 50, 0, 0, 30));
            GameManager.Instance.items_list_shop.Add(new ShopItem(false, "가시갑옷", 2500, ItemType.Armor, 40, 0, 0, 40));
            GameManager.Instance.items_list_shop.Add(new ShopItem(false, "광전사의군화", 1500, ItemType.Shoes, 0, 0, 15, 0));
            GameManager.Instance.items_list_shop.Add(new ShopItem(false, "판금장화", 1500, ItemType.Shoes, 0, 0, 0, 18));
        }

        public void ShowShop(Player _player, Inven _inven)
        {
            inven = _inven;
            bool bool_showShop = false;
            while (!bool_showShop)
            {
                //반복 기본 문장
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("상점");
                    Console.ResetColor();
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

                    Item_list_show(GameManager.Instance.items_list_shop, false);

                    Console.WriteLine("1. 아이템구매");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">>");
                }
                int input;
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 0:
                            //나가기 
                            bool_showShop = true;
                            break;
                        case 1:
                            //아이템구매 
                            Buy_item(_player, GameManager.Instance.items_list_shop);

                            break;

                        default:
                            Console.WriteLine("잘못된 숫자를 입력하셨습니다");
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

        private void Buy_item(object player, List<ShopItem> items_list_shop)
        {
            //player의 골드를 가져와서 구매해서 가방에 넣고 상점에서는 노란색으로 표시하기 그리고 구매못하게
            bool boolbuyShop = false;
            int number;
            while (!boolbuyShop)
            {
                //반복문장
                {
                    Console.Clear();
                    Console.WriteLine($"[보유한 골드] : {GameManager.Instance.player.Gold} G");
                    Console.WriteLine();
                    Item_list_show(items_list_shop, true);
                    Console.WriteLine();
                    Console.WriteLine("구매하실 아이템의 이름를 입력해주세요 :(나가기 :0)");
                    Console.Write(">>>");
                }
                string answer = Console.ReadLine();
                if (!string.IsNullOrEmpty(answer) && items_list_shop.Any(x => x.itemName == answer))
                {
                    var Buyitem = items_list_shop.Find(x => x.itemName == answer);
                    //골드가 있는경우
                    if (GameManager.Instance.player.Gold >= Buyitem.itemPrice)
                    {
                        //구매완료인템 
                        if (Buyitem.purchase == true)
                        {
                            Console.WriteLine("구매 완료된 템입니다. 다른 아이템을 구매해주세요");
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            int anser;
                            bool boolbuyShop_02 = false;
                            while (!boolbuyShop_02)
                            {
                                Console.Clear();
                                Console.WriteLine($"[보유한 골드] : {GameManager.Instance.player.Gold} G");
                                Console.WriteLine();
                                //Console.WriteLine($"구매하실 아이템 :{Buyitem.itemName} /가격 :{Buyitem.itemPrice}");
                                Console.WriteLine($"{"이름",-17}{"종류",-10}{"가격",-5}{"HP",-5}{"MP",-6}{"공격력",-7}{"방어력",-4}");
                                Console.WriteLine($"{Buyitem.itemName,-14}{Buyitem.itemType,-10}{Buyitem.itemPrice,-8}{Buyitem.hp,-6}{Buyitem.mp,-6}{Buyitem.atk,-8}{Buyitem.def,-6}");
                                Console.WriteLine();
                                Console.WriteLine("구매하시겠습니까? :(1:구매하기 /0:뒤로가기)");
                                Console.Write(">>> ");
                                if (int.TryParse(Console.ReadLine(), out anser))
                                {
                                    if (anser == 1)
                                    {
                                        //골드 차감 
                                        GameManager.Instance.player.Gold -= Buyitem.itemPrice;
                                        //상점에 표시
                                        Buyitem.purchase = true;
                                        //가방에 넣기
                                        inven.ItemAdd(false, Buyitem.itemName, Buyitem.itemPrice, Buyitem.itemType, Buyitem.hp, Buyitem.mp, Buyitem.atk, Buyitem.def);
                                        boolbuyShop_02= true;
                                        break;
                                    }
                                    else if (anser == 0)
                                    {
                                        boolbuyShop_02 = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("잘못된 입력입니다 다시 입력해주세요");
                                        Thread.Sleep(1000);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("잘못된 입력입니다 다시 입력해주세요");
                                    Thread.Sleep(1000);
                                }
                            }


                        }



                    }
                    else //골드 부족한 경우
                    {
                        Console.WriteLine("골드가 부족합니다 : ");
                        Thread.Sleep(1000);
                    }


                }
                else if (int.TryParse(answer, out number) && number == 0)
                {
                    boolbuyShop = true;
                }
                else
                {
                    Console.WriteLine("잘못된 이름입니다 다시입력해주세요");
                    Thread.Sleep(1000);
                }

            }
        }

        private void Item_list_show(List<ShopItem> items_list_shop, bool buybool)
        {

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("============================================================");
            Console.WriteLine($"{"이름",-17}{"종류",-10}{"가격",-5}{"HP",-5}{"MP",-6}{"공격력",-7}{"방어력",-4}");

            //shop아이템을 보여주면된다
            foreach (var x in items_list_shop)
            {
                IStatus status = x;
                string purchase = x.purchase ? "구매완료" : "";
                //구매완료 ==노란색 
                if (purchase == "구매완료")
                {
                    // 클릭을 못하게 해야됨 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[{purchase}]{x.itemName,-14}{x.itemType,-10}{x.itemPrice,-8}{status.hp,-6}{status.mp,-6}{status.atk,-8}{status.def,-6}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"[{purchase}]{x.itemName,-14}{x.itemType,-10}{x.itemPrice,-8}{status.hp,-6}{status.mp,-6}{status.atk,-8}{status.def,-6}");
                }

            }
            //invenlist에서 install이 'E'인 놈을찾아서 비교해서 같은 이름이라면 빨강색으로 표시후 구매 불가를 써줘야됨

            //구매 불가기능 아직안됨 
            Console.WriteLine("============================================================");
        }



        public void Add(ShopItem item)
        {
            GameManager.Instance.items_list_shop.Add(item);
        }
        public void Add(bool purchase, string itemName, int itemPrice, ItemType itemType, int hp, int mp, int atk, int def)
        {
            //음 어덯게 하는게 좋을까?
            ShopItem newitem = new ShopItem(purchase, itemName, itemPrice, itemType, hp, mp, atk, def);
            GameManager.Instance.items_list_shop.Add(newitem);
        }
    }
}
