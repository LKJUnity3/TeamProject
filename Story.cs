using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class Story
    {
        // Prologue: 게임 개발자의 억울한 죽음과 환생 기회
        public static async Task Prologue()
        {
            Console.WriteLine("게임 개발자를 꿈꾸던 주인공은 스파르타 코딩클럽에서 열심히 공부하던 중,");
            Console.WriteLine("횡단보도에서의 차량 사고로 억울하게 세상을 떠나게 된다.");
            Console.WriteLine("하지만 주인공은 그의 이야기가 끝나지 않았음을 깨닫는다.");

            Console.WriteLine("신은 억울하게 죽은 주인공에게 환생의 기회를 주기로 한다.");
            Console.WriteLine("환생을 위해서는 대한민국의 각 역사를 체험해야 한다.");
            Console.WriteLine("주인공은 삼국시대, 조선, 현 대한민국을 각각 탐험하여 통과해야만 환생할 수 있다.");
            Console.WriteLine("이제 주인공은 대한민국의 각 시대를 체험하며 자신의 운명을 다시 쓰기로 한다.");

            // 대화를 기다리며 화면을 지연시킵니다.
            await Task.Delay(3000);
        }

        // Chapter 1: 삼국시대의 도전
        public static async Task Chapter1()
        {
            Console.WriteLine("환생의 첫 번째 시대는 삼국시대이다.");
            Console.WriteLine("주인공은 고구려, 백제, 신라 등 다양한 나라를 돌아다니며 새로운 기술을 배우고,");
            Console.WriteLine("게임 개발에 필요한 전략적인 사고를 키운다.");
            Console.WriteLine("역사 속의 무명의 영웅으로서 어려운 과제를 수행하면서,");
            Console.WriteLine("삼국시대의 지혜와 용기를 경험한다.");

            // 대화를 기다리며 화면을 지연시킵니다.
            await Task.Delay(3000);
        }

        // Chapter 2: 조선시대의 모험
        public static async Task Chapter2()
        {
            Console.WriteLine("삼국시대에서의 경험을 토대로 주인공은 조선시대로 이동한다.");
            Console.WriteLine("여기서는 훈민정음을 창제하거나, 한글을 통해 게임 시나리오를 작성하는 등의 임무를 수행한다.");
            Console.WriteLine("또한 왕족들과의 교류를 통해 게임 캐릭터의 다양한 성격을 더욱 풍부하게 만들어가며,");
            Console.WriteLine("조선시대의 문화와 예절을 체험한다.");

            // 대화를 기다리며 화면을 지연시킵니다.
            await Task.Delay(3000);
        }

        // Chapter 3: 현대 대한민국의 도전
        public static async Task Chapter3()
        {
            Console.WriteLine("조선시대에서의 경험을 살려 현대 대한민국으로 도전하는 주인공.");
            Console.WriteLine("여기서는 최신 기술과 트렌드를 활용하여 현대적인 게임을 개발한다.");
            Console.WriteLine("다양한 역할과 협업을 통해 게임 제작 프로세스를 체험하며,");
            Console.WriteLine("현실 세계의 도전과 고난에 부딪혀 게임 개발자로서의 진정한 역량을 키운다.");

            // 대화를 기다리며 화면을 지연시킵니다.
            await Task.Delay(3000);
        }

        // Epilogue: 환생의 기적
        public static async Task Epilogue()
        {
            Console.WriteLine("세 시대의 모든 도전과 임무를 성공적으로 마치게 된 주인공.");
            Console.WriteLine("환생의 기적은 현실로부터 게임 개발자로의 부활을 의미한다.");
            Console.WriteLine("주인공은 다시 세상으로 돌아와 스파르타 코딩클럽에서의 꿈을 이루게 되며,");
            Console.WriteLine("억울하게 끝난 삶을 새롭게 시작한다.");

            // 대화를 기다리며 화면을 지연시킵니다.
            await Task.Delay(3000);
        }
    }
}
