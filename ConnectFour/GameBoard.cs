﻿using System;

namespace ConnectFour
{
    public static class GameBoard
    {
        public static string[,] board = new string[6, 7];
        private static bool hasWinnerOrTie = false;
        

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

       



        private static bool PlayAgain()
        {
            while (true)
            {
                Console.WriteLine("Do you want play again?\nPlease type Y/N:\n");
                string s = Console.ReadLine().ToLower();

                if (s == "y")
                {
                    return true;
                }
                else if (s == "n")
                {
                    return false;
                }
            }
        }
        private static string CheckWinner()
        {
            return "";
        }
        //private static void ChangeTurn()
        //{
        //    if (turn == "O")
        //    {
        //        turn = "X";
        //    }
        //    else
        //    {
        //        turn = "O";
        //    }

        //}
        
        public static void Start()
        {
            string winner = "";
            InitializeGameBoard();
            bool gameActive = true;
            while (!hasWinnerOrTie && gameActive)
            {
                Console.Clear();
                //DisplayGameBoard();
                //Play(turn);
                winner = CheckWinner();
                if (winner != "")
                {
                    break;
                }
                //ChangeTurn();
            }
        }
        public static void Play(string turn)
        {

            if (turn == "O")
            {
                Console.WriteLine("It's Player 1 turn \"O\"");
            }
            else
            {
                Console.WriteLine("It's Player 2 turn \"X\"");
            }

            string command = Console.ReadLine();

            int column = CheckCommand(command);
        }
        public static int CheckCommand(string command)
        {
            int ncommand;

            if (command.ToLower() == "exit")
            {
                return 0;
            }
            else if (int.TryParse(command, out ncommand))
            {
                if (ncommand >= 1 && ncommand <= 7)
                {
                    //PutAPiece(ncommand, turn);
                }
            }
            return ncommand;
        }

        public static void PutAPiece(int n, string turn)
        {

            for (int i = 5; i >= 0; i--)
            {
                if (board[i, n - 1] == " ")
                {
                    board[i, n - 1] = turn;
                    return;
                }
            }
            Console.WriteLine("There is no space in this column.");
            Console.ReadLine();
        }

    }
}
