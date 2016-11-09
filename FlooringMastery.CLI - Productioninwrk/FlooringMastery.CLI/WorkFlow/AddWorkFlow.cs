using FlooringMaster.BLL;
using FlooringMastery.BLL;
using FlooringMastery.BLL.gettingvalues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.CLI.WorkFlow
{
    class AddWorkFlow
    {
        public bool Execute()
        {
            Order newOrder = new Order();
            OrderManager orderManager = OrderManagerFactory.Create();
            Calculations calculate = new Calculations();
            Console.Clear();
            Console.WriteLine("FLOORING MASTERY");
            Console.WriteLine("--------------------");
            string order = newOrder.OrderID = ConsoleIO.GetOrderID("Please enter a Order ID (MMDDYYYY): ");
            string index = orderManager.LoadCheckIndex(order);
            int number = newOrder.NumberID = Int32.Parse(index);
            string customer = newOrder.CustomerName;
            do
            {
               customer = newOrder.CustomerName = ConsoleIO.GetCustomerName("Please enter Customer's Full Name: ");
            } while (String.IsNullOrWhiteSpace(customer));
            string state = newOrder.State.ToString();
            States stateHolder;
            do {
                newOrder.State = ConsoleIO.GetStateFromUser("Please Enter your state... (MN)Minnesota, (IA)Iowa, (WI)Wisconsin, (SD)South Dakota, or (ND)North Dakota...");
            } while (Enum.TryParse<States>(state, out stateHolder) ==false || newOrder.State == stateHolder);
            States stateToState = (States)Enum.Parse(typeof(States), state);
            ProductTypes productHolder;
            string product = newOrder.Product.ToString();
            do
            {
                newOrder.Product = ConsoleIO.GetProductTypeFromUser("Please Enter an product type... (W)Wood, (T)Tile, (C)Carpet, or (L)Laminate...");
            } while (Enum.TryParse<ProductTypes>(product, out productHolder) == false || newOrder.Product == productHolder);
            ProductTypes productToproduct = (ProductTypes)Enum.Parse(typeof(ProductTypes), product);
            decimal area = newOrder.AreaProvided;
            do
            {
              area = newOrder.AreaProvided = ConsoleIO.GetArea("Please enter in the square footage required by Customer...");
            } while (area == 0);
            newOrder.Tax = calculate.getTax(newOrder.State, newOrder);
            newOrder.TotalLaborCost = calculate.totalLaborCost(newOrder.Product, newOrder);
            newOrder.TotalProductCost = newOrder.TotalPrice = calculate.totalProductCost(newOrder.Product, newOrder);
            newOrder.TotalPrice = calculate.getTotalPrice(newOrder.State, newOrder);
            bool didTheyScrewItUp = orderManager.ValidationAdd(newOrder.OrderID, newOrder.CustomerName, newOrder.AreaProvided);

            if (!didTheyScrewItUp)
            {
                Console.WriteLine("Order could not be processed because of incorrect formatting!");
                Console.WriteLine("Please try again!");
                Console.WriteLine("Press any key to continue...");
                return false;
            }
            else
            {
                ConsoleIO.DisplayOrderDetails(newOrder);

                if (ConsoleIO.GetYesNoAnswerFromUser("Add the following information").ToUpper() == "Y")
                {
                    orderManager.WhichOneToAdd(newOrder);
                    Console.WriteLine("Order Added!");
                    Console.WriteLine("Press any key to continue...");
                    return true;
                }
                else
                {
                    Console.WriteLine("Order Cancelled!");
                    Console.WriteLine("Press any key to continue...");
                    return false;
                }
            }
            Console.ReadKey();
        }
    }
}
