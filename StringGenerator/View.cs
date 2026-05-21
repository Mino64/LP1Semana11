using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringGenerator
{
    public class View
    {


        public void printOnScreen(string input)
        {

            Console.WriteLine(input);

        }

        public void ErrorMessage()
        {
            Console.WriteLine("Nope");
        }
    }
}