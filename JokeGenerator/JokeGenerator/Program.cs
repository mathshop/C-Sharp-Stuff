using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            Zach zachJoke = new Zach();
            Joel joelJoke = new Joel();
            Cheng chengJoke = new Cheng();


            JokeTeller jokeTeller = new JokeTeller(zachJoke);
            jokeTeller.TellJoke();
            Console.Clear();

            jokeTeller = new JokeTeller(joelJoke);
            jokeTeller.TellJoke();
            Console.Clear();

            jokeTeller = new JokeTeller(chengJoke);
            jokeTeller.TellJoke();
            Console.Clear();
        }
    }
}
