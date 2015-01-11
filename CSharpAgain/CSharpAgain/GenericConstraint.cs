using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    class GenericConstraint
    {
        //static void Swap<T>(ref T a, ref T b) where T: struct   // Will fail for types that don't inherit from System.ValueType
        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        //static T Add<T>(T arg1, T arg2) where T: struct { return arg1 + arg2; }     // '+', '-', '*', '/' can't be applied to T directly
        
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Generic Methods *****\n");
            
            // Swap 2 ints.
            int a = 10, b = 90;
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            //Swap<int>(ref a, ref b);
            Swap(ref a, ref b);     // Omission of the generic will work only if, at least one argument is passed in the function call
            Console.WriteLine("After swap: {0}, {1}", a, b);
            Console.WriteLine();
            
            // Swap 2 strings.
            string s1 = "Hello", s2 = "There";
            Console.WriteLine("Before swap: {0} {1}!", s1, s2);
            Swap<string>(ref s1, ref s2);
            Console.WriteLine("After swap: {0} {1}!", s1, s2);
            
            Console.ReadLine();
        }
    }
}
