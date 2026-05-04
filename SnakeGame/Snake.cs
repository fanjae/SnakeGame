
using System.ComponentModel;

namespace SnakeGame
{
    internal class Snake
    {
        private MyList SnakeBody;
        private Direction currentDirection;

        public Snake(int x, int y)
        {
            SnakeBody = new MyList(x, y);
            currentDirection = Direction.Up;
        }
      
        public Position[] GetBodyPositions()
        {
            return SnakeBody.GetPositions();
        }

        public void ChangeDirection(Direction newDirection)
        {
            if(((int)currentDirection + 2) % 4 != (int) newDirection) // 뱀은 자신의 반대 방향으로 바로 이동할 수 없다.
            {
                currentDirection = newDirection;
            }  
        }

        public Direction CurrentDirection
        {
            get { return currentDirection; }
        }

        public Position HeadPosition // 헤드 정보 얻어오기
        {
            get { return SnakeBody.HeadPosition; }
        }

        public Position GetNextHeadPosition() // 다음 헤드 정보 얻어오기
        {
            Position head = SnakeBody.HeadPosition;

            int x = head.X;
            int y = head.Y;

            switch(currentDirection)
            {
                case Direction.Up:
                    x--;
                    break;
                case Direction.Down:
                    x++;
                    break;
                case Direction.Left:
                    y--;
                    break;
                case Direction.Right:
                    y++;
                    break;  
            }
            return new Position(x, y);
        }

        public void Move(bool foodEat) // 이동
        {
            Position nextHead = GetNextHeadPosition();
            SnakeBody.AddFront(nextHead.X, nextHead.Y);

            if(!foodEat)
            {
                SnakeBody.DeleteBack();
            }

        }
    }
}
