using RockPaperScissorsV2.BLL;
using System;

namespace RockPaperScissorsV2.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Rock Paper Scissors";
            Console.WriteLine("Let's play ROCK PAPER SCISSORS!");
            bool continuePlaying;
            do
            {
                IPlayer player1 = PlayerFactory.GetPlayer1();
                IPlayer player2 = PlayerFactory.GetPlayer2();
                RockPaperScissorsGame game = new RockPaperScissorsGame(player1, player2);
                Outcome outcome = game.Play();  
               


                 switch(outcome)
                {
                    case Outcome.Player1Wins:
                        //Console.WriteLine($"Player 1 used a {player1Weapon} and Player 2 used a {player2Weapon}.");
                        Console.WriteLine($"Player 1 wins!!!");
                        break;
                    case Outcome.Player2Wins:
                        //Console.WriteLine($"Player 1 used a {player1Weapon} and Player 2 used a {player2Weapon}.");
                        Console.WriteLine($"Player 2 wins!!!");
                        outcome = Outcome.Player2Wins;
                        break;
                    default:
                        //Console.WriteLine($"Player 1 used a {player1Weapon} and Player 2 used a {player2Weapon}.");
                        Console.WriteLine("It's a draw!");
                        break;
                }
                
                
                
                    
                Console.Write("If you Would you like to play again, please type Y...");
                string playAgain = Console.ReadLine();
                continuePlaying = playAgain.ToUpper() == "Y";
            } while (continuePlaying);
            Console.WriteLine("Thank you for playing. Please press any key to quit.");
            Console.ReadKey();
        }
    }
}
