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

            new Skill_DataSet(SkillType.SupportAtk, "Fire Sword", "칼에 불을 인챈트하는 스킬", 5, stat.JobList.검사,StageType.삼국시대),
            new Skill_DataSet(SkillType.SupportAtk, "Ice Arrow", "화살에 얼음 속성을 인챈트하는 스킬", 5, stat.JobList.궁수,StageType.삼국시대),
            new Skill_DataSet(SkillType.SupportSpecial, "분신술", "분신술을 만들어서 회피력을 높이는 스킬", 20, stat.JobList.주술사,StageType.삼국시대),
            new Skill_DataSet(SkillType.SupportHP, "기도", "신의 의술을 가진 화타에게 기도하여 체력을 증가하는 스킬", 20, stat.JobList.약사,StageType.삼국시대),

 
            new Skill_DataSet(SkillType.Special, "불패의 신화", "결코 패배하지 않는 전설, 공격력과 체력이 10000만큼 증가", 10000, stat.JobList.검사,StageType.All),
            new Skill_DataSet(SkillType.Special, "천하무적", "세상에 적수가 없다. 광역 3연속 공격 스킬", 100, stat.JobList.궁수,StageType.All),
            new Skill_DataSet(SkillType.Special, "의협심", "의리에 밝고 협조심이 많은 마음", 10000, stat.JobList.주술사,StageType.All),
            new Skill_DataSet(SkillType.Special, "민중의 영웅", "민중의 사랑을 받는 영웅", 10000, stat.JobList.주술사,StageType.조선),
            new Skill_DataSet(SkillType.Special, "명의", "모든 체력을 즉시 회복하고 다음 체력 회복 스킬부터는 효과 2배 상승", 0, stat.JobList.약사,StageType.All),
            new Skill_DataSet(SkillType.Special, "인술", "모든 체력을 즉시 회복하고 적으로부터 공격을 받지 아니함", 0, stat.JobList.약사,StageType.All),
        };

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
            SupportAtk,
            SupportDef,
            SupportHP,
            SupportSpecial,
            Special
        }
        public class Skill_DataSet
        {
            public SkillType skilltype;// 스킬 타입 저장
            public string skillname;
            public string skillInfo;
            public int skillDamage;
            public stat.JobList jobName;//스킬을 사용할 수 있는 직업, 저장을 위한 변수
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
        }

        public static void SetSkill(stat.JobList jobName) //직업에 맞는 스킬 전부 입력
        {
            int SkillCount = 0;
            Random rand = new Random();
            for(int i=0; i<skilldatabase.Count; i++)
            {
                if (skilldatabase[i].jobName == jobName || skilldatabase[i].jobName == stat.JobList.All)
                {
                    Player.player.characterSkill.Add(skilldatabase[i]);
                }
            }
        }


    }
}
