using ConnectFour;
using System;

namespace ConnectFour
{

    interface IPlayer
    {
        public void PutAPiece(Player playerOne, Player playerTwo);
    }
    public abstract class Player:IPlayer
    {
        public string playerName = "Unknow Player";
        public int score { get; set; } = 0;

        public Player()
        {

        }

        public virtual void PutAPiece(Player playerOne, Player playerTwo)
        {

        }

    }


    public class ComputerPlayer : Player
    {
        public Random r = new Random();
        public ComputerPlayer()
        {
            playerName = "ComputerPlayer";
        }
        public override void PutAPiece(Player playerOne, Player playerTwo)
        {

            int chosenColumn = int.Parse(Controller.validsPlays[r.Next(0, Controller.validsPlays.Count)]);
            Controller.PutAPiece(chosenColumn, Controller.turn);
        }

        public override string ToString()
        {
            return playerName;
        }

    }

    public class HumanPlayer : Player
    {

        public HumanPlayer(string n)

        {
            Screen.TypePlayersScreen($"Type the name of Player {n}:", "(max.15 characters)");
            do
            {
                try
                {
                    //playerName = "";
                    playerName = Console.ReadLine();

                    while(playerName.Contains("  "))
                    {
                        playerName = playerName.Replace("  ", " ");
                    }
                    playerName = playerName.Trim();

                    if (playerName == "" || playerName.Length>15 || playerName == " ")
                    {
                        throw new CheckPlayerNameException("Invalid Name");
                    }
                    else
                    {
                        break;
                    }

                }
                catch (CheckPlayerNameException e)
                {

                    e.InvalidName();
                }
                
            }
            while (true);

        }

        public override string ToString()
        {
            return playerName;
        }

        public override void PutAPiece(Player playerOne, Player playerTwo)
        {
            string playChoosen = Controller.ValidPlay(playerOne, playerTwo);
            Controller.PutAPiece(int.Parse(playChoosen), Controller.turn);

        }
    }
}