using System;
using BattleShip.BLL;


namespace BattleShip.UI

{
    internal class MainProgram
    {

       private static void Main(string[] args)
        {

            Start startNow = new Start();
            GetNames gettingNames = new GetNames();
            StartMenu startingnow = new StartMenu();

            startNow.startBattleship();
            gettingNames.nameForPlayerOne();
            gettingNames.nameForPlayerTwo();
            startingnow.displayBoardOne();
            startingnow.getCoordinatesPlayerOne();
            startingnow.placeShipOnPlayerOneBoard(BLL.Ships.ShipType.Carrier);
            startingnow.getCoordinatesPlayerOne();
            startingnow.placeShipOnPlayerOneBoard(BLL.Ships.ShipType.Battleship);
            startingnow.getCoordinatesPlayerOne();
            startingnow.placeShipOnPlayerOneBoard(BLL.Ships.ShipType.Submarine);
            startingnow.getCoordinatesPlayerOne();
            startingnow.placeShipOnPlayerOneBoard(BLL.Ships.ShipType.Cruiser);
            startingnow.getCoordinatesPlayerOne();
            startingnow.placeShipOnPlayerOneBoard(BLL.Ships.ShipType.Destroyer);
           


        }
    }
}
