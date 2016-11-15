using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;
using BattleShip.UI;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    public class StartMenu
    {
        private string xCoordinate;
        private string yCoordinate;
        private int letterToNumber;
        private int letterToNumberShot;
        private string abcdefghij = "abcdefghij";
        private string ABCDEFGHIJ = "ABCDEFGHIJ";
        string orientationNumber;
        int numbertoNumber;
        private Board playerOneBoard = new Board();
        private Board playerTwoBoard = new Board();
        public static string playerOneOfficalName = "";
        public static string playerTwoOfficalName = "";
        Coordinate originalCoordinate = new Coordinate(0, 0);
        private int letterShotNewNumber;
        private ShotStatus status;
        ShipPlacement result;

        public void playingGameFinally(string playerOne, string playerTwo)
        {
            bool didSomeoneWin = false;

            for (int i = 2; i < 200; i++)
            {
                while (!didSomeoneWin)
                {
                    bool invalidOrDuplicated = false;
                    do
                    {
                        if (i % 2 == 0)
                        {
                            Console.Clear();
                            displayBoardHistory(playerOne);
                            displayBoard(playerOne);
                            Console.WriteLine($"Where would you like to shoot {playerOneOfficalName}?");
                            do
                            {
                                Console.WriteLine("Enter X coordinate (Letters)  ", playerTwoOfficalName);
                                xCoordinate = Console.ReadLine();
                            } while (String.IsNullOrWhiteSpace(xCoordinate));
                            translateCoordinates(letterToNumberShot);
                            do
                            {
                                Console.WriteLine("Enter Y coordinate (Numbers)  ", playerTwoOfficalName);
                                yCoordinate = Console.ReadLine();
                            } while (String.IsNullOrWhiteSpace(yCoordinate));
                            numbertoNumber = Int32.Parse(yCoordinate);
                            Coordinate shootingCoordinates = new Coordinate(numbertoNumber, letterToNumber);
                            FireShotResponse responsed = playerTwoBoard.FireShot(shootingCoordinates);
                            Console.Clear();
                            i++;
                            if (responsed.ShotStatus == ShotStatus.Victory)
                            {
                                didSomeoneWin = true;
                                Console.WriteLine("{0}, You have sunk all your opponent's ships, you win!", playerOneOfficalName);
                                Console.WriteLine("{0}, You have sunk all your opponent's ships, you win!", playerOneOfficalName);
                                Console.WriteLine("{0}, You have sunk all your opponent's ships, you win!", playerOneOfficalName);
                                Console.WriteLine("{0}, You have sunk all your opponent's ships, you win!", playerOneOfficalName);
                                Console.ReadLine();
                            }
                            else if (responsed.ShotStatus == ShotStatus.Invalid)
                            {
                                i--;
                                Console.WriteLine("INVALID SHOT, YOU GET TO GO AGAIN.");
                                Console.ReadLine();
                                invalidOrDuplicated = true;
                            }

                            else if (responsed.ShotStatus == ShotStatus.Hit)
                            {
                                Console.WriteLine("{0}!!!! You hit something!", responsed.ShotStatus);
                                Console.WriteLine("{0}, NOW PLEASE TURN AROUND, its {1}'s turn!", playerOneOfficalName, playerTwoOfficalName);
                                Console.ReadLine();
                                Console.Clear();
                                didSomeoneWin = false;
                            }
                            else if (responsed.ShotStatus == ShotStatus.Duplicate)
                            {
                                i--;
                                Console.WriteLine("DUPLICATE SHOT, YOU GET TO GO AGAIN.");
                                Console.ReadLine();
                                invalidOrDuplicated = true;

                            }
                            else if (responsed.ShotStatus == ShotStatus.HitAndSunk)
                            {
                                Console.WriteLine("{0}!!!! You sunk the {1}", responsed.ShotStatus, responsed.ShipImpacted);
                                Console.WriteLine("{0} NOW PLEASE TURN AROUND, its {1}'s turn!", playerOneOfficalName, playerTwoOfficalName);
                                Console.ReadLine();
                                Console.Clear();
                                didSomeoneWin = false;
                            }
                            else
                            {
                                //you miss
                                Console.WriteLine("Your projectile splashes into the ocean, you missed...");
                                Console.WriteLine("{0}, NOW PLEASE TURN AROUND, its {1}'s turn!", playerOneOfficalName, playerTwoOfficalName);
                                Console.ReadLine();
                                Console.Clear();
                                didSomeoneWin = false;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            displayBoardHistory(playerTwo);
                            displayBoard(playerTwo);
                            Console.WriteLine($"Where would you like to shoot {playerTwoOfficalName}?");

                            do
                            {
                                Console.WriteLine("Enter X coordinate (Letters)  ", playerTwoOfficalName);
                                xCoordinate = Console.ReadLine();
                            } while (String.IsNullOrWhiteSpace(xCoordinate));
                            translateCoordinates(letterToNumberShot);
                            do
                            {
                                Console.WriteLine("Enter Y coordinate (Numbers)  ", playerTwoOfficalName);
                                yCoordinate = Console.ReadLine();
                            } while (String.IsNullOrWhiteSpace(yCoordinate));
                            numbertoNumber = Int32.Parse(yCoordinate);
                            Coordinate shootingCoordinated = new Coordinate(numbertoNumber, letterToNumber);
                            FireShotResponse response = playerOneBoard.FireShot(shootingCoordinated);
                            Console.Clear();
                            i++;
                            if (response.ShotStatus == ShotStatus.Victory)
                            {
                                didSomeoneWin = true;
                                Console.WriteLine("{0}, You have sunk all your opponent's ships, you win!", playerTwoOfficalName);
                                Console.WriteLine("{0}, You have sunk all your opponent's ships, you win!", playerTwoOfficalName);
                                Console.WriteLine("{0}, You have sunk all your opponent's ships, you win!", playerTwoOfficalName);
                                Console.WriteLine("{0}, You have sunk all your opponent's ships, you win!", playerTwoOfficalName);
                                Console.ReadLine();
                            }
                            else if (response.ShotStatus == ShotStatus.Invalid)
                            {
                                i--;
                                Console.WriteLine("INVALID SHOT, YOU GET TO GO AGAIN.");
                                Console.ReadLine();
                                invalidOrDuplicated = true;
                            }
                            else if (response.ShotStatus == ShotStatus.Hit)
                            {
                                Console.WriteLine("{0}!!!! You hit something!", response.ShotStatus);
                                Console.WriteLine("{0}, NOW PLEASE TURN AROUND, its {1}'s turn!", playerTwoOfficalName, playerOneOfficalName);
                                Console.ReadLine();
                                Console.Clear();
                                didSomeoneWin = false;
                            }
                            else if (response.ShotStatus == ShotStatus.HitAndSunk)
                            {
                                Console.WriteLine("{0}!!!! You sunk the {1}", response.ShotStatus, response.ShipImpacted);
                                Console.WriteLine("{0}, NOW PLEASE TURN AROUND, its {1}'s turn", playerTwoOfficalName, playerOneOfficalName);
                                Console.ReadLine();
                                Console.Clear();
                                didSomeoneWin = false;
                            }
                            else if (response.ShotStatus == ShotStatus.Duplicate)
                            {
                                i--;
                                Console.WriteLine("DUPLICATE SHOT, YOU GET TO GO AGAIN.");
                                Console.ReadLine();
                                invalidOrDuplicated = true;
                            }
                            else
                            {
                                //you miss
                                Console.WriteLine("Your projectile splashes into the ocean, you missed...");
                                Console.WriteLine("{0}, NOW PLEASE TURN AROUND, its {1}'s turn!", playerTwoOfficalName, playerOneOfficalName);
                                Console.ReadLine();
                                Console.Clear();
                                didSomeoneWin = false;
                            }
                        }
                    } while (invalidOrDuplicated);
                }
            }
        }

        public void nameForPlayer(string player)
        {
            if (player == "player 1")
            {
                do
                {
                    Console.WriteLine("Please enter your name Player 1");
                    player = Console.ReadLine();
                    playerOneOfficalName = player;

                } while (String.IsNullOrWhiteSpace(player));
            }
            else
            {
                do
                {
                    //clearing so player 2 can't see player 1's board
                    Console.Clear();
                    Console.WriteLine("Please enter your name Player 2");
                    player = Console.ReadLine();
                    playerTwoOfficalName = player;
                } while (String.IsNullOrWhiteSpace(player));
            }
        }

        public void displayBoard(string player)
        {
            if (player == "player 1")
            {
                Console.WriteLine("{0}'s Board", playerOneOfficalName);
                Console.WriteLine("   {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  {8}  {9}", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J");
                for (int x = 1; x < 11; x++)
                {
                    Console.Write("{0} ", x);
                    for (int y = 1; y < 11; y++)
                    {
                        Coordinate originalCoordinate = new Coordinate(x, y);

                        if (playerOneBoard.CheckShipCoord(originalCoordinate) == true)
                        {
                            Console.Write(" {0} ", "X");
                        }
                        else
                        {
                            Console.Write(" {0} ", "_");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("{0}'s Board", playerTwoOfficalName);
                Console.WriteLine("   {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  {8}  {9}", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J");
                for (int x = 1; x < 11; x++)
                {
                    Console.Write("{0} ", x);
                    for (int y = 1; y < 11; y++)
                    {
                        Coordinate originalCoordinate = new Coordinate(x, y);

                        if (playerTwoBoard.CheckShipCoord(originalCoordinate) == true)
                        {
                            Console.Write(" {0} ", "X");
                        }
                        else
                        {
                            Console.Write(" {0} ", "_");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        public void displayBoardHistory(string player)
        {
            if (player == "player 2")
            {
                // actually player two's board
                Console.WriteLine("{0}'s History Board", playerTwoOfficalName);
                Console.WriteLine("   {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  {8}  {9}", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J");
                for (int x = 1; x < 11; x++)
                {
                    Console.Write("{0} ", x);
                    for (int y = 1; y < 11; y++)
                    {
                        Coordinate originalCoordinate = new Coordinate(x, y);
                        if (playerOneBoard.ShotHistory.ContainsKey(originalCoordinate))
                        {
                            switch (playerOneBoard.ShotHistory[originalCoordinate])
                            {
                                case ShotHistory.Hit:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(" H ");

                                        break;
                                    }
                                case ShotHistory.Miss:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(" M ");
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" {0} ", "_");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                // actually player one's board
                Console.WriteLine("{0}'s History Board", playerOneOfficalName);
                Console.WriteLine("   {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  {8}  {9}", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J");
                for (int x = 1; x < 11; x++)
                {
                    Console.Write("{0} ", x);
                    for (int y = 1; y < 11; y++)
                    {
                        Coordinate originalCoordinate = new Coordinate(x, y);
                        if (playerTwoBoard.ShotHistory.ContainsKey(originalCoordinate))
                        {
                            switch (playerTwoBoard.ShotHistory[originalCoordinate])
                            {
                                case ShotHistory.Hit:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(" H ");

                                        break;
                                    }
                                case ShotHistory.Miss:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(" M ");
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" {0} ", "_");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        public void translateCoordinates(int LetterToNumberShot)
        {
            StartMenu gettingXCoordinate = new StartMenu();
            ABCDEFGHIJ = "ABCDEFGHIJ";
            for (int i = 0; i < 10; i++)
            {
                if (xCoordinate.ToUpper()[0] == ABCDEFGHIJ[i])
                {
                    letterToNumber = i + 1;
                }
                else
                {
                    //throwing exception null reference
                }
            }
            //validation-ish
            // Console.WriteLine($" {xCoordinate}  is now {letterToNumber}");
        }

        public void placeShipOnPlayerBoard(ShipType shipType, string player) //players
        {
            bool shipPlacementIsTrue = false;
            do
            {
                if (player == "player 1")
                {
                    bool validateCoordinates;
                    string userCoordinates;
                    Console.WriteLine($"{playerOneOfficalName}'s Board Where do you want to put your ship {shipType}");
                    do
                    {
                        Console.WriteLine("Enter X coordinate (Letters)  ", playerOneOfficalName);
                        xCoordinate = Console.ReadLine();

                    } while (!(xCoordinate.ToUpper() == "A" || xCoordinate.ToUpper() == "B" || xCoordinate.ToUpper() == "C" || xCoordinate.ToUpper() == "D" || xCoordinate.ToUpper() == "E" || xCoordinate.ToUpper() == "F" || xCoordinate.ToUpper() == "G" || xCoordinate.ToUpper() == "H" || xCoordinate.ToUpper() == "I" || xCoordinate.ToUpper() == "J"));
                    do
                    {
                        Console.WriteLine("Enter Y coordinate (#s')  ", playerOneOfficalName);
                        yCoordinate = Console.ReadLine();
                    } while (!(yCoordinate.ToUpper() == "10" || yCoordinate.ToUpper() == "1" || yCoordinate.ToUpper() == "2" || yCoordinate.ToUpper() == "3" || yCoordinate.ToUpper() == "4" || yCoordinate.ToUpper() == "5" || yCoordinate.ToUpper() == "6" || yCoordinate.ToUpper() == "7" || yCoordinate.ToUpper() == "8" || yCoordinate.ToUpper() == "9"));
                    {
                        numbertoNumber = Int32.Parse(yCoordinate);
                        translateCoordinates(letterToNumber);
                    }
                    PlaceShipRequest theNewShips = new PlaceShipRequest();
                    theNewShips.ShipType = shipType;
                    theNewShips.Coordinate = new Coordinate(numbertoNumber, letterToNumber);
                    do
                    {
                        Console.WriteLine("\n Orientation? 1 == Up, 2 == Down, 3 == Right, 4 == Left");
                        orientationNumber = Console.ReadLine();
                    } while (!(orientationNumber == "1" || orientationNumber == "2" || orientationNumber == "3" || orientationNumber == "4"));
                    switch (orientationNumber)
                    {
                        case "1":
                            theNewShips.Direction = ShipDirection.Up;
                            break;
                        case "2":
                            theNewShips.Direction = ShipDirection.Down;
                            break;
                        case "3":
                            theNewShips.Direction = ShipDirection.Right;
                            break;
                        case "4":
                            theNewShips.Direction = ShipDirection.Left;
                            break;
                    }
                    ShipPlacement result = playerOneBoard.PlaceShip(theNewShips);
                    Console.WriteLine($"That placement is {result}");
                    if (result == ShipPlacement.Ok)
                    {
                        shipPlacementIsTrue = true;
                        //Console.WriteLine($"Successfully placed. {playerTwoOfficalName}");

                    }
                    else if (result == ShipPlacement.NotEnoughSpace)
                    {
                        Console.WriteLine("invalid placement, not enough spaces, please try again.");
                        Console.ReadLine();
                    }
                    else if (result == ShipPlacement.Overlap)
                    {
                        Console.WriteLine("overlap placement, not enough spaces, please try again.");
                        Console.ReadLine();
                    }
                    Console.Clear();
                    // Console.WriteLine($"Successfully placed. {playerOneOfficalName}");
                    displayBoard("player 1");
                }
                else if (player == "player 2")
                {
                    bool validateCoordinates;
                    string userCoordinates;
                    Console.WriteLine($"{playerTwoOfficalName}'s Board Where do you want to put your ship {shipType}");
                    do
                    {
                        Console.WriteLine("Enter X coordinate (Letters)  ", playerTwoOfficalName);
                        xCoordinate = Console.ReadLine();
                    } while (!(xCoordinate.ToUpper() == "A" || xCoordinate.ToUpper() == "B" || xCoordinate.ToUpper() == "C" || xCoordinate.ToUpper() == "D" || xCoordinate.ToUpper() == "E" || xCoordinate.ToUpper() == "F" || xCoordinate.ToUpper() == "G" || xCoordinate.ToUpper() == "H" || xCoordinate.ToUpper() == "I" || xCoordinate.ToUpper() == "J"));
                    do
                    {
                        Console.WriteLine("Enter Y coordinate (#s')  ", playerTwoOfficalName);
                        yCoordinate = Console.ReadLine();
                    } while (!(yCoordinate.ToUpper() == "10" || yCoordinate.ToUpper() == "1" || yCoordinate.ToUpper() == "2" || yCoordinate.ToUpper() == "3" || yCoordinate.ToUpper() == "4" || yCoordinate.ToUpper() == "5" || yCoordinate.ToUpper() == "6" || yCoordinate.ToUpper() == "7" || yCoordinate.ToUpper() == "8" || yCoordinate.ToUpper() == "9"));
                    {
                        numbertoNumber = Int32.Parse(yCoordinate);
                        translateCoordinates(letterToNumber);
                    }
                    PlaceShipRequest theNewShips = new PlaceShipRequest();
                    theNewShips.ShipType = shipType;
                    theNewShips.Coordinate = new Coordinate(numbertoNumber, letterToNumber);
                    do
                    {
                        Console.WriteLine("\n Orientation? 1 == Up, 2 == Down, 3 == Right, 4 == Left");
                        orientationNumber = Console.ReadLine();
                    } while (!(orientationNumber == "1" || orientationNumber == "2" || orientationNumber == "3" || orientationNumber == "4"));
                    switch (orientationNumber)
                    {
                        case "1":
                            theNewShips.Direction = ShipDirection.Up;
                            break;
                        case "2":
                            theNewShips.Direction = ShipDirection.Down;
                            break;
                        case "3":
                            theNewShips.Direction = ShipDirection.Right;
                            break;
                        case "4":
                            theNewShips.Direction = ShipDirection.Left;
                            break;
                    }
                    result = playerTwoBoard.PlaceShip(theNewShips);
                    Console.WriteLine($"That placement is {result}");
                    if (result == ShipPlacement.Ok)
                    {
                        shipPlacementIsTrue = true;
                        // Console.WriteLine($"Successfully placed. {playerTwoOfficalName}");

                    }
                    else if (result == ShipPlacement.NotEnoughSpace)
                    {
                        Console.WriteLine("invalid placement, not enough spaces, please try again.");
                        Console.ReadLine();

                    }
                    else if (result == ShipPlacement.Overlap)
                    {
                        Console.WriteLine("overlap placement, not enough spaces, please try again.");
                        Console.ReadLine();
                    }

                    Console.Clear();
                    // Console.WriteLine($"Successfully placed. {playerTwoOfficalName}");
                    displayBoard("player 2");
                }
            } while (!shipPlacementIsTrue);
        }
    }
}




