using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;

namespace BattleShip.UI
{
    internal class MainControl
    {

        private static void Main(string[] args)
        {
            bool playAgain = true;
            do
            {
                Start startNow = new Start();
                StartMenu startingnow = new StartMenu();
                playGame letsPlayFinally = new playGame();
                playGame playGame = new playGame();
               
                Console.WriteLine("Welcome to the game of Battleship!!");
                Console.ReadLine();

                startingnow.nameForPlayer("player 1");
                startingnow.displayBoard("player 1");
                startingnow.placeShipOnPlayerBoard(BLL.Ships.ShipType.Carrier, "player 1");
                startingnow.placeShipOnPlayerBoard(BLL.Ships.ShipType.Battleship, "player 1");
                startingnow.placeShipOnPlayerBoard(BLL.Ships.ShipType.Submarine, "player 1");
                startingnow.placeShipOnPlayerBoard(BLL.Ships.ShipType.Cruiser, "player 1");
                startingnow.placeShipOnPlayerBoard(BLL.Ships.ShipType.Destroyer, "player 1");

                startingnow.nameForPlayer("player 2");
                startingnow.displayBoard("player 2");
                startingnow.placeShipOnPlayerBoard(BLL.Ships.ShipType.Carrier, "player 2");
                startingnow.placeShipOnPlayerBoard(BLL.Ships.ShipType.Battleship, "player 2");
                startingnow.placeShipOnPlayerBoard(BLL.Ships.ShipType.Submarine, "player 2");
                startingnow.placeShipOnPlayerBoard(BLL.Ships.ShipType.Cruiser, "player 2");
                startingnow.placeShipOnPlayerBoard(BLL.Ships.ShipType.Destroyer, "player 2");

                Console.Clear();
                playGame.LetsGetReadyToRumble();
                Console.ReadLine();
                startingnow.playingGameFinally("player 1", "player 2");

                Console.WriteLine("Would you like to play again? Press Y");
                string userInput = Console.ReadLine().ToUpper();
               
                if (userInput== null || userInput != "Y"|| userInput == "")
                {
                    playAgain = false;
                }
            } while (playAgain);


            Console.Clear();
            Console.WriteLine("Thanks for Playing!!!!!");
            Console.ReadLine();

        }
    }
}