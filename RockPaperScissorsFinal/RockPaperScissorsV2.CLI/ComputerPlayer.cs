using RockPaperScissorsV2.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsV2.CLI
{
    public class ComputerPlayer : IPlayer
    {
        Random random = new Random();

        public Weapon GetWeapon()
        {
            Weapon player2Weapon;
            switch (random.Next(1, 4))
            {
                case 1:
                    return player2Weapon = Weapon.Rock;
                case 2:
                    return player2Weapon = Weapon.Paper;
                case 3:
                    return player2Weapon = Weapon.Scissors;
                default:
                    return player2Weapon = Weapon.Scissors;
            }
        }
    }
}
