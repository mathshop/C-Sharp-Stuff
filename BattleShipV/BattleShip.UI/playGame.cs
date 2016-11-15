using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.UI;


namespace BattleShip.UI
{
    class playGame
    {
        public void LetsGetReadyToRumble()
        {
            Console.Clear();
            Console.WriteLine("LETS GET READY TO RUMBLE!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("LETS GET READY TO RUMBLE!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("\n {0} it's your turn first, {1} please turn around!", StartMenu.playerOneOfficalName, StartMenu.playerTwoOfficalName);
        }
    }
}
