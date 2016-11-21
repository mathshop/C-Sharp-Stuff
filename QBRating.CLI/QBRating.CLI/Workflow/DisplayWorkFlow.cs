using QBRating.BLL;
using QBRating.BLL.Calculations;
using QBRating.Model.DTO;
using QBRating.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.CLI.Workflow
{
    class DisplayWorkFlow
    {

        public void Execute()
        {
            Manager manager = ManagerFactory.Create();
            Console.WriteLine("Lookup a Player");
            Console.WriteLine("--------------------------");
            string playerName = ConsoleIO.GetPlayerName("Please enter a Players Name: ");
            LookUpResponse response = manager.LookResponse(playerName);

            if (response.Success)
            {
                var results = ConvertAll(response.player);
                ConsoleIO.DisplayPlayer(results);
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Player not found, press any key to continue...");
                Console.ReadLine();
            }
        }

        internal Player ConvertAll(Player player)
        {
            Player newPlayer = new Player();
            newPlayer.Name = player.Name;
            newPlayer.PassAttempted = player.PassAttempted;
            newPlayer.PassCompleted = player.PassCompleted;
            newPlayer.PassingTD = player.PassingTD;
            newPlayer.PassingYard = player.PassingYard;
            newPlayer.Interceptions = player.Interceptions;
            Calculations calc = new Calculations();
            calc.CalcRating(newPlayer);
            return newPlayer;
        }
    }
}
