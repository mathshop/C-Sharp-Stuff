using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class GetNames
    {
        private string playerOne;
        private string playerTwo;

        public void nameForPlayerOne()
        {
            Console.WriteLine("Please enter your name Player 1");
            playerOne = Console.ReadLine();
            if (String.IsNullOrEmpty(playerOne) || String.IsNullOrWhiteSpace(playerOne))
            {
                Console.WriteLine("Your name is invalid");
                GetNames tryAgainName = new GetNames();
                tryAgainName.nameForPlayerOne();
            }
            else
            {
                Console.WriteLine("Hello {0}", playerOne);
              
            }
        }
        public void nameForPlayerTwo()
        {
            Console.WriteLine("Please enter your name Player 2");
            playerTwo = Console.ReadLine();
            if (String.IsNullOrEmpty(playerTwo) || String.IsNullOrWhiteSpace(playerTwo))
            {
                Console.WriteLine("Your name is invalid");
                GetNames tryAgainName = new GetNames();
                tryAgainName.nameForPlayerTwo();
            }
            else
            {
                Console.WriteLine("Hello {0}", playerTwo);
                //displayBoardOne();
            }
        }
    }
}
