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
