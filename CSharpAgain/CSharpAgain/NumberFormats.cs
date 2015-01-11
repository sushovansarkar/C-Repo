using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    class NumberFormats
    {

        static void Main(string[] args)
        {
            int num = 99999;

            Console.WriteLine("The value of {0} in various formats:", num);

            Console.WriteLine("c format: {0:c}", num);
            Console.WriteLine("d9 format: {0:d9}", num);
            Console.WriteLine("f3 format: {0:f3}", num);
            Console.WriteLine("n format: {0:n}", num);
            Console.WriteLine("x format: {0:x}", num);
            Console.WriteLine("X format: {0:X}", num);

        }

    }
}
