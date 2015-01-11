using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    class Params
    {
        static double CalculateAverage(params double[] values)
        {
            if (values.Length == 0)
                return 0;   
            else
                return values.Average();
        }

        static void Main(string[] args)
        {
            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine("Average = {0}", average);

            double[] arr = { 1, 2, 3, 4, 5 };
            average = CalculateAverage(arr);
            Console.WriteLine("Average = {0}", average);

            Console.WriteLine("Average of no data = {0}", CalculateAverage());

            Console.Read();
        }
    }
}
