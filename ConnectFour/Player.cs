using ConnectFour;
using System;

namespace ConnectFour
{
    public abstract class Player
    {
        public string playerName = "Unknow Player";
        public int score { get; set; } = 0;

        public Player(){
     
        }

        public virtual void PutAPiece(Player playerOne, Player playerTwo)
        {

        }

    }


public class ComputerPlayer : Player
{
    public ComputerPlayer()
    {
        playerName = "ComputerPlayer";
    }
}

public class HumanPlayer : Player
{
    
        public HumanPlayer(string n)
    
        {
            Console.WriteLine($"\nType the name of Player {n}:\n(max.15 characters)");
            playerName = Console.ReadLine();
    
        }

        public override string ToString()
        {
            return playerName;
        }

        public override void PutAPiece(Player playerOne, Player playerTwo)
        {
            int columnchosenColumn = Controller.ValidColumn(playerOne,playerTwo);
            Controller.PutAPiece(columnchosenColumn, Controller.turn);
        }
    }
}