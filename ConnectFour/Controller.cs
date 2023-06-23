using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ConnectFour
{
    public static class Controller
    {
        public static string turn = "O";
        public static Random r = new Random();
        public static string Message = "";
        public static string Message2 = "";
        public static bool isEndOfGame = false;
        public static Player actualPlayer;
        public static List<string> validsColumns = new List<string>(){"1", "2", "3", "4", "5", "6", "7"};

        private static void SortFirstPlayer(Player playerOne, Player playerTwo)
        {
           int x = r.Next(1, 3);

            switch (x)
            {
                case 1:
                    turn = "X";
                    Message = $" Player {playerOne.playerName} will start! Choose a Column";
                    actualPlayer = playerOne;
                    break;
                case 2:
                    turn = "O";
                    Message = $" Player {playerTwo.playerName} will start! Choose a Column";
                    actualPlayer = playerTwo;
                    break;

            }


        }
        public static void Start(Player playerOne, Player playerTwo )
        {
            SortFirstPlayer(playerOne, playerTwo);

            while (true)
            {
                GameBoard.InitializeGameBoard();
                validsColumns.Clear();
                validsColumns.Add("1");
                validsColumns.Add("2");
                validsColumns.Add("3");
                validsColumns.Add("4");
                validsColumns.Add("5");
                validsColumns.Add("6");
                validsColumns.Add("7");
                Message2 = "";
                Screen.DisplayGameBoard(playerOne, playerTwo);

            while(true)
            {
                UpdateValidsColumns();
                Screen.DisplayGameBoard(playerOne, playerTwo);
                actualPlayer.PutAPiece(playerOne, playerTwo);
                Screen.DisplayGameBoard(playerOne, playerTwo);
                if (CheckWinner(playerOne, playerTwo)) break;
                ChangeTurn(playerOne, playerTwo);
                Message = $"It's {actualPlayer.playerName} turn. Choose a column number:";
                Screen.DisplayGameBoard(playerOne, playerTwo);


            }
            if(Continue(playerOne, playerTwo))
                {
                    ChangeTurn(playerOne, playerTwo);
                    Message2 = "";
                    Screen.DisplayGameBoard(playerOne, playerTwo);

                    continue;
                }
                else
                {
                    break;
                }
            }
            Console.ReadKey();

        }

        private static void UpdateValidsColumns()
        {
            for (int col =0; col<7; col++)
            {
                if (GameBoard.board[0,col] != " ")
                {
                    validsColumns.Remove((col+1).ToString());
                }
            }
        }

        private static bool Continue(Player playerOne, Player playerTwo)
        {
            Message2 = "Do you want continue playing? (Y/N)";
            Screen.DisplayGameBoard(playerOne, playerTwo);

            while (true)
            {
                string answer = Console.ReadKey().KeyChar.ToString().ToLower();

                switch(answer)
                {
                    case "y":
                        return true;
                    case "n":
                        Message = "Thanks for playing!";
                        Message2 = "";
                        Screen.DisplayGameBoard(playerOne, playerTwo);
                        return false;
                    default:
                        Message = "Invalid comand. Please type \"Y\" or \"N\"";
                        Message2 = "";
                        Screen.DisplayGameBoard(playerOne, playerTwo);
                        break;
                }
            }
            

        }

        private static bool CheckWinner(Player playerOne, Player playerTwo)
        {
            string[] sRow = new string[6];
            for (int row = 0; row <6; row++)
            {
                for(int col = 0; col < 7; col++)
                {
                    sRow[row] += GameBoard.board[row, col];

                }
                if (sRow[row].Contains("XXXX"))
                {
                    Message = $"Congratulations {playerOne.playerName}. YOU WIN ! ! !";
                    playerOne.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }else if (sRow[row].Contains("OOOO"))
                {
                    Message = $"Congratulations {playerTwo.playerName}. YOU WIN ! ! !";
                    playerTwo.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }
                
            }
                return false;
        }

        //private static Player ActualPlayer()
        //{
        //    if (turn == "X")
        //    {
        //        return playerOne;
        //    }
        //    else
        //    {
        //        return playerTwo;
        //    }
        //}

        public static int ValidColumn(Player playerOne, Player playerTwo)
        {   
            while(true) {
                string userCommand = Console.ReadKey().KeyChar.ToString();
                if (validsColumns.Any(p => p == userCommand)){
                    Message2 = "";
                    return int.Parse(userCommand);
                }
                else
                {
                    Message2 = "Invalid Column. Try again";
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                }
            
            }
        }

        public static void PutAPiece(int n, string turn)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (GameBoard.board[i, n - 1] == " ")
                {
                    GameBoard.board[i, n - 1] = turn;
                    return;
                }
            }
        }

        private static void ChangeTurn(Player playerOne, Player playerTwo)
        {
            if (turn == "O")
            {
                actualPlayer = playerOne;
                turn = "X";
                Message = $"It's {actualPlayer.playerName} turn. Choose a column number:";
                Screen.DisplayGameBoard(playerOne, playerTwo);

            }
            else
            {
                actualPlayer = playerTwo;
                turn = "O";
                Message = $"It's {actualPlayer.playerName} turn. Choose a column number:";
                Screen.DisplayGameBoard(playerOne, playerTwo);

            }
        }

        public static void TwoPlayersGame() {
            Console.WriteLine("Let's start a game with 2 Players");

            Player playerOne = new HumanPlayer("One");
            Player playerTwo = new HumanPlayer("Two");
            Controller.Start(playerOne, playerTwo);
        }

        public static void OnePlayerGame()
        {
            Console.WriteLine("Let's start a game against Computer");

            Player playerOne = new HumanPlayer("One");
            Player playerTwo = new ComputerPlayer();
            Controller.Start(playerOne, playerTwo);
        }

        public static void CheckOption()
    {
        string option = Console.ReadKey().KeyChar.ToString();


            switch (option)
            {
                case "1":
                    Console.WriteLine("One Player vs Computer");
                    OnePlayerGame();
                    break;
                case "2":
                    Console.WriteLine("Two Players Game");
                    TwoPlayersGame();
                    break;
                case "3":
                    Console.WriteLine("Help / About the game");
                    Screen.ShowHelp();
                    break;
                case "4":
                    Console.WriteLine("\n\nThanks for the game!");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("\nInvalid Option!\nPlease Select a valid option\n\n Press any key to continue...");
                    Console.ReadKey();
                    Screen.InitialScreen();
                    break;
            }

        }

    }

}



