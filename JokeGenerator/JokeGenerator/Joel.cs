using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator
{
    class Joel : IJoke
    {
        public string TellPunchLine()
        {
            string punchLine = "The second Law of Economics: They're both wrong.";
            return punchLine;
        }

        public string TellSetup()
        {
            string setupLine = "The First Law of Economics: For evey economist, there exists an equal and opposite economist.";
            return setupLine;
        }
    }
}
