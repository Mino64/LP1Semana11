using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringGenerator
{
    public class Controller
    {

        public void RandomizeGen(string input, View view)
        {
            try
            {
                //int.Parse(input);
               // int seed = int.Parse(input);
                view.printOnScreen(Model.Generate(int.Parse(input)));
            }
            catch
            {
                view.ErrorMessage();
            }


        }
    }
}