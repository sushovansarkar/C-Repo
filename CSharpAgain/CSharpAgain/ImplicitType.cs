using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    class ImplicitType
    {
        static void Main(string[] args)
        {
            var myInt = 0;
            var myBool = true;
            var myString = "Time marches on....";

            Console.WriteLine("myInt is: {0}", myInt.GetType().Name);
            Console.WriteLine("myBool is: {0}", myBool.GetType());
            Console.WriteLine("myString is: {0}", myString.GetType());

            Console.Read();
        }
    }
}
