using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class Skill
    {
        public static List<Skill_DataSet> skilldatabase = new List<Skill_DataSet>//skill 전체정보 리스트 배열
        {
            new Skill_DataSet(SkillType.Attack, "크게 베기", "칼을 크게 휘둘러 베는 스킬", 5, stat.JobList.검사,StageType.삼국시대),
            new Skill_DataSet(SkillType.Attack, "큰 화살 쏘기", "큰 화살을 쏘아 데미지를 주는 스킬", 5, stat.JobList.궁수,StageType.삼국시대),
            new Skill_DataSet(SkillType.Attack, "이동 타격", "상대 뒤로 이동하여 타격을 가하는 스킬", 5, stat.JobList.주술사,StageType.삼국시대),
            new Skill_DataSet(SkillType.Attack, "돌 던지기", "상대에게 돌을 던져서 타격을 가하는 스킬", 5, stat.JobList.약사,StageType.삼국시대),

            new Skill_DataSet(SkillType.Defense, "방어", "칼로 상대의 공격을 방어하는 스킬", 5, stat.JobList.검사,StageType.삼국시대),
            new Skill_DataSet(SkillType.Defense, "활 방어", "활로 상대의 공격을 방어하는 스킬", 5, stat.JobList.궁수,StageType.삼국시대),
            new Skill_DataSet(SkillType.Defense, "부적 방어", "부적으로 상대의 공격을 방어하는 스킬", 5, stat.JobList.주술사,StageType.삼국시대),
            new Skill_DataSet(SkillType.Defense, "가방 방어", "가방으로 상대의 공격을 방어하는 스킬", 5, stat.JobList.약사,StageType.삼국시대),

            new Skill_DataSet(SkillType.Heal, "힐", "체력을 회복하는 스킬", 5, stat.JobList.약사,StageType.삼국시대),
            new Skill_DataSet(SkillType.Heal, "침술", "스스로의 몸에 침을 꽂아 체력을 회복하는 스킬", 10, stat.JobList.약사,StageType.삼국시대),

            new Skill_DataSet(SkillType.Support, "Fire Sword", "칼에 불을 인챈트하는 스킬", 5, stat.JobList.검사,StageType.삼국시대),
            new Skill_DataSet(SkillType.Support, "Ice Arrow", "화살에 얼음 속성을 인챈트하는 스킬", 5, stat.JobList.궁수,StageType.삼국시대),
            new Skill_DataSet(SkillType.Support, "분신술", "분신술을 만들어서 회피력을 높이는 스킬", 20, stat.JobList.주술사,StageType.삼국시대),
            new Skill_DataSet(SkillType.Support, "기도", "신의 의술을 가진 화타에게 기도하여 체력을 증가하는 스킬", 20, stat.JobList.약사,StageType.삼국시대)
        };
        public static List<Skill_DataSet> characterSkill = new List<Skill_DataSet>(); // 캐릭터가 소지한 skill

        public enum StageType //stage가 삼국시대, 조선, 한국, 전부해당으로 구성
        {
            삼국시대,
            조선,
            대한민국,
            All
        }
        public enum SkillType //skill의 타입이 공격, 방어, 힐, 서포트로 구성
        {
            Attack,
            AttackPercent,
            Defense,
            DefensePercent,
            Heal,
            HealPercent,
            Support,
            Special
        }
        public class Skill_DataSet
        {
            public SkillType skilltype;
            public string skillname;
            public string skillInfo;
            public int skillDamage;
            public stat.JobList jobName;
            //stat.JobType jobName; //파일이름.enum명칭 변수명 선언가능
            // 검사, 궁수, 주술사, 힐러, 전부로 구분된 enum의 상수값을 받기 위한 변수
            StageType stagetype;//삼국시대, 조선, 대한민국, 전부로 구분된 enum의 상수값을 받기 위한 변수

            public Skill_DataSet(SkillType type, string name, string Info, int statusNumber, stat.JobList jobName, StageType stage)
            {
                this.skilltype = type;
                this.skillname = name;
                this.skillInfo = Info;
                this.skillDamage = statusNumber;
                this.jobName = jobName;
                this.stagetype = stage;
            }
            public void SkillDamage()
            {
                
            }
        }

        public static void SetSkill(stat.JobList jobName) //직업에 맞는 스킬 2개를 랜덤하게 설정
        {
            int SkillCount = 0;
            Random rand = new Random();
            for(int i=0; SkillCount<1; i++)
            {
                int id = rand.Next(0, skilldatabase.Count());
                if (skilldatabase[id].jobName == jobName)
                {
                    characterSkill.Add(skilldatabase[id]);
                    SkillCount++;
                }
            }
        }


    }
}
