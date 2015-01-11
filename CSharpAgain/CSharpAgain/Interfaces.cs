using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharpAgain
{
    public interface IPointy
    {
        //byte GetNumberOfPoints();   //Implicitly public and abstract
        
        byte Points { get; }        // Read-Only Property
    }

    
    abstract class Shape
    {
        public Shape(string name = "NoName")
        { PetName = name; }
       
        public string PetName { get; set; }
        
        // A single virtual method.
        public virtual void Draw()
        {
            Console.WriteLine("Inside Shape.Draw()");
        }
    }


    // Circle DOES NOT override Draw().
    class Circle : Shape, IPointy
    {
        public Circle() { }
        public Circle(string name) : base(name) { }

        public byte Points
        {
            get { return 0; }
        }
    }
    
    
    // Hexagon DOES override Draw().
    class Hexagon : Shape, IPointy
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }

        public byte Points
        {
            get { return 6; }
        }
    }


    class Garage: IEnumerable   // When using 'yield return' for iterator, implementing this interface is optional
    {
        private Car[] carArray = new Car[4];

        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Car c in carArray)
            {
                yield return c;
            }
            //return carArray.GetEnumerator();
        }

        public IEnumerable GetTheCars(bool status)
        {
            if (status)
            {
                for (int i = carArray.Length - 1; i >= 0; i--)
                {
                    yield return carArray[i];
                }
            }
            else
            {
                //foreach (Car  item in carArray)
                //{
                //    yield return item;                   
                //}
                yield return carArray[0];
                yield return carArray[1];
            }
        }

    }


    class Interfaces
    {
        static void Main(string[] args)
        {
            // Make an array of Shape-compatible objects.
            Shape[] myShapes = { new Hexagon(), new Circle(), new Hexagon("Mick"),
                                new Circle("Beth"), new Hexagon("Linda") };
            
            // Loop over each item and interact with the
            // polymorphic interface.
            foreach (Shape s in myShapes)
            {
                s.Draw();
            }

            Console.WriteLine(new Hexagon("Mick").Points);
            Console.WriteLine(new Circle("Beth").Points);

            Garage g = new Garage();
            //foreach (Car c in g)
            //{
            //    Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrentSpeed);
            //}

            foreach (Car item in g.GetTheCars(false))
            {
                Console.WriteLine("{0} is going {1} MPH", item.PetName, item.CurrentSpeed);
            }

            Console.ReadLine();
        }
    }
}
