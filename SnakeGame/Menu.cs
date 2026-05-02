namespace SnakeGame
{
    internal class Menu
    {
        private string menu_input;

        public bool MyParse(string input, out int number) // 파싱
        {
            return int.TryParse(input, out number) && (number >= 1 && number <= 4);
        }
        public int Choose_Menu() // 메뉴 고르기
        {
            int number;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================");
                Console.WriteLine("=====[SNAKE GAME]=====");
                Console.WriteLine("======================");
                Console.WriteLine("=====[1.게임시작]=====");
                Console.WriteLine("=====[2.게임방법]=====");
                Console.WriteLine("=====[3. 크레딧 ]=====");
                Console.WriteLine("=====[4.  종료  ]=====");
                Console.WriteLine("======================");
                Console.WriteLine("======================");
                Console.Write("숫자를 입력 하세요 : ");
                menu_input = Console.ReadLine();
                if(menu_input == null || MyParse(menu_input, out number) == false)
                {
                    Console.WriteLine("유효한 값을 입력하시길 바랍니다.");
                    continue;
                }
                return number;
            }
        }
        public void How_To_Play() // 플레이 방법
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("============[ 게임소개 ]==============");
            Console.WriteLine("======================================");
            Console.WriteLine("스네이크 게임은 사방이 막힌 네모난");
            Console.WriteLine("뱀을 조종하여 먹이를 먹는 게임입니다.");
            Console.WriteLine("먹이를 먹으면 뱀의 길이가 길어집니다.");
            Console.WriteLine("뱀은 현재 머리가 향하고 있는 방향으로");
            Console.WriteLine("멈추지 않고, 계속 이동합니다.");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine("============[ 조작방법 ]==============");
            Console.WriteLine("======================================");
            Console.WriteLine("↑ ↓ ← → : 스네이크 머리 방향 이동");
            Console.WriteLine("뱀은 머리를 반대로 돌릴 수 없습니다.");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("======================================");
            Console.WriteLine("============[ 승리조건 ]==============");
            Console.WriteLine("======================================");
            Console.WriteLine("뱀이 보드판의 모든 영역을 차지한 경우");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine("============[ 패배조건 ]==============");
            Console.WriteLine("======================================");
            Console.WriteLine("1. 벽에 머리를 부딪힌 경우");
            Console.WriteLine("2. 자신의 몸 일부에 머리를 부딪힌 경우");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("계속 하려면 아무키나 누르세요.");

            Console.ReadKey();
        }
        public void Credits() // 크레딧
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("============[  크레딧  ]==============");
            Console.WriteLine("======================================");
            Console.WriteLine("Made By. FanJae");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("계속 하려면 아무키나 누르세요.");
            Console.ReadKey();
        }
        public void exit()
        {
            Console.Clear();
            Console.WriteLine("프로그램을 종료합니다.");
        }
    }
}
