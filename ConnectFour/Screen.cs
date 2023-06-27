using System;
using System.Net.Http;

namespace ConnectFour
{

    public static class Screen
    {

        public static void InitialScreen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("████████████████████████████████████████████████████████████");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("███             Welcome to Tic Tac Toe Game              ███");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("████████████████████████████████████████████████████████████");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("███   Choose a option                                    ███");
            Console.WriteLine("███   1 - One Player vs Computer Game                    ███");
            Console.WriteLine("███   2 - Two Players Game                               ███");
            Console.WriteLine("███   3 - Help / About the game                          ███");
            Console.WriteLine("███   4 - Exit                                           ███");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("████████████████████████████████████████████████████████████");
            Console.WriteLine("████████████████████████████████████████████████████████████");
            Console.WriteLine("███ Developed by Wagner Pires Ferreira 2023 ████████████████");
            Console.WriteLine("████████████████████████████████████████████████████████████");

            Controller.CheckOption();

        }

        public static void DisplayGameBoard(Player playerOne, Player playerTwo)
        {
            Console.Clear();
            Header(playerOne, playerTwo);
            Body();
            Bottom();
        }
        public static void Token(string token)
        {
            switch (token)
            {
                case "X":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("X");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "O":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("O");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case " ":
                    Console.Write(" ");
                    break;

            }
        }

        public static void Header(Player one, Player two)
        {
            Console.Clear();
            Console.WriteLine($"████████████████████████████████████████████████████████████");
            Console.WriteLine($"███ {one,-15}                      {two,15} ███");
            Console.Write($"███ Token: ");
            Token("X");
            Console.Write("          Tic Tac Toe Game          Token: ");
            Token("O");
            Console.Write(" ███\n");
            Console.WriteLine($"███ Wins: {one.score,2}                                    Wins: {two.score,2} ███");
            Console.WriteLine($"████████████████████████████████████████████████████████████");
        }

        public static void Body()
        {
            Console.WriteLine($"███                                                      ███");
            Console.WriteLine($"███{Controller.Message,-52}  ███");
            Console.WriteLine($"███                                                      ███");
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("███              1   2   3                               ███");
                    Console.WriteLine("███            ╔═══╦═══╦═══╗                             ███");
                }
                Console.Write($"███          {i+1} ║ ");
                for (int j = 0; j < 3; j++)
                {
                    Token(GameBoard.board[i, j]);
                    Console.Write(" ║ ");
                }
                Console.Write("                            ███\n");
                if (i != 2)
                {
                    Console.WriteLine("███            ╠═══╬═══╬═══╣                             ███");
                }
                else
                {
                    Console.WriteLine("███            ╚═══╩═══╩═══╝                             ███");
                }
            }
            Console.WriteLine($"███                                                      ███");
        }

        public static void Bottom()
        {
            Console.WriteLine($"███                                                      ███");
            Console.WriteLine($"███{Controller.Message2,-52}  ███");
            Console.WriteLine($"███                                                      ███");
            Console.WriteLine($"████████████████████████████████████████████████████████████");

        }

        public static void TypePlayersScreen(string msg, string msg2)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("████████████████████████████████████████████████████████████");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("███             Welcome to Tic Tac Toe Game              ███");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("████████████████████████████████████████████████████████████");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine($"███  {msg, -52}███");
            Console.WriteLine($"███  {msg2,-52}███");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("████████████████████████████████████████████████████████████");
            Console.WriteLine("████████████████████████████████████████████████████████████");
            
        }
            
            public static void ShowHelp()
        {
            Console.Clear();
            Console.WriteLine("████████████████████████████████████████████████████████████");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("███                  About Tic Tac Toe                   ███");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("████████████████████████████████████████████████████████████");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("███  Tic Tac Toes is a paper-and-pencil game for two     ███");
            Console.WriteLine("███  players who take turns marking the spaces in a      ███");
            Console.WriteLine("███  three-by-three grid with X or O. The player who     ███");
            Console.WriteLine("███  succeeds in placing three of their marks in a       ███");
            Console.WriteLine("███    horizontal,                                       ███");
            Console.WriteLine("███    vertical, or                                      ███");
            Console.WriteLine("███    diagonal                                          ███");
            Console.WriteLine("███  row is the winner.                                  ███");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("███                                                      ███");
            Console.WriteLine("███                            source:wikipedia.org      ███");
            Console.WriteLine("████████████████████████████████████████████████████████████");
            Console.WriteLine("Press any key to return to Initial Menu");
            Console.ReadKey();
            Screen.InitialScreen();
        }
    }
}
