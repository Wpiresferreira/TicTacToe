using System;

namespace ConnectFour
{
    public class CheckPlayerNameException : ApplicationException
    {

        public CheckPlayerNameException(string msg) : base(msg)
        {
        }
        public void InvalidName()
        {
            Screen.TypePlayersScreen("", "Please insert a valid name.") ;

        }
    }

}



