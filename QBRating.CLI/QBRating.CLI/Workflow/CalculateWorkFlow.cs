using QBRating.BLL;
using QBRating.BLL.Calculations;
using QBRating.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.CLI.Workflow
{
    class CalculateWorkFlow
    {
        public const string bar = "------------------------";
        public void Execute()
        {
            Manager manage = ManagerFactory.Create();
            Console.Clear();
            Console.WriteLine(bar);
            Console.WriteLine("QB Rating Calculator");
            Console.WriteLine("Calculate Player");
            Console.WriteLine(bar);
            Calculations calc = new Calculations();
            Player player = new Player();
            player.Name = ConsoleIO.GetPlayerName("Please enter the Quarterback's Name (I.E. Steve Young): ");
            player.PassAttempted = ConsoleIO.GetPassAttempt($"Please enter passing attempt of {player.Name}: ");

            do
            {
                player.PassCompleted = ConsoleIO.GetPassComplete($"Please enter passing completion of {player.Name}: ");
                if (player.PassCompleted > player.PassAttempted)
                {
                    Console.WriteLine("Completions must be less than Attempts...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
            } while (player.PassCompleted > player.PassAttempted);

            player.PassingYard = ConsoleIO.GetPassYard($"Please enter the passing yard of {player.Name}: ");
            do
            {
                player.PassingTD = ConsoleIO.GetPassTD($"Please enter the amount of touchdowns {player.Name} has thrown or scored: ");
                if (player.PassingTD > player.PassCompleted)
                {
                    Console.WriteLine("Touchdowns must be less than passing completions...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
            } while (player.PassingTD > player.PassCompleted);

            do
            {
                player.Interceptions = ConsoleIO.GetPassInt($"Please enter the number of interceptions for {player.Name}: ");
                if (player.Interceptions > player.PassAttempted - player.PassCompleted)
                {
                    Console.WriteLine("Interceptions must be less than passes attempts minus passes completed...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }

            } while (player.Interceptions > player.PassAttempted - player.PassCompleted);

            calc.CalcRating(player);
            ConsoleIO.DisplayPlayer(player);
            var saveStats = ConsoleIO.SaveStats($"Press Y to save stats, else press any other key...");
            Console.WriteLine("Press any key to continue...");

            if (saveStats)
            {
                manage.AddManager(player);
            }
            Console.ReadLine();
        }
    }
}

