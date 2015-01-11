using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharpAgain
{
    class PetNameComparer: IComparer
    {
        public int Compare(object x, object y)
        {
            Car c1 = x as Car;
            Car c2 = y as Car;

            if (c1 != null && c2 != null)
            {
                return string.Compare(c1.PetName, c2.PetName);
            }
            else
            {
                throw new ArgumentException("Invalid parameter(s) supplied!!!!");
            }
        }
    }

    class CarIDComparer: IComparer
    {
        public int Compare(object x, object y)
        {
            Car c1 = x as Car;
            Car c2 = y as Car;

            if (c1 != null && c2 != null)
            {
                return c1.CarID.CompareTo(c2.CarID);
            }
            else
            {
                throw new ArgumentException("Invalid parameter(s) supplied!!!!");
            }
        }
    }
    
    class SortOnDiffKeys
    {
        static void Main(string[] args)
        {
            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("Rusty", 80, 1);
            myAutos[1] = new Car("Mary", 40, 234);
            myAutos[2] = new Car("Viper", 40, 34);
            myAutos[3] = new Car("Mel", 40, 4);
            myAutos[4] = new Car("Chucky", 40, 5);

            Console.WriteLine("\nUnordered set of cars: \n");
            foreach (Car c in myAutos)
            {
                Console.WriteLine("{0} {1}", c.CarID, c.PetName);
            }

            //Array.Sort(myAutos);
            //Array.Sort(myAutos, new PetNameComparer());
            //Array.Sort(myAutos, new CarIDComparer());
            Array.Sort(myAutos, Car.SortByPetName);
            Console.WriteLine("\nOrdered set of cars:");
            foreach (Car c in myAutos)
            {
                Console.WriteLine("{0} {1}", c.CarID, c.PetName);
            }

            Console.ReadLine();
        }
    }
}
