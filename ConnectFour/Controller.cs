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
                        Message2 = "Invalid comand. Continue? Please type \"Y\" or \"N\"";
                        //Message = "";
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

            string[] sCol = new string[7];
            for (int col = 0; col < 7; col++)
            {
                for (int row = 0; row < 6; row++)
                {
                    sCol[col] += GameBoard.board[row, col];

                }
                if (sCol[col].Contains("XXXX"))
                {
                    Message = $"Congratulations {playerOne.playerName}. YOU WIN ! ! !";
                    playerOne.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }
                else if (sCol[col].Contains("OOOO"))
                {
                    Message = $"Congratulations {playerTwo.playerName}. YOU WIN ! ! !";
                    playerTwo.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }

            }

            string[] sDiag1 = new string[6];
            sDiag1[0] = GameBoard.board[2, 0] + GameBoard.board[3, 1] + GameBoard.board[4, 2] + GameBoard.board[5, 3];
            sDiag1[1] = GameBoard.board[1, 0] + GameBoard.board[2, 1] + GameBoard.board[3, 2] + GameBoard.board[4, 3] + GameBoard.board[5, 4];
            sDiag1[2] = GameBoard.board[0, 0] + GameBoard.board[1, 1] + GameBoard.board[2, 2] + GameBoard.board[3, 3] + GameBoard.board[4, 4] + GameBoard.board[5, 5];
            sDiag1[3] = GameBoard.board[0, 1] + GameBoard.board[1, 2] + GameBoard.board[2, 3] + GameBoard.board[3, 4] + GameBoard.board[4, 5]+ GameBoard.board[5, 6];
            sDiag1[4] = GameBoard.board[0, 2] + GameBoard.board[1, 3] + GameBoard.board[2, 4] + GameBoard.board[3, 5]+ GameBoard.board[4,6];
            sDiag1[5] = GameBoard.board[0, 3] + GameBoard.board[1, 4] + GameBoard.board[2, 5] + GameBoard.board[3, 6];

            for (int diag1 = 0; diag1 < 6; diag1++)
            {
                if (sDiag1[diag1].Contains("XXXX"))
                {
                    Message = $"Congratulations {playerOne.playerName}. YOU WIN ! ! !";
                    playerOne.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }
                else if (sDiag1[diag1].Contains("OOOO"))
                {
                    Message = $"Congratulations {playerTwo.playerName}. YOU WIN ! ! !";
                    playerTwo.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }

            }

            string[] sDiag2 = new string[6];
            sDiag2[0] = GameBoard.board[0, 3] + GameBoard.board[1, 2] + GameBoard.board[2, 1] + GameBoard.board[3, 0];
            sDiag2[1] = GameBoard.board[0, 4] + GameBoard.board[1, 3] + GameBoard.board[2, 2] + GameBoard.board[3, 1] + GameBoard.board[4, 0];
            sDiag2[2] = GameBoard.board[0, 5] + GameBoard.board[1, 4] + GameBoard.board[2, 3] + GameBoard.board[3, 2] + GameBoard.board[4, 1] + GameBoard.board[5, 0];
            sDiag2[3] = GameBoard.board[0, 6] + GameBoard.board[1, 5] + GameBoard.board[2, 4] + GameBoard.board[3, 3] + GameBoard.board[4, 2] + GameBoard.board[5, 1];
            sDiag2[4] = GameBoard.board[1, 6] + GameBoard.board[2, 5] + GameBoard.board[3, 4] + GameBoard.board[4, 3] + GameBoard.board[5, 2];
            sDiag2[5] = GameBoard.board[2, 6] + GameBoard.board[3, 5] + GameBoard.board[4, 4] + GameBoard.board[5, 3];

            for (int diag2 = 0; diag2 < 6; diag2++)
            {
                if (sDiag2[diag2].Contains("XXXX"))
                {
                    Message = $"Congratulations {playerOne.playerName}. YOU WIN ! ! !";
                    playerOne.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }
                else if (sDiag2[diag2].Contains("OOOO"))
                {
                    Message = $"Congratulations {playerTwo.playerName}. YOU WIN ! ! !";
                    playerTwo.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }

            }

            if (GameBoard.board[0, 0] != " " && GameBoard.board[0, 1] != " " && GameBoard.board[0, 2] != " " && GameBoard.board[0, 3] != " " && GameBoard.board[0, 4] != " " && GameBoard.board[0, 5] != " " && GameBoard.board[0, 6] != " ")
            {
                Message = $"The game ended in a draw";
                playerOne.score++;
                playerTwo.score++;
                Screen.DisplayGameBoard(playerOne, playerTwo);
                return true;
            }

            return false;
        }


        public static int ValidColumn(Player playerOne, Player playerTwo)
        {
            if(actualPlayer is ComputerPlayer)
            {
                while (true)
                {
                    Random r = new Random();
                    int randomColumn = r.Next(1, 8);

                }

            }



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
            Screen.TypePlayersScreen("Let's start a game against Computer","");
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
                    OnePlayerGame();
                    break;
                case "2":
                    TwoPlayersGame();
                    break;
                case "3":
                    Screen.ShowHelp();
                    break;
                case "4":
                    Screen.TypePlayersScreen("Thanks for play!","");
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



