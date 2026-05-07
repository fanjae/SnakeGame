namespace SnakeGame
{
    internal class Game
    {
        private Board gameBoard;
        private Snake snake;
        private ConsoleRenderer renderer;
        
        public void InitGame() // 게임 초기화
        {
            gameBoard = new Board(16, 16);
            snake = new Snake(8, 8);
            renderer = new ConsoleRenderer();

            gameBoard.UpdateSnakeBoard(snake.GetBodyPositions());
            gameBoard.CreateFood();

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            renderer.Render(gameBoard, snake.CurrentDirection);
        }
        public void RenderBoard() // 보드 렌더링 요청
        {
            gameBoard.ClearSnake();
            gameBoard.UpdateSnakeBoard(snake.GetBodyPositions());

            Console.SetCursorPosition(0, 0); // 커서 고정으로 출력 상태 유지
            renderer.Render(gameBoard, snake.CurrentDirection);
        }
        public void PlayGame()
        {
            ConsoleKeyInfo input_key;
            Position nextHead;
            Direction new_dir;
            bool foodEat = false;

            InitGame();
            while (true)
            {
                new_dir = snake.CurrentDirection;
                if(Console.KeyAvailable)
                {
                    input_key = Console.ReadKey();

                    switch(input_key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            new_dir = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            new_dir = Direction.Down;
                            break;
                        case ConsoleKey.LeftArrow:
                            new_dir = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            new_dir = Direction.Right;
                            break;
                        default:
                            break;
                    }

                }
                snake.ChangeDirection(new_dir);

                // 다음 위치
                nextHead = snake.GetNextHeadPosition();
                foodEat = gameBoard.IsFood(nextHead);
                if (gameBoard.IsCrash(nextHead))
                {
                    RenderBoard();
                    Lose();
                    break;
                }

                // 이동 진행
                snake.Move(foodEat);
                if(foodEat)
                {
                    if(gameBoard.CreateFood() == false) // 먹이를 만들 빈 칸이 더 이상 없음 = 뱀이 모든 공간을 차지
                    {
                        RenderBoard();
                        Win();
                        break;
                    }
                }

                RenderBoard();
                Thread.Sleep(250);
            }
        }
        public void Lose()
        {
            Console.WriteLine("뱀이 벽이나 몸통에 부딪혔습니다.");
            Console.WriteLine("엔터를 누르면 메뉴로 이동합니다.");
            Console.ReadLine();
        }
        public void Win()
        {
            Console.WriteLine("축하드립니다. 당신은 뱀의 왕입니다.");
            Console.WriteLine("엔터를 누르면 메뉴로 이동합니다.");
            Console.ReadLine();
        }
    }
}
