using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TeamProject
{
    public class DataStore
    {
        public static void DataSave()
        {
            string filePath = "Player.json";
            //Json 데이터 저장
            string json = JsonConvert.SerializeObject(Player.player, Formatting.Indented);
            File.WriteAllText(filePath, json); // JSON 문자열을 파일로 저장
        }

        public static void DataLoad()
        {
            //Json 저장
            string filePath = "Player.json";
            string json = File.ReadAllText(filePath);
            // JSON 문자열로부터 아이템 리스트를 역직렬화
            Player.player = JsonConvert.DeserializeObject<Player>(json);
        }
    }
}
