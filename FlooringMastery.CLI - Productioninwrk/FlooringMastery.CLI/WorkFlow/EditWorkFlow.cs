using FlooringMaster.BLL;
using FlooringMaster.BLL.Responses;
using FlooringMaster.Models;
using FlooringMastery.BLL;
using FlooringMastery.BLL.gettingvalues;
using FlooringMastery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.CLI.WorkFlow
{
    class EditWorkFlow
    {
        public bool Execute()
        {
            Order newOrder = new Order();
            OrderManager manager = OrderManagerFactory.Create();
            Calculations calculate = new Calculations();
            Console.Clear();
            Console.WriteLine("FLOORING MASTERY");
            Console.WriteLine("--------------------");
            string orderID = ConsoleIO.GetOrderID("Please enter a Order ID (MMDDYYYY): ");
            string newURL = ConsoleIO.ConvertURLToString(orderID);
            int responseNumber = ConsoleIO.GetNumberIDFromUser("Enter in NumberID: ");
            OrderLookupResponse responseOrder = manager.LookupOrder(orderID, responseNumber, newURL);
            newOrder.OrderID = orderID;
            newOrder.NumberID = responseNumber;

            if (responseOrder.Success && responseNumber == responseOrder.Order.NumberID)
            {
                ConsoleIO.DisplayOrderDetails(responseOrder.Order);

                newOrder.CustomerName = ConsoleIO.GetCustomerName("Please enter new Customer Name.\n");
                if (string.IsNullOrWhiteSpace(newOrder.CustomerName))
                {
                    newOrder.CustomerName = responseOrder.Order.CustomerName;
                }
                newOrder.State = ConsoleIO.GetStateFromUser("Please enter a new State.(MN)Minnesota, (IA)Iowa, (WI)Wisconsin, (SD)South Dakota, or (ND)North Dakota...\n");
                if (newOrder.State == 0)
                {
                    newOrder.State = responseOrder.Order.State;
                }

                newOrder.Product = ConsoleIO.GetProductTypeFromUser("Please enter a new Product (W)Wood, (T)Tile, (C)Carpet, or (L)Laminate...\n");
                if (newOrder.Product == 0)
                {
                    newOrder.Product = responseOrder.Order.Product;
                }

                do
                {
                    newOrder.AreaProvided = ConsoleIO.GetArea("Please enter a new area.\n");
                } while (newOrder.AreaProvided < 0);

                if (newOrder.AreaProvided == 0)
                {
                    newOrder.AreaProvided = responseOrder.Order.AreaProvided;
                }
                

                newOrder.NumberID = responseNumber;
                newOrder.OrderID = responseOrder.Order.OrderID;
                newOrder.Tax = calculate.getTax(newOrder.State, newOrder);
                newOrder.TotalLaborCost = calculate.totalLaborCost(newOrder.Product, newOrder);
                newOrder.TotalProductCost = calculate.totalProductCost(newOrder.Product, newOrder);
                newOrder.TotalPrice = calculate.getTotalPrice(newOrder.State, newOrder);
                ConsoleIO.DisplayOrderDetails(newOrder);

                if (ConsoleIO.GetYesNoAnswerFromUser("Save the following information").ToUpper() == "Y")
                {
                    manager.EditOrder(newOrder, responseNumber);
                    Console.WriteLine("Order successfully Updated...");
                }
                else
                {
                    Console.WriteLine("Delete cancelled.");
                }
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
            return true;
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

