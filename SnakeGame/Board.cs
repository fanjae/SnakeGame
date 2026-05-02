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

        enum BoardSet { Wall=1, Normal, SnakeBody, SnakeHead, Food };
        public Board(int x, int y)
        {
            gameBoard = new int[x, y];
            this.x = x;
            this.y = y;

            InitializeBoardWallSet();
        }
        private void InitializeBoardWallSet() // 보드 벽 초기화(보드 생성시 활용)
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
        private bool BoardIndexCheck(int x, int y) // 보드 범위를 넘는 로직 체크
        {
            if (x < 0 || y < 0) return false;
            if (this.x < x || this.y < y) return false;
            return true;
        }
        public void PrintBoard() // 게임 보드판 출력
        {
            for (int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    switch (gameBoard[i,j]) 
                    {
                        case (int)BoardSet.Wall:
                            Console.Write("▣");
                            break;
                        case (int)BoardSet.Normal:
                            Console.Write("□");
                            break;
                        case (int)BoardSet.SnakeBody:
                            Console.Write("■");
                            break;
                        case (int)BoardSet.SnakeHead:
                            Console.Write("◀");
                            break;
                        case (int)BoardSet.Food:
                            Console.Write("");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public void UpdateSnakeBoard(Position[] positions) 
        {
            for(int i=0; i<positions.Length; i++)
            {
                gameBoard[positions[i].GetX(), positions[i].GetY()] = (int)BoardSet.SnakeBody;
            }
        }

    }
        
}
