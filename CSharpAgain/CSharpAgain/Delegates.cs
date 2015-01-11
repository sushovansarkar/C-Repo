using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    class MathClass
    {
        public static int Add(int x, int y) { return x + y; }
        public int Subtract(int x, int y) { return x - y; }
        public static int Multiply(int x, int y) { return x * y; }
        public static int Divide(int x, int y) { return x / y; }
        public static void DisplayDelegateInfo(Delegate del)
        {
            foreach (Delegate d in del.GetInvocationList())
            {
                Console.WriteLine("Method Name: " + d.Method);
                Console.WriteLine("Type Name: " + (d.Target ?? "Null"));
            }
        }
    }

    public delegate int NumberOp(int a, int b);

    class Delegates
    {
        static void Main(string[] args)
        {
            NumberOp op = new NumberOp(MathClass.Add);
            //op = new NumberOp(new MathClass().Subtract);
            //op = new MathClass().Subtract;
            //op += MathClass.subtract;

            Console.WriteLine("10 + 10 is {0}", op(10, 10));
            //Console.WriteLine("10 + 10 is {0}", op.Invoke(10, 10));
            MathClass.DisplayDelegateInfo(op);

            Func<int, int, int> intSum = new Func<int, int, int>(MathClass.Add);
            Console.WriteLine("10 + 10 is {0}", intSum(10, 10));
            
            Console.ReadLine();
        }
    }
}
