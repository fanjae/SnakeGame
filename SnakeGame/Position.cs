namespace SnakeGame
{    
    struct Position // 좌표값 구조체
    {
        private readonly int x;
        private readonly int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get { return x; } }
        public int Y { get { return y; } }
    }
}
