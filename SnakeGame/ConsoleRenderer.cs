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
        private string GetCellMark(Board board, int x, int y, Direction currentDirection)
        {
            if (board.IsWall(x, y)) return "▣";
            if (board.IsEmpty(x, y)) return "□";
            if (board.IsSnakeBody(x, y)) return "■";
            if (board.IsSnakeHead(x, y)) return directionMarks[(int)currentDirection];
            if (board.IsFood(x, y)) return "●";

            return "?";
        }

    }
}
