using System;

namespace RockPaperScissorsV2.BLL
{
    public class RockPaperScissorsGame
    {
        private IPlayer _player1;
        private IPlayer _player2;


        public RockPaperScissorsGame(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public Outcome Play()
        {
            Outcome outcome;
            Console.Clear();  
            Console.WriteLine("Player 1's turn...");
            Weapon player1Weapon = _player1.GetWeapon();
           
            Console.Clear();
            Console.WriteLine("Player 2's turn...");         
            Weapon player2Weapon = _player2.GetWeapon();
          // Player1sWeapon(player1Weapon, player2Weapon);

            Console.Clear();

            if (player1Weapon == player2Weapon)
            {              
                outcome = Outcome.Draw;             
            }
            else if (player1Weapon == Weapon.Rock && player2Weapon == Weapon.Scissors
                || player1Weapon == Weapon.Scissors && player2Weapon == Weapon.Paper
                || player1Weapon == Weapon.Paper && player2Weapon == Weapon.Rock)
            {            
                outcome = Outcome.Player1Wins;
            }
            else
            {             
                outcome = Outcome.Player2Wins;
            }
            return outcome;
        }

        //public Weapon PlayersWeapons(Weapon player1, Weapon player2)
        //{

            
            

        //}
    }
}
