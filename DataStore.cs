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

        public static bool DataSelect()//데이터 불러오기 선택 창
        {
            Console.Clear();
            Console.WriteLine("데이터를 불러오시겠습니까?");
            Console.WriteLine("");
            Console.WriteLine("[0] 새로하기");
            Console.WriteLine("[1] 이어하기");
            
        dataChoose:
            Console.Write("\n>>");
            string dataSelect = Console.ReadLine();
            int dataNumb;
            if(int.TryParse(dataSelect, out dataNumb))
            {
                if(dataNumb ==0)
                {
                    return false;
                }
                else if(dataNumb ==1)
                {
                    try
                    {
                        DataLoad();
                    }
                    catch//불러올 데이터가 없으면 예외 처리, 신규 캐릭터 생성으로 진행됨
                    {
                        Console.WriteLine("이전에 저장한 데이터가 없습니다. 신규 캐릭터를 생성하겠습니다");
                        Thread.Sleep(600);
                        return false;
                    }

                    return true;
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                    goto dataChoose;
                }
            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                goto dataChoose;
            }
        }
    }
}
