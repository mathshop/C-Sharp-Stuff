﻿using RockPaperScissorsV2.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsV2.BLL
{
    public class RockPlayer : IPlayer
    {
        public Weapon GetWeapon()
        {
            return Weapon.Rock;
        }
    }
}
