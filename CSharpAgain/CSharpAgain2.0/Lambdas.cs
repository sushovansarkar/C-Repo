using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain2._0
{
    public delegate void EmptyArgument();
    class Lambdas
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            Predicate<int> TraditionalSyntax = new Predicate<int>(IsEvenNumber);    // Delegate
            //List<int> li = list.FindAll(TraditionalSyntax);

            //List<int> li = list.FindAll(delegate(int num)     // Anonymous Method
            //{   return (num % 2 == 0);   }  );

            //List<int> li = list.FindAll(x => (x % 2) == 0);   // LINQ
            List<int> li = list.FindAll(                        // Multiline LINQ uses curly braces "{}"
                (int x) =>
                {
                    Console.WriteLine("Element Scanning: {0}", x);
                    if ((x % 2) == 0)
                    {
                        Console.WriteLine("{0} is even", x);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //foreach (int item in li)
            //{
            //    Console.WriteLine(item);
            //}


            SimpleMath sm = new SimpleMath();
            sm.RegisterMathDelegate((msg, res) => 
                                    Console.WriteLine("Message: {0} Result: {1}", msg, res));
            sm.Add(10, 20);

            EmptyArgument ea = new EmptyArgument(() => Console.WriteLine("Hello World!!"));
            ea();
        }


        static bool IsEvenNumber(int num)
        {
            return (num % 2 == 0);
        }
    }


    class SimpleMath
    {
        public delegate void MathMessage(string msg, int num);
        private MathMessage mmDelegate;

        public void RegisterMathDelegate(MathMessage mm)
        {
            mmDelegate = mm;
        }

        public void Add(int x, int y)
        {
            mmDelegate("Addition Successful....", (x + y));
        }
    }
}
