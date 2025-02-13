using System.Text.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
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
        public static string defaultSavePath = "savefile.json";
        public void SaveGame()
        {
            //SaveData에 현재 게임 데이터를 넣고, SaveData를 json 문자열로 변환, 문자열을 파일에 쓰기.
            SaveData saveData = new SaveData() //기본 생성자가 적용되어 이렇게 초기화가 가능한건가?
            {
                player = this.player,
                inventoryItems = this.inventoryItems,
                items_list_shop = this.items_list_shop
            };

            string json = JsonConvert.SerializeObject(saveData, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
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
                SaveData loadData = JsonConvert.DeserializeObject<SaveData>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All})!;
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
    public class SaveLoad
    {
        public static void ui_Save()
        {
            UI ui = new UI(new List<UIElement>
            {
                new("게임을 저장하시겠습니까?"),
                new(),
                new("네",selectable: true, tip: "진행 상황을 저장합니다."),
                new("아니옹",selectable: true, tip: "저장하지 않고 돌아갑니다.")
            });

            ui.WriteAll();
            int input = ui.UserUIControl();

            if (input == 1) return;
            
            GameManager.Instance.SaveGame();
        }
        public static void ui_LoadAtStart()
        {
            UI ui = new UI(new List<UIElement>
            {
                new("세이브파일이 감지되었습니다."),
                new("세이브파일을 불러오시겠습니까?"),
                new(),
                new("네",selectable: true, tip: "이어서 플레이 합니다."),
                new("아니옹",selectable: true, tip: "처음부터 다시 플레이 합니다.")
            });

            ui.WriteAll();
            int input = ui.UserUIControl();

            if (input == 1)
            {
                GameManager.Instance.shop.ShopItem_Add();
                GameManager.Instance.inven.BaseItemAdd();
                GameManager.Instance.Chi_Champion();
                return;
            }
            GameManager.Instance.LoadGame();
        }
    }
}
