using FlooringMaster.BLL;
using FlooringMaster.Models;
using FlooringMastery.CLI.WorkFlow;
using FlooringMastery.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.CLI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(Order OrderInfo)
        {
            Console.Clear();
            Console.WriteLine("Order Information");
            Console.WriteLine(Menu.separatorBar);
            Console.WriteLine("ID: {0}", OrderInfo.NumberID);
            Console.WriteLine("Order ID: {0}", OrderInfo.OrderID);
            Console.WriteLine("Name: {0}", OrderInfo.CustomerName);
            Console.WriteLine("State: {0}", OrderInfo.State);
            Console.WriteLine("Product Type: {0}", OrderInfo.Product);
            Console.WriteLine("Area Provided: {0}", OrderInfo.AreaProvided);
            Console.WriteLine("Total Product Cost: ${0}", OrderInfo.TotalProductCost);
            Console.WriteLine("Total Labor Cost: ${0}", OrderInfo.TotalLaborCost);
            Console.WriteLine("{0} Tax: {1}%", OrderInfo.State, OrderInfo.Tax);
            Console.WriteLine("Total Price: ${0}", OrderInfo.TotalPrice);
        }

        public static string GetOrderID(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input.Count() != 8)
                {
                    Console.WriteLine("You must enter a valid Order ID (MMDDYYYY).");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }

        public static string GetCustomerName(string prompt)
        {
            Console.Write(prompt);
            prompt = Console.ReadLine();
            return prompt;
        }

        public static States GetStateFromUser(string state)
        {
            Console.Write(state);
            States theStates = new States();
            state = Console.ReadLine().ToUpper();
            if (state == "IA")
            {
                theStates = States.IA;
            }
            if (state == "MN")
            {
                theStates = States.MN;
            }
            if (state == "ND")
            {
                theStates = States.ND;
            }
            if (state == "SD")
            {
                theStates = States.SD;
            }
            if (state == "WI")
            {
                theStates = States.WI;
            }
            if (state == "")
            {
                return theStates;
            }
            return theStates;
        }

        public static ProductTypes GetProductTypeFromUser(string productType)
        {
            Console.Write(productType);
            ProductTypes theProductTypes = new ProductTypes();
            productType = Console.ReadLine().ToUpper();

            if (productType == "W")
            {
                theProductTypes = ProductTypes.Wood;
            }
            if (productType == "T")
            {
                theProductTypes = ProductTypes.Tile;
            }
            if (productType == "C")
            {
                theProductTypes = ProductTypes.Carpet;
            }
            if (productType == "L")
            {
                theProductTypes = ProductTypes.Laminate;
            }
            if (productType == "")
            {
                return theProductTypes;
            }
            return theProductTypes;
        }

        public static decimal GetArea(string prompt)
        {
            decimal output;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input == string.Empty)
                {
                    return 0;
                }
                else if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter a valid Area.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (output < 0)
                    {
                        Console.WriteLine("You must have an area greather than 0...");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    return output;
                }
            }
        }

        public static string GetYesNoAnswerFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter a Y/N.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter a Y/N.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    return input;
                }
            }
        }

        public static string GetOrderIDFromUser(string prompt)
        {
            int output;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!int.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter a valid Order ID (MMDDYYYY).");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return output.ToString();
                }
            }
        }

        public static int GetNumberIDFromUser(string getNumber)
        {
            int output;
            Console.Write(getNumber);
            string input = Console.ReadLine();
            if (!int.TryParse(input, out output))
            {
                Console.WriteLine("You must enter a valid Number ID.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            return output;
        }

        public static string ConvertURLToString(string orderID)
        {
            string newAddress = $"{FilePath.directoryfolder}\\Orders_{orderID}.txt".ToString();
            return newAddress;
        }
    }
}
