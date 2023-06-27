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
        public static Player starterPlayer;
        public static Player actualPlayer;
        public static List<string> validsPlays = new List<string>();

        public static void Initialize()
        {
            Screen.InitialScreen();
        }

        public static void Start(Player playerOne, Player playerTwo )
        {

            while (true)
            {
                SortFirstPlayer(playerOne, playerTwo);
                GameBoard.InitializeGameBoard();
                validsPlays.Clear();
                validsPlays.Add("11");
                validsPlays.Add("12");
                validsPlays.Add("13");
                validsPlays.Add("21");
                validsPlays.Add("22");
                validsPlays.Add("23");
                validsPlays.Add("31");
                validsPlays.Add("32");
                validsPlays.Add("33");
                Message2 = "";
                Screen.DisplayGameBoard(playerOne, playerTwo);

            while(true)
            {
                UpdateValidsPlays();
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

        private static void SortFirstPlayer(Player playerOne, Player playerTwo)
        {
            if (starterPlayer is null)
            {
                int x = r.Next(1, 3);

                switch (x)
                {
                    case 1:
                        turn = "X";
                        Message = $" Player {playerOne.playerName} will start! Choose a row and column";
                        starterPlayer = actualPlayer = playerOne;
                        break;
                    case 2:
                        turn = "O";
                        Message = $" Player {playerTwo.playerName} will start! Choose a row and column";
                        starterPlayer = actualPlayer = playerTwo;
                        break;
                }

            }
            else if (starterPlayer == playerOne)
            {
                turn = "O";
                starterPlayer = actualPlayer = playerTwo;

            }
            else
            {
                turn = "X";
                starterPlayer = actualPlayer = playerOne;
            }

            Message = $" Player {playerOne.playerName} will start! Choose a row and column";

        }

        private static void UpdateValidsPlays()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (GameBoard.board[row, col] != " ")
                    {
                        validsPlays.Remove((row + 1).ToString() + (col + 1).ToString());
                    }
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

            string[] sRow = new string[3];
            for (int row = 0; row <3; row++)
            {
                for(int col = 0; col < 3; col++)
                {
                    sRow[row] += GameBoard.board[row, col];

                }
                if (sRow[row].Contains("XXX"))
                {
                    Message = $"Congratulations {playerOne.playerName}. YOU WIN ! ! !";
                    playerOne.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }else if (sRow[row].Contains("OOO"))
                {
                    Message = $"Congratulations {playerTwo.playerName}. YOU WIN ! ! !";
                    playerTwo.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }
                
            }

            string[] sCol = new string[3];
            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    sCol[col] += GameBoard.board[row, col];

                }
                if (sCol[col].Contains("XXX"))
                {
                    Message = $"Congratulations {playerOne.playerName}. YOU WIN ! ! !";
                    playerOne.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }
                else if (sCol[col].Contains("OOO"))
                {
                    Message = $"Congratulations {playerTwo.playerName}. YOU WIN ! ! !";
                    playerTwo.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }

            }

            string sDiag1 = GameBoard.board[0, 0] + GameBoard.board[1, 1] + GameBoard.board[2, 2];

            if (sDiag1.Contains("XXX"))
            {
                Message = $"Congratulations {playerOne.playerName}. YOU WIN ! ! !";
                playerOne.score++;
                Screen.DisplayGameBoard(playerOne, playerTwo);
                return true;
            }
            else if (sDiag1.Contains("OOO"))
            {
                Message = $"Congratulations {playerTwo.playerName}. YOU WIN ! ! !";
                playerTwo.score++;
                Screen.DisplayGameBoard(playerOne, playerTwo);
                return true;
            }

            string sDiag2 = GameBoard.board[0, 2] + GameBoard.board[1, 1] + GameBoard.board[2, 0];
            if (sDiag2.Contains("XXX"))
                {
                    Message = $"Congratulations {playerOne.playerName}. YOU WIN ! ! !";
                    playerOne.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }
                else if (sDiag2.Contains("OOO"))
                {
                    Message = $"Congratulations {playerTwo.playerName}. YOU WIN ! ! !";
                    playerTwo.score++;
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                    return true;
                }

            if (GameBoard.board[0, 0] != " " && GameBoard.board[0, 1] != " " && GameBoard.board[0, 2] != " " &&
                GameBoard.board[1, 0] != " " && GameBoard.board[1, 1] != " " && GameBoard.board[1, 2] != " " &&
                GameBoard.board[2, 0] != " " && GameBoard.board[2, 1] != " " && GameBoard.board[2, 2] != " ")
            {
                Message = $"The game ended in a draw";
                playerOne.score++;
                playerTwo.score++;
                Screen.DisplayGameBoard(playerOne, playerTwo);
                return true;
            }

            return false;
        }


        public static string ValidPlay(Player playerOne, Player playerTwo)
        {
            if(actualPlayer is ComputerPlayer)
            {
                while (true)
                {
                    int x;
                    Random r = new Random();
                    int randomPlay = r.Next(1, 4);
                    x = randomPlay * 10;
                    randomPlay = r.Next(1, 4);
                    x += randomPlay;
                    if (validsPlays.Any(p => p == x.ToString()))
                    {
                        Message2 = "";
                        return x.ToString();
                    }
                }

            }



            while (true) {
                string userCommand = Console.ReadKey().KeyChar.ToString();
                userCommand += Console.ReadKey().KeyChar.ToString();

                if (validsPlays.Any(p => p == userCommand)){
                    Message2 = "";
                    return userCommand;
                }
                else
                {
                    Message2 = "Invalid Play. Try again";
                    Screen.DisplayGameBoard(playerOne, playerTwo);
                }
            
            }
        }

        public static void PutAPiece(int n, string turn)
        {
            int row = n/10 - 1;
            int col = n - 10 * (row + 1)-1;
            GameBoard.board[row, col] = turn;
                       
        }

        private static void ChangeTurn(Player playerOne, Player playerTwo)
        {
            if (turn == "O")
            {
                actualPlayer = playerOne;
                turn = "X";
                Message = $"It's {actualPlayer.playerName} turn. Choose a row and column number:";
                Screen.DisplayGameBoard(playerOne, playerTwo);

            }
            else
            {
                actualPlayer = playerTwo;
                turn = "O";
                Message = $"It's {actualPlayer.playerName} turn. Choose a row and column number:";
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



