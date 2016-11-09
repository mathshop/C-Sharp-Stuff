using RockPaperScissorsV2.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsV2.BLL
{
    public class PaperPlayer : IPlayer
    {
        public Weapon GetWeapon()
        {
            return Weapon.Paper;
        }
    }
}
