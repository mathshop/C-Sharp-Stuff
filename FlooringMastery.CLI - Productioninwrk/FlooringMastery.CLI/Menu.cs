using FlooringMaster.BLL;
using FlooringMastery.BLL;
using FlooringMastery.CLI.WorkFlow;
using FlooringMastery.UI.WorkFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public static class Menu
    {
        public const string separatorBar = "------------------------";
        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine(separatorBar);
            Console.WriteLine("Flooring Program");
            Console.WriteLine("1. Display Orders");
            Console.WriteLine("2. Add an Order");
            Console.WriteLine("3. Edit an Order");
            Console.WriteLine("4. Remove an Order");
            Console.WriteLine("\nQ to quit");
            Console.WriteLine(separatorBar);
            Console.Write("\nEnter selection: ");
        }

        private static bool ProcessChoice()
        {
            string userinput = Console.ReadLine();
            switch (userinput.ToUpper())
            {
                case "1":
                    DisplayWorkFlow lookUpWorkFlow = new DisplayWorkFlow();
                    lookUpWorkFlow.Execute();
                    break;
                case "2":
                    AddWorkFlow addWorkFlow = new AddWorkFlow();
                    addWorkFlow.Execute();
                    break;
                case "3":
                    EditWorkFlow editWorkFlow = new EditWorkFlow();
                    editWorkFlow.Execute();
                    break;
                case "4":
                    RemoveOrderWorkFlow removeOrderWorkFlow = new RemoveOrderWorkFlow();
                    removeOrderWorkFlow.Execute();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("That is not a valid choice. Press any key to continue...");
                    break;
            }
            return true;
        }

        public static void MockDataLoader()
        {
            if (OrderManagerFactory.IsTestSystemOn())
            {
                LoadMockData loadMockData = new LoadMockData();
                loadMockData.Execute();
            }
        }
        public static void Start()
        {
            bool keepGoing = true;
            MockDataLoader();
            while (keepGoing)
            {
                DisplayMenu();
                keepGoing = ProcessChoice();
            }
        }
    }
}

