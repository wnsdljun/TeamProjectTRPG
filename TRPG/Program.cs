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

            List<InvenItem> newitems_inven = new List<InvenItem>()
            { 
                //string _itemName, ItemType _itemType, int _hp, int _mp, int _atk, int _def
                new InvenItem(false,"삼위일체",3000,ItemType.Weapon,30,0,15,15),
                new InvenItem(false,"몰락한왕의검",3000,ItemType.Weapon,0,0,40,0),
                new InvenItem(false,"얼어붙은심장",2000,ItemType.Armor,50,0,0,30),
                new InvenItem(false,"가시갑옷",2500,ItemType.Armor,40,0,0,40)
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
            foreach (var item in newitems_inven)
            {
                inven.ItemAdd(item);
            }
            while (true)
            {
                inven.ShowInven(player);
                shop.ShowShop(player,inven);


            }
        }
    }
}
