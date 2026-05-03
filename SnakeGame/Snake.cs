
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
        public Direction GetDirection()
        {
            return currentDirection;
        }

        public Position GetHeadPosition() // 헤드 정보 얻어오기
        {
            return SnakeBody.GetHeadPosition();
        }

        public Position GetNextHeadPosition() // 다음 헤드 정보 얻어오기
        {
            Position head = SnakeBody.GetHeadPosition();

            int x = head.GetX();
            int y = head.GetY();

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
            SnakeBody.AddFront(nextHead.GetX(), nextHead.GetY());

            if(!foodEat)
            {
                SnakeBody.DeleteBack();
            }

        }
    }
}
