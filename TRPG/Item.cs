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
        




    }

    enum ItemType
    {
        Weapon,
        Armor,
        Shoes,
        Potion
    }
}
