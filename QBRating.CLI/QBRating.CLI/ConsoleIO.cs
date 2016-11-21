using QBRating.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.CLI
{
    class ConsoleIO
    {
        public static void DisplayPlayer(Player playerInfo)
        {
            Console.Clear();
            Console.WriteLine("Player Information");
            Console.WriteLine(Menu.bar);
            Console.WriteLine("Player Name: {0}", playerInfo.Name);
            Console.WriteLine("Passes Attempt: {0}", playerInfo.PassAttempted);
            Console.WriteLine("Passes Completed: {0}", playerInfo.PassCompleted);
            Console.WriteLine("Passing Yards: {0}", playerInfo.PassingYard);
            Console.WriteLine("Passing Touchdowns: {0}", playerInfo.PassingTD);
            Console.WriteLine("Interceptions: {0}", playerInfo.Interceptions);
            Console.WriteLine("QB Rating: {0} ", playerInfo.Rating);
            Console.WriteLine(Menu.bar);
        }

        internal static int GetPassInt(string attempt)
        {
            {
                int output;
                while (true)
                {
                    Console.Write(attempt);
                    string input = Console.ReadLine();
                    if (input == string.Empty)
                    {
                        continue;
                    }
                    else if (!int.TryParse(input, out output))
                    {
                        Console.WriteLine("You must enter a valid number for interceptions.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (output < 0)
                        {
                            Console.WriteLine("You must have a positive number of interceptions...");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        return output;
                    }
                }
            }
        }

        internal static bool SaveStats(string yes)
        {
            Console.Write(yes);
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                return true;
            }
            return false;
        }

        internal static int GetPassTD(string attempt)
        {
            {
                int output;
                while (true)
                {
                    Console.Write(attempt);
                    string input = Console.ReadLine();
                    if (input == string.Empty)
                    {
                        continue;
                    }
                    else if (!int.TryParse(input, out output))
                    {
                        Console.WriteLine("You must enter a valid number for touchdowns.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (output < 0)
                        {
                            Console.WriteLine("You must have only positive touchdowns...");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        return output;
                    }
                }
            }
        }

        internal static int GetPassYard(string attempt)
        {
            {
                int output;
                while (true)
                {
                    Console.Write(attempt);
                    string input = Console.ReadLine();
                    if (input == string.Empty)
                    {
                        continue;
                    }
                    else if (!int.TryParse(input, out output))
                    {
                        Console.WriteLine("You must enter a valid number for passing yards.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        return output;
                    }
                }
            }
        }

        internal static int GetPassComplete(string attempt)
        {
            {
                int output;
                while (true)
                {
                    Console.Write(attempt);
                    string input = Console.ReadLine();
                    if (input == string.Empty)
                    {
                        continue;
                    }
                    else if (!int.TryParse(input, out output))
                    {
                        Console.WriteLine("You must enter a valid number for passing completion.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (output < 0)
                        {
                            Console.WriteLine("You must have a passing completion of greather than 0...");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        return output;
                    }
                }
            }
        }

        internal static int GetPassAttempt(string attempt)
        {
            int output;
            while (true)
            {
                Console.Write(attempt);
                string input = Console.ReadLine();
                if (input == string.Empty)
                {
                    continue;
                }
                else if (!int.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter a valid number for passing attempt.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (output < 1)
                    {
                        Console.WriteLine("Player must have at least thrown 1 pass in order to calculated QB rating...");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    return output;
                }
            }
        }

        internal static string GetPlayerName(string name)
        {
            while (true)
            {
                Console.Write(name);
                string input = Console.ReadLine();
                if (input == string.Empty || String.IsNullOrWhiteSpace(input))
                {
                    continue;
                }
                else
                {
                    return input;
                }
            }
        }
    }
}
