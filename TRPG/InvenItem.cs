using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class InvenItem : Item
    {
        public InvenItem(bool installed, string itemName, int itemPrice, ItemType itemType, int hp, int mp, int atk, int def)
        {
            Installed = installed;
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.itemType = itemType;
            this.hp = hp;
            this.mp = mp;
            this.atk = atk;
            this.def = def;
        }

        public bool Installed { get; set; }
        public string itemName { get; set; }
        public int itemPrice { get; }
        public ItemType itemType { get; }
        public int hp { get; set; }
        public int mp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
    }
}
