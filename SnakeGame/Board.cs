using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Board
    {
        private int[,] gameBoard;
        private int x;
        private int y;
        private Random rand;
        private string[] direction_mark = { "▲", "◀", "▼", "▶" };

        enum BoardSet { Wall=1, Normal, SnakeBody, SnakeHead, Food };
        public Board(int x, int y)
        {
            gameBoard = new int[x, y];
            this.x = x;
            this.y = y;
            rand = new Random();

            InitializeBoardWallSet();
        }
        private void InitializeBoardWallSet() // 보드 벽 초기화(보드 생성시에만 활용)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i == 0 || i == x - 1 || j == 0 || j == y - 1)
                    {
                        gameBoard[i, j] = (int)BoardSet.Wall;
                    }
                    else
                    {
                        gameBoard[i, j] = (int)BoardSet.Normal;
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

        public string GetSnakeHeadMark(Direction currentDirection)
        {
            return direction_mark[(int)currentDirection];
        }
        public void PrintBoard(Direction currentDirection) // 게임 보드판 출력
        {
            for (int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    switch (gameBoard[i,j]) 
                    {
                        case (int)BoardSet.Wall: // 벽
                            Console.Write("▣");
                            break;
                        case (int)BoardSet.Normal: // 일반 칸
                            Console.Write("□");
                            break;
                        case (int)BoardSet.SnakeBody: // 몸체
                            Console.Write("■");
                            break;
                        case (int)BoardSet.SnakeHead: // 머리
                            Console.Write(GetSnakeHeadMark(currentDirection));
                            break;
                        case (int)BoardSet.Food: // 음식
                            Console.Write("●");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public void ClearSnake() // 스네이크 경로 정리
        {
            for(int i=0; i<x; i++)
            {
                for(int j=0; j<y; j++)
                {
                    if (gameBoard[i,j] == (int)BoardSet.SnakeHead || gameBoard[i, j] == (int)BoardSet.SnakeBody)
                    {
                        gameBoard[i, j] = (int)BoardSet.Normal;
                    }
                }
            }
        }

        public void UpdateSnakeBoard(Position[] positions)  // 스네이크 경로 재업데이트
        {
            for(int i=0; i<positions.Length; i++) 
            {
                if (i == 0) gameBoard[positions[i].X, positions[i].Y] = (int)BoardSet.SnakeHead;
                else gameBoard[positions[i].X, positions[i].Y] = (int)BoardSet.SnakeBody;
            }
        }
        public bool IsFood(Position Target) // 먹이 확인
        {
            return gameBoard[Target.X, Target.Y] == (int)BoardSet.Food;
        }

        private bool IsWall(Position Target) // 벽 위치 확인
        {
            return gameBoard[Target.X, Target.Y] == (int)BoardSet.Wall;
        }

        private bool IsSnakeBody(Position Target) // 스네이크 몸체 확인
        {
            return gameBoard[Target.X, Target.Y] == (int)BoardSet.SnakeBody;
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
                    if (gameBoard[i,j] == (int)BoardSet.Normal) // 빈 값 개수 확인
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
                    if (gameBoard[i,j] == (int)BoardSet.Normal) // 빈칸 체크
                    {
                        if (index_count == next_food_index) // 랜덤으로 뽑은 칸과 일치하는 인덱스에 먹이 배치
                        {
                            gameBoard[i, j] = (int)BoardSet.Food;
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
