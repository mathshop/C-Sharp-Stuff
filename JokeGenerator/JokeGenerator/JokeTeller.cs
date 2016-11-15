using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator
{
    class JokeTeller
    {
        IJoke joke;
        public JokeTeller(IJoke joke)
        {
            this.joke = joke;

        }
        public void TellJoke()
        {
            Console.WriteLine(joke.TellSetup());
            Console.ReadKey();
            Console.WriteLine(joke.TellPunchLine());
            Console.ReadKey();
        }



    }


}
