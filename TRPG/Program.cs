namespace TRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! 지환!");

            Shop shop = new Shop();
            Inven inven = new Inven();
            Player player = new Player();
            List<Item> newitems_inven = new List<Item>()
            { 
                //string _itemName, ItemType _itemType, int _hp, int _mp, int _atk, int _def
                new Item("삼위일체",3000,ItemType.Weapon,30,0,15,15,false,false),
                new Item("몰락한왕의검",3000,ItemType.Weapon,0,0,40,0,false,false),
                new Item("얼어붙은심장",2000,ItemType.Armor,50,0,0,30,false,false),
                new Item("가시갑옷",2500,ItemType.Armor,40,0,0,40, false, false),
            };

            List<ShopItem> newitems_shop = new List<ShopItem>()
            { 
                //string _itemName, ItemType _itemType, int _hp, int _mp, int _atk, int _def
                new ShopItem(false,"삼위일체",3000,ItemType.Weapon,30,0,15,15),
                new ShopItem(false,"몰락한왕의검",3000,ItemType.Weapon,0,0,40,0),
                new ShopItem(false,"얼어붙은심장",2000,ItemType.Armor,50,0,0,30),
                new ShopItem(false,"가시갑옷",2500,ItemType.Armor,40,0,0,40),
                new ShopItem(false,"광전사의군화",1500,ItemType.Shoes,0,0,15,0),
                new ShopItem(false,"판금장화",1500,ItemType.Weapon,0,0,0,18)
            };

            foreach (var item in newitems_shop)
            {
                shop.Add(item);
            }
            while (true)
            {
                inven.ShowInven(newitems_inven, player);
                shop.ShowShop(newitems_inven, player);


            }
        }
    }
}
