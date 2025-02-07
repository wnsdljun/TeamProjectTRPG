using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class ShopItem : IStatus
    {
        public ShopItem(bool purchase, string itemName, int itemPrice, ItemType itemType, int hp, int mp, int atk, int def)
        {
            this.purchase = purchase;
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.itemType = itemType;
            ((IStatus)this).hp = hp;
            ((IStatus)this).mp = mp;
            ((IStatus)this).atk = atk;
            ((IStatus)this).def = def;
        }

        public bool purchase { get; set; }
        public string itemName { get; set; }
        public int itemPrice { get; }
        public ItemType itemType { get; }
        int IStatus.hp { get; set; }
        int IStatus.mp { get; set; }
        int IStatus.atk { get; set; }
        int IStatus.def { get; set; }

    }
}
