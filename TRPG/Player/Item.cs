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
