using RockPaperScissorsV2.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsV2.CLI
{
    public class HumanPlayer : IPlayer
    {
        public Weapon GetWeapon()
        {
            string player1Input = Console.ReadLine().ToUpper();
            Console.WriteLine("Choose 1 - Rock, 2 - Paper, or 3- Scissor!");
            player1Input = Console.ReadLine();
            Weapon player1Weapon;
            switch (player1Input)
            {
                case "1":
                    return player1Weapon = Weapon.Rock;
                case "2":
                    return player1Weapon = Weapon.Paper;
                case "3":
                    return player1Weapon = Weapon.Scissors;
                default:
                    return player1Weapon = Weapon.Scissors;
            }
        }
    }
}
