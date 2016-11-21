using QBRating.CLI.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.CLI
{
    class Menu
    {
        public const string bar = "------------------------";
        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine(bar);
            Console.WriteLine("QB Calculator");
            Console.WriteLine("1. Calculate Player");
            Console.WriteLine("2. Search a Player");
            Console.WriteLine("3. View All Player");
            Console.WriteLine("\nQ to quit");
            Console.WriteLine(bar);
            Console.Write("\nEnter selection: ");
        }

        public static void Start()
        {
            LoadMockData load = new LoadMockData();
            load.Execute();
            bool keepGoing = true;
            while (keepGoing)
            {
                DisplayMenu();
                keepGoing = ProcessChoice();
            }
            Console.Clear();
            Console.WriteLine("Thank you for using QB Rating Calculator...");
            Console.WriteLine("Created by Cheng Thao");
            Console.ReadLine();
        }

        private static bool ProcessChoice()
        {
            string userinput = Console.ReadLine();
            switch (userinput.ToUpper())
            {
                case "1":
                    CalculateWorkFlow addWorkFlow = new CalculateWorkFlow();
                    addWorkFlow.Execute();
                    break;
                case "2":
                    DisplayWorkFlow lookUpWorkFlow = new DisplayWorkFlow();
                    lookUpWorkFlow.Execute();
                    break;
                case "3":
                    ViewAllWorkFlow viewAllWorkFlow = new ViewAllWorkFlow();
                    viewAllWorkFlow.Execute();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("That is not a valid choice. Press any key to continue...");
                    Console.ReadLine();
                    break;
            }
            return true;
        }
    }
}
