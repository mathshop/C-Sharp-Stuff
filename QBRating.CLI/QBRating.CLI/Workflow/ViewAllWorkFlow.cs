using QBRating.BLL;
using QBRating.BLL.Calculations;
using QBRating.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.CLI.Workflow
{
    class ViewAllWorkFlow
    {
        public void Execute()
        {
            Manager manager = ManagerFactory.Create();
            var players = manager.LoadAllManager();
            Calculations calc = new Calculations();

            foreach (var player in players)
            {
                calc.CalcRating(player);
                Console.WriteLine("{0}'s QB Rating is: {1}", player.Name, player.Rating);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
