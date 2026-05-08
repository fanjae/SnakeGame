namespace SnakeGame
{
    internal class Board
    {
        private CellType[,] gameBoard;
        private int x;
        private int y;
        private Random rand;

        public int Width
        {
            get { return x; }
        }
        public int Height
        {
            get { return y; }
        }

        public Board(int x, int y)
        {
            gameBoard = new CellType[x, y];
            this.x = x;
            this.y = y;
            rand = new Random();

            InitializeBoardWallSet();
        }

        public CellType GetCellType(int x, int y) // Cell Type 획득
        {
            return gameBoard[x, y];
        }
        private void InitializeBoardWallSet() // 보드 벽 초기화(보드 생성시에만 활용)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i == 0 || i == x - 1 || j == 0 || j == y - 1)
                    {
                        gameBoard[i, j] = CellType.Wall;
                    }
                    else
                    {
                        gameBoard[i, j] = CellType.Empty;
                    }
                }
            }
        }
        private bool BoardIndexCheck(int x, int y) // 보드 범위를 넘는 로직 체크 (Not Used)
        {
            if (x < 0 || y < 0) return false;
            if (this.x <= x || this.y <= y) return false;
            return true;
        }

        public void ClearSnake() // 스네이크 경로 정리
        {
            for(int i=0; i<x; i++)
            {
                for(int j=0; j<y; j++)
                {
                    if (gameBoard[i,j] == CellType.SnakeHead || gameBoard[i, j] == CellType.SnakeBody)
                    {
                        gameBoard[i, j] = CellType.Empty;
                    }
                }
            }
        }

        public void UpdateSnakeBoard(Position[] positions)  // 스네이크 경로 재업데이트
        {
            for(int i=0; i<positions.Length; i++) 
            {
                if (i == 0) gameBoard[positions[i].X, positions[i].Y] = CellType.SnakeHead;
                else gameBoard[positions[i].X, positions[i].Y] = CellType.SnakeBody;
            }
        }
        public bool IsFood(Position Target) // 먹이 확인
        {
            return gameBoard[Target.X, Target.Y] == CellType.Food;
        }

        private bool IsWall(Position Target) // 벽 위치 확인
        {
            return gameBoard[Target.X, Target.Y] == CellType.Wall;
        }

        private bool IsSnakeBody(Position Target) // 스네이크 몸체 확인
        {
            return gameBoard[Target.X, Target.Y] == CellType.SnakeBody;
        }

        public bool IsCrash(Position Target) // 벽이거나 스네이크의 몸을 만났으면 충돌.
        {
            return IsWall(Target) || IsSnakeBody(Target);
        }
        public bool CreateFood() // 먹이 만드는 함수
        {
            int empty_count = 0;
            int index_count = 0;
            int next_food_index = 0;
            for(int i=1; i<x; i++)
            {
                for(int j=1; j<y; j++)
                {
                    if (gameBoard[i,j] == CellType.Empty) // 빈 값 개수 확인
                    {
                        empty_count++;
                    }
                }
            }
            if(empty_count == 0) // 빈칸이 없으면 먹이를 만들 수 없음. 
            {
                return false;
            }

            next_food_index = rand.Next(empty_count);
            for(int i=1; i<x; i++)
            {
                for(int j=1; j<y; j++)
                {
                    if (gameBoard[i,j] == CellType.Empty) // 빈칸 체크
                    {
                        if (index_count == next_food_index) // 랜덤으로 뽑은 칸과 일치하는 인덱스에 먹이 배치
                        {
                            gameBoard[i, j] = CellType.Food;
                            return true;
                        }
                        else
                        {
                            index_count++;
                        }  
                    }
                }
            }
            return false; // Logical Error (도달 불가)
        }
    }
        
}
