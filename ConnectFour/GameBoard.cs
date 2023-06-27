using System;

namespace ConnectFour
{
    public static class GameBoard
    {
        public static string[,] board = new string[3, 3];
        
        public static void InitializeGameBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = " ";
                }
            }
        }
    }
}
