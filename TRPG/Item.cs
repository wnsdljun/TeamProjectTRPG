using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class Item : IStatus
    {
        public Item(string _itemName, ItemType _itemType, int _hp, 
            int _mp, int _atk, int _def)
        {
            this.itemName = _itemName;
            this.itemType = _itemType;
            ((IStatus)this).hp = _hp;
            ((IStatus)this).mp = _mp;
            ((IStatus)this).atk = _atk;
            ((IStatus)this).def = _def;
        }

        public string itemName { get; }
        public ItemType itemType { get; }
        int IStatus.hp { get; set; }
        int IStatus.mp { get; set; }
        int IStatus.atk { get; set; }
        int IStatus.def { get; set; }

        /// <summary>
        /// 아이템을 장착 메소드 
        /// </summary>
        public void EquipItem()
        {

        }

        /// <summary>
        /// 아이템을 해제하는 메소드
        /// </summary>
        public void ReleaseItem()
        {

        }


    }

    enum ItemType
    {
        Weapon,
        Armor,
        Shoes,
        Potion
    }
}
