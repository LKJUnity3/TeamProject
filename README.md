# Text-RPG 만들기 : 환생의 길, 시대를 넘어서 
스파르타 코딩 내일배움캠프 Unity 3기 3조의 팀프로젝트.


## 🎉프로젝트 소개
Visual Studio 를 이용해서 C#으로 제작한 프로그램입니다.
한효승과 3천궁녀를 컨셉으로 만든 환생의 길 , 시대를 넘어서 입니다. 
<br>


## 📅개발 기간
* 2024년 1월 9일 ~ 2024년 1월 16일

### 멤버구성
* 김혜림(팀장) - 콘솔꾸미기(외형, 스토리) , 몬스터 종류 추가, 직업 선택, 스테이지
* 김철우 - 스킬 기능 , 저장/불러오기
* 이광재 - 상태보기, 전투씬구현, 메인CS 관리
* 박지훈 - 아이템 적용, 회복아이템 , 사운드
* 채호선 - 치명타, 회피 , 레벨업, 전투보상, 사운드

### 🏟️개발 환경
* Visual Studio 2022
* C#
* .NET 8.0
* Windows
* Nugat 패키지

## 주요기능
* 필수기능 - 게임 시작화면, 상태보기, 전투시작 

* 선택기능 - 
콘솔꾸미기 ,캐릭터 생성 기능, 직업 선택 기능, 스킬 기능, 치명타 & 회피 기능, 
아이템 적용, 스테이지 추가, 게임 저장 , 레벨업 기능, 보상 추가 기능 

* 나만의 기능 - 던전별 효과음, 전투중 포션 사용, 스킬 효과음, 던전 별 스토리 구현

## CS 구성 

### <메인>
* Program : GameManager와 같이 전체적인 모든 파일의 근본이자 메인
  
### <플레이어>
* Player : 플레이어의 기본 직업별 스탯 & 스킬, 이름 & 직업 설정 , 레벨업 설정
  
* Enemy : 몬스터별의 기본 스탯 & 이름, 각 던전별 몬스터 랜덤 스폰 설정, 아이템 보상 추가 기능
  
* Item : 아이템 기본, 장비 & 포션 아이템 리스트 , 아이템 정보 표시 , 인벤토리 메뉴, 장착 메뉴 , 아이템 장착시 변경되는 스탯변경 , 상점 , 상점 내 구매
  
* Stat : 직업 리스트 및 기본 세팅
  
* Scene : 게임 시작화면 

### <배틀>
* Dungeon : 던전 타입 , 선택지 입력, 던전 난이도 선택,  던전 입장컷(hp양에 따른)
  
* BattleScene :
  배틀선택 여부, 몬스터 세팅, 플레이어 & 적 , 어태커 변수 저장 , 배틀 시작화면
  스킬 선택 창 & 정보 나열 & 선택, 소모 아이템 사용, 몬스터 Dead표시 ,공격 스킬 이용 대상 선택
  스킬 효과 발현 Ui, skill 효과에 따른 적용 및 UI 표시 , 스킬 데미지 계산 & 적용
  적 죽음, 변수 감소 , 소모 아이템 페이지, 게임 승패 여부 , 골드 & 경험치 획득 
  
* Skill: skill 전체정보 리스트 배열, 각 스테이지 타입 설정, skill의 타입 및 저장, 각 직업별 스킬 모두 입력
  
### <기타>
* DataStore : 플레이어 데이터 저장 및 불러오기 기능
  
* DamageProcess :
  스킬 최소& 최대 데미지 계산, 크리티컬, 회피여부, 플레이어 공격 & 회피 & 크리티컬 계산, 적 공격& 회피 & 크리티컬 값 계산,
  플레이어 최소 & 최대 데미지 , 특수효과 스킬, 현재 및 최종 체력
  
* Story : 게임의 전체적인 스토리
  
* Sound : 게임 시작 배경음, 던전별 배경음, 스킬 효과음 
  

## 게임 구성 

### 장르 : 1인칭 텍스트 RPG 게임

### 스토리 요약 :
게임의 주인공, 게임 개발자를 꿈꾸던 취준생은 횡단보도에서 차에 치여 억울하게 사망합니다. 
신은 그에게 환생의 기회를 주며 대한민국 역사를 체험해야 한다고 전합니다.
주인공은 삼국시대, 조선, 현대 대한민국을 탐험하며 
각 시대의 전쟁, 문화, 도전을 경험하고, 마지막으로 얻은 지혜와 성장을 통해 환생의 문을 열기 위한 시험에 맞서게 됩니다.

### 연출 : 
게임 개발자를 꿈꾸던 주인공의 억울한 죽음과 환생을 통해 대한민국 역사를 체험하며 성장하는 이야기를 
다양한 시대와 상황에서 풀어내는, 흥미진진한 여정을 그린다.

### 몬스터 : 
- 게임 1부: 삼국시대
    : 왜군,  당나라군 ,백제군, 의자왕
    
- 게임 2부: 조선시대
    : 황희, 정약용 , 수양대군, 이순신, 세종대왕
  
- 게임 3부: 대한민국
     : 퇴사 일보 직전 김대리, 만성피로 박과장, 워커홀릭 차현 본부장, 김상무 , 한효승 매니저님
  
### 직업 : 
- 김유신(검사)
- 이성계(궁수)
- 홍길동(주술사)
- 허준(약사)

### 플레이 방식 :
주인공은 각 시대의 다양한 던전을 클리어하여, 적들과 전투를 벌여야 합니다.
던전을 클리어하면 게임 내 재화와 경험치를 얻을 수 있습니다.
얻은 경험치로 체력이  일정 수준에 도달하면 다음 시대로 이동할 수 있습니다

## 자세한  정보는 팀 노션에서 
*https://www.notion.so/3-741b3b8cdf3d445a805512a23870aba4?pvs=4


