using RockPaperScissorsV2.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsV2.CLI
{
    public static class PlayerFactory
    {
        private static IPlayer GetPlayerType()
        {
            Console.WriteLine("Please Enter 1 for Human Player or 2 for AI Player.");
            string player = Console.ReadLine();

            if (player == "1")
            {
                IPlayer playerOne = new HumanPlayer();
                return playerOne;
            }
            else
            {
                IPlayer playerOne = new ComputerPlayer();
                return playerOne;
            }
        }

        public static IPlayer GetPlayer1()
        {
            return GetPlayerType();
        }

        public static IPlayer GetPlayer2()
        {
            return GetPlayerType();
        }
    }
}
