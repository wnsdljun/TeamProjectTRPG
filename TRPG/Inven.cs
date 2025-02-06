using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class Inven
    {
        List<Item> items =new List<Item>();

        /// <summary>
        /// 스텟을 줄이고 + 가방에서 그 아이템 삭제
        /// </summary>
        /// <param name="itemName"></param>
        public void ItemDelete(string itemName,Player player)
        {
            Item foundItem =items.Find(Item => Item.itemName == itemName);
            //스텟을 감소시키기
            StatusDecrease(foundItem,player);
            //삭제
            items.Remove(foundItem);
        }

        /// <summary>
        /// 가방에 아이템 추가 
        /// </summary>
        /// <param name="_item"></param>
        public void ItemAdd(Item _item)
        {
            items.Add(_item);
        }
        /// <summary>
        /// 아이템에 대한 수치마큼 스텟에서 제외시켜줘
        /// </summary>
        /// <param name="foundItem"></param>
        public void StatusDecrease(Item? foundItem,Player player)
        {
            //player의 스텟이 구성되면 그 구성된 수치에서 제외시켜주기 

        }
    }
}
