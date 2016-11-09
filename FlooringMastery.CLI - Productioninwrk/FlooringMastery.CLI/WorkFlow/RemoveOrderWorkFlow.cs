using FlooringMaster.BLL;
using FlooringMaster.BLL.Responses;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.CLI.WorkFlow
{
    class RemoveOrderWorkFlow
    {
        public void Execute()
        {
            OrderManager orderManager = OrderManagerFactory.Create();
            Order order = new Order();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Delete Order");
            Console.WriteLine(Menu.separatorBar);
            Console.WriteLine();
            string orderID = ConsoleIO.GetOrderIDFromUser("Date that the Order was placed (orderID)? ");
            int index = ConsoleIO.GetNumberIDFromUser("Enter in NumberID: ");
            string newURL = ConsoleIO.ConvertURLToString(orderID);
            OrderLookupResponse response = orderManager.LookupOrder(orderID, index, newURL);

            if (response.Success && index == response.Order.NumberID)
            {
                ConsoleIO.DisplayOrderDetails(response.Order);
                string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to delete?");

                if (answer == "Y")
                {
                    orderManager.DeleteOrderID(response.Order, index);
                    Console.WriteLine("Account successfully Deleted...");
                }
                else
                {
                    Console.WriteLine("Delete cancelled.");
                }
            }
            else if (response.Success && index != response.Order.NumberID)
            {
                Console.WriteLine("An error occured, NumberID does not exist. ");
            }
            else if (!response.Success)
            {
                Console.WriteLine();
                Console.WriteLine("An error has occured, {0}", response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
