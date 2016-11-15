using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator
{
    class Cheng : IJoke
    {
        public string TellPunchLine()
        {
            string punchLine = "Chuck Norris would be the punchline";
            return punchLine;
        }

        public string TellSetup()
        {
            string setupLine = "If this was a joke";
            return setupLine;
        }
    }
}
