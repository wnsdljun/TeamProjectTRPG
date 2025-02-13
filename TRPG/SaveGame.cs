using System.Text.Json;
using System.Text.Json.Nodes;

namespace TRPG
{
    internal class SaveData
    {
        public Player? player { get; set; } //당연히 필요하겠죠?
        public List<InvenItem>? inventoryItems { get; set; }
        public List<ShopItem>? items_list_shop { get; set; } //구매 기록 유지에 필요
    }

    partial class Player
    {
        public Player(Player p)
        {
            PlayerName = p.PlayerName;
            Level = p.Level;
            Exp = p.Exp;
            Gold = p.Gold;
            Championclass = p.Championclass;
        }
    }

    partial class GameManager
    {
        string defaultSavePath = "savefile.json";
        public void SaveGame()
        {
            //SaveData에 현재 게임 데이터를 넣고, SaveData를 json 문자열로 변환, 문자열을 파일에 쓰기.
            SaveData saveData = new SaveData() //기본 생성자가 적용되어 이렇게 초기화가 가능한건가?
            {
                player = this.player,
                inventoryItems = this.inventoryItems,
                items_list_shop = this.items_list_shop
            };

            string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
            //JsonSerializerOptions { WriteIndented = true } : 예쁘게 쓰기 (?)
            File.WriteAllText(defaultSavePath, json);
        }
        public void LoadGame()
        {
            //반대로, 파일을 읽어 불러온 json 형식의 문자열을 de-serialize 하여 SaveData에 저장, 그리고 각 위치에 갖다넣기.
            if (!File.Exists(defaultSavePath))
            {
                UI uI = new UI(new List<UIElement>
                {
                    new("저장된 세이브파일이 없습니다!")
                });

                uI.WriteAll("세이브파일이없습니다.", 2000);
            }
            else
            {
                string json = File.ReadAllText(defaultSavePath);
                SaveData loadData = JsonSerializer.Deserialize<SaveData>(json)!;
                //if (json != null) { loadData }
                if (loadData != null)
                {
                    player = loadData.player!;
                    inventoryItems = loadData.inventoryItems!;
                    items_list_shop = loadData.items_list_shop!;
                }
            }
        }
    }
}
