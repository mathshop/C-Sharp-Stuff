using BattleShip.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Start
    {
        
        public void startBattleship()
        {
            Console.WriteLine("Hello, and welcome to the game of Battleship!!");

            Console.WriteLine("Please Press 1 to play, or any other key to quit.");
            string selection = Console.ReadLine();
            if (selection == "1")
            {
                Console.WriteLine("i pressed one");         
            }
            else
            {
                Console.WriteLine("I guess you didn't want to play Battleship, see you next time!");
                Console.ReadKey();
            }
        }
    }
}
