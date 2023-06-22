﻿using System;

namespace ConnectFour
{
    public static class Screen
    {
        
        public static void InitialScreen() {
            Console.Clear();
            Console.WriteLine("************************************************************");
            Console.WriteLine("***                                                      ***");
            Console.WriteLine("***             Welcome to Connect Four Game             ***");
            Console.WriteLine("***                                                      ***");
            Console.WriteLine("************************************************************");
            Console.WriteLine("***                                                      ***");
            Console.WriteLine("***   Choose a option                                    ***");
            Console.WriteLine("***   1 - One Player vs Computer Game                    ***");
            Console.WriteLine("***   2 - Two Players Game                               ***");
            Console.WriteLine("***   3 - Help / About the game                          ***");
            Console.WriteLine("***   4 - Exit                                           ***");
            Console.WriteLine("***                                                      ***");
            Console.WriteLine("************************************************************");
            Console.WriteLine("************************************************************");
            Console.WriteLine("*** Developed by Wagner Pires Ferreira 2023 ****************");

            Controller.CheckOption();
            
        }

        public static void DisplayGameBoard( Player playerOne, Player playerTwo) {
            Header(playerOne, playerTwo);
            Body();

        }

        public static void Header(Player one, Player two) {
            Console.Clear();
            Console.WriteLine($"************************************************************");
            Console.WriteLine($"*** {one,-10}                                {two,10} ***");
            Console.WriteLine($"***      X                                         O     ***");
            Console.WriteLine($"*** Wins: {one.score,2}                                    Wins: {two.score,2} ***");
            Console.WriteLine($"************************************************************");
        }

        public static void Body()
        {
            Console.WriteLine($"***                                                      ***");
            Console.WriteLine($"***                                                      ***");


            string row = "";
                for (int i = 0; i < 6; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("***            1   2   3   4   5   6   7                 ***");
                        Console.WriteLine("***          +---+---+---+---+---+---+---+               ***");
                    }
                    row = "***          | ";
                    for (int j = 0; j < 7; j++)
                    {
                        row += GameBoard.board[i, j] + " | ";
                    }
                    row += "              ***";
                    Console.WriteLine(row);
                    Console.WriteLine("***          +---+---+---+---+---+---+---+               ***");
                    row = "";
                }
            Console.WriteLine($"***                                                      ***");
            Console.WriteLine($"***                                                      ***");
            Console.WriteLine($"************************************************************");

            
        }

        public static void ShowHelp()
        {
            Console.Clear();
            Console.WriteLine("************************************************************");
            Console.WriteLine("***                                                      ***");
            Console.WriteLine("***                  About Connect Four                  ***");
            Console.WriteLine("***                                                      ***");
            Console.WriteLine("************************************************************");
            Console.WriteLine("***                                                      ***");
            Console.WriteLine("***  Connect Four  is a two-player connection rack game, ***");
            Console.WriteLine("***  in which the players choose a color (or \"X\" /\"O\")   ***");
            Console.WriteLine("***  and then take turns dropping colored tokens into a  ***");
            Console.WriteLine("***  six-row, seven-column vertically suspended grid.    ***");
            Console.WriteLine("***  The pieces fall straight down, occupying the lowest ***");
            Console.WriteLine("***  available space within the column. The objective of ***");
            Console.WriteLine("***  the game is to be the first to form a horizontal,   ***");
            Console.WriteLine("***  vertical, or diagonal line of four of one's own     ***");
            Console.WriteLine("***  tokens.                                             ***");
            Console.WriteLine("***                                                      ***");
            Console.WriteLine("***                            source:wikipedia.org      ***");
            Console.WriteLine("************************************************************");
            Console.WriteLine("Press any key to return to Initial Menu");
            Console.ReadKey();
            Screen.InitialScreen();
        }


    }
}