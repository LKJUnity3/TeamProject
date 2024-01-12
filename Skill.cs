using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class Skill
    {
        public static List<Skill_DataSet> skilldatabase = new List<Skill_DataSet>(); //skill 전체정보 리스트 배열
        public static List<Skill_DataSet> characterSkill = new List<Skill_DataSet>(); // 캐릭터가 소지한 skill

        public enum StageType //stage가 삼국시대, 조선, 한국, 전부해당으로 구성
        {
            Samguk,
            Josun,
            Korea,
            All
        }
        public enum SkillType //skill의 타입이 공격, 방어, 힐, 서포트로 구성
        {
            Attack,
            Defense,
            Heal,
            Support,
        }
        public class Skill_DataSet
        {
            private int skillnumber;
            SkillType skilltype;
            private string skillname;
            private string skillInfo;
            private float skillDamage;
            //stat.JobType jobName; //파일이름.enum명칭 변수명 선언가능
            // 검사, 궁수, 주술사, 힐러, 전부로 구분된 enum의 상수값을 받기 위한 변수
            StageType stagetype;//삼국시대, 조선, 대한민국, 전부로 구분된 enum의 상수값을 받기 위한 변수

            public Skill_DataSet(int number, SkillType type, string name, string Info, float damage, int jobNumber, StageType stage)
            {
                this.skillnumber = number;
                this.skilltype = type;
                this.skillname = name;
                this.skillInfo = Info;
                this.skillDamage = damage;
                //this.jobNumber = jobNumber;
                this.stagetype = stage;
            }
            public void SkillDamage()
            {
                
            }
        }


    }
}
