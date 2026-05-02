
namespace SnakeGame
{
    internal class Snake
    {
        private MyList SnakeBody;
        public Snake(int x, int y)
        {
            SnakeBody = new MyList(x, y);
        }
        void Move()
        {
            
        }
        public Position[] GetBodyPositions()
        {
            return SnakeBody.GetPositions();
        }
        
    }
}
