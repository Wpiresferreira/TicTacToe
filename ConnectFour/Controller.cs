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

        public static List<string> validsColumns = new List<string>(){"1", "2", "3", "4", "5", "6", "7"};

        private static void SortFirstPlayer(Player playerOne, Player playerTwo)
        {
           int x = r.Next(1, 3);

            switch (x)
            {
                case 1:
                    turn = "X";
                    Message = $" Player {playerOne.playerName} will start! Choose a Column";
                    break;
                case 2:
                    turn = "O";
                    Message = $" Player {playerTwo.playerName} will start! Choose a Column";
                    break;

            }


        }
        public static void Start(Player playerOne, Player playerTwo )
        {
            GameBoard.InitializeGameBoard();
            SortFirstPlayer(playerOne, playerTwo);
            Screen.DisplayGameBoard(playerOne, playerTwo);

            while(!isEndOfGame)
            {
                int columnchosenColumn = ValidColumn(playerOne, playerTwo);
                PutAPiece(columnchosenColumn, turn);
                Screen.DisplayGameBoard(playerOne, playerTwo);
                ChangeTurn();
                Message = $"It's {ActualPlayer(playerOne, playerTwo)} turn. Choose a column number:";
                Screen.DisplayGameBoard(playerOne, playerTwo);


            }
        }

        private static string ActualPlayer(Player playerOne, Player playerTwo)
        {
            if (turn == "X")
            {
                return playerOne.playerName;
            }
            else
            {
                return playerTwo.playerName;
            }
        }

        private static int ValidColumn(Player playerOne, Player playerTwo)
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

        private static void PutAPiece(int n, string turn)
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

        private static void ChangeTurn()
        {
            if (turn == "O")
            {
                turn = "X";
            }
            else {  turn = "O"; }
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



