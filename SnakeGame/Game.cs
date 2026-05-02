namespace SnakeGame
{
    internal class Game
    {
        private Board gameBoard;
        private Snake snake;
        public Game()
        {
            gameBoard = new Board(20, 30);
            snake = new Snake(20 / 2, 30 / 2);
        }
        public void PlayGame()
        {
            while (true)
            {
                gameBoard.PrintBoard();
                gameBoard.UpdateSnakeBoard(snake.GetBodyPositions());
                //snake.move();
                

                Thread.Sleep(100);
            }
        }
    }
}
