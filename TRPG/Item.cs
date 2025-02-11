using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal interface Item : IStatus
    {
        public string itemName { get; set; }
        public int itemPrice { get; }
        public ItemType itemType { get; }
        int hp { get; set; }
        int mp { get; set; }
        int atk { get; set; }
        int def { get; set; }




    }

    enum ItemType
    {
        Weapon,
        Armor,
        Shoes,
        Potion
    }
}
