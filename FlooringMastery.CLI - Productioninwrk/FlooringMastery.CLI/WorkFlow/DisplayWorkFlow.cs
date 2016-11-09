using FlooringMaster.BLL;
using FlooringMaster.BLL.Responses;
using FlooringMastery.BLL;
using FlooringMastery.CLI;
using FlooringMastery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.WorkFlow
{
    public class DisplayWorkFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order newOrder = new Order();
            Console.Clear();
            Console.WriteLine("Lookup an Order");
            Console.WriteLine("--------------------------");
            string orderID = ConsoleIO.GetOrderID("Please enter a Order ID (MMDDYYYY): ");
            string newURL = ConsoleIO.ConvertURLToString(orderID);
            int responseNumber = ConsoleIO.GetNumberIDFromUser("Enter in NumberID: ");
            OrderLookupResponse responseOrder = manager.LookupOrder(orderID, responseNumber, newURL);
            newOrder.OrderID = orderID;
            newOrder.NumberID = responseNumber;
         
            if (responseOrder.Success && responseNumber == responseOrder.Order.NumberID)
            {
                ConsoleIO.DisplayOrderDetails(responseOrder.Order);
            }
            else if (responseOrder.Success && responseNumber != responseOrder.Order.NumberID)
            {
                Console.WriteLine("An error has occured, NumberID does not exist.");
               
            }
            else if (!responseOrder.Success)
            {
                Console.WriteLine();
                Console.WriteLine("An error has occured, {0}", responseOrder.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

