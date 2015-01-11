using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    enum EmpType : short
    {
        Manager,
        Grunt,
        Contractor,
        VicePresident
    }
    
    class Enums
    {
        static void Main(string[] args)
        {
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);
            
            //Console.WriteLine(emp.GetType());
            Console.WriteLine("{0} uses {1} for storage", emp.GetType().Name, Enum.GetUnderlyingType(emp.GetType()));       // Enum instance used
            Console.WriteLine("{0} uses {1} for storage\n", emp.GetType().Name, Enum.GetUnderlyingType(typeof(EmpType)));     // Enum instance not used

            emp = EmpType.Manager;
            Console.WriteLine("{0} = {1}", emp, (short)emp);
            Console.WriteLine("{0} = {1}\n", emp.ToString(), (short)emp);

            Array arr = Enum.GetValues(emp.GetType());
            //Array arr = Enum.GetNames(emp.GetType());
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("{0} = {0:d}", arr.GetValue(i));
                //Console.WriteLine("{0} = {1}", arr.GetValue(i), (short)arr.GetValue(i));
            }

            Console.WriteLine();
            Array days = Enum.GetValues(typeof(DayOfWeek));
            for (int i = 0; i < days.Length; i++)
            {
                Console.WriteLine("{0} = {0:D}", days.GetValue(i));
            }
        }

        private static void AskForBonus(EmpType emp)
        {
            switch (emp)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You've got to be kidding!");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You got no dough.");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("Very well, Sir");
                    break;
                default:
                    break;
            }
        }
    }
}
