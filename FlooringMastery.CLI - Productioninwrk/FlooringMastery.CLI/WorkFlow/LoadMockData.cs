using FlooringMaster.BLL;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.CLI.WorkFlow
{
    class LoadMockData
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("FLOORING MASTERY");
            Console.WriteLine("--------------------");
            Console.WriteLine("Loading Mock Repository");         
            OrderManager orderManager = OrderManagerFactory.Create();
            MockOrderRepository.InMemoryOrderRepo();
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }
    }
}
