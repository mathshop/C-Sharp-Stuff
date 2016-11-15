using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator
{
    class Zach : IJoke
    {
        public string TellPunchLine()
        {
            string punchLine = "Employee: Nobody has ever complained about my BackEnd before.";
            return punchLine;
        }

        public string TellSetup()
        {
            string setupLine = "Engineer team lead: I have had some complaints about your BackEnd on this project.";
            return setupLine;
        }
    }
}
