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
            Console.WriteLine($"\nType the name of Player {n}:");
            playerName = Console.ReadLine();
    
        }

        public override string ToString()
        {
            return playerName;
        }
    }
}