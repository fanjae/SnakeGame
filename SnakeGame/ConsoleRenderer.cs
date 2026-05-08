namespace SnakeGame
{
    internal class ConsoleRenderer
    {
        private readonly String[] directionMarks = { "▲", "◀", "▼", "▶" };

        public void Render(Board board, Direction currentDirection)
        {
            for (int i = 0; i < board.Width; i++)
            {
                for (int j = 0; j < board.Height; j++)
                {
                    Console.Write(GetCellMark(board, i, j, currentDirection));
                }

                Console.WriteLine();
            }
        }
        private string GetCellMark(Board board, int x, int y, Direction currentDirection) // 셀 마크를 받아 출력 문자로 변환
        {
            CellType cellType = board.GetCellType(x, y); // 셀 상태를 받아옴

            switch (cellType)
            {
                case CellType.Wall:
                    return "▣";

                case CellType.Empty:
                    return "□";

                case CellType.SnakeBody:
                    return "■";

                case CellType.SnakeHead:
                    return directionMarks[(int)currentDirection];

                case CellType.Food:
                    return "●";

                default:
                    return "?";
            }
        }

    }
}
