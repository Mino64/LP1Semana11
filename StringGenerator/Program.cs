using System;
using System.Text;

namespace StringGenerator
{

    class Program
    {

        static void Main(string[] args)
        {
            View view = new();
            Controller con = new();
            con.RandomizeGen(args[0], view);
            

        }
    }
}