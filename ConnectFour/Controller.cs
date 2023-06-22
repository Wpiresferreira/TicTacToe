using System;

namespace ConnectFour
{
    public static class Controller
    {
        public static void Start(Player playerOne, Player playerTwo )
        {
            GameBoard.InitializeGameBoard();
            Screen.DisplayGameBoard(playerOne, playerTwo);
        }

        public static void TwoPlayersGame() {
            Console.WriteLine("Let's start a game with 2 Players");

            Player playerOne = new HumanPlayer("One");
            Player playerTwo = new HumanPlayer("Two");
            Controller.Start(playerOne, playerTwo);

        }






        public static void CheckOption()
    {
        string option = Console.ReadKey().KeyChar.ToString();

        switch (option)
        {
            case "1":
                Console.WriteLine("One Player vs Computer");
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



