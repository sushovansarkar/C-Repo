using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    class MotorCycle
    {
        public int driverIntensity;
        public string driverName;

        public MotorCycle() { }

        public MotorCycle(int intensity)
            : this(intensity, "")
        {
            //this.driverIntensity = intensity;
            Console.WriteLine("In constructor taking int");
        }

        public MotorCycle(string name)
            : this(0, name)
        {
            //this.driverName = name;
            Console.WriteLine("In constructor taking string");
        }

        public MotorCycle(int intensity, string name)
        {
            driverIntensity = (intensity > 10) ? 10 : intensity;
            driverName = name;
            Console.WriteLine("In constructor taking (int, string)");
        }

        //static void Main(string[] args)
        //{
        //    //MotorCycle c = new MotorCycle();
        //    //Console.WriteLine("Rider name is {0}, Rider intensity = {1}", c.driverName, c.driverIntensity);
        //    MotorCycle m = new MotorCycle(5);
        //    Console.WriteLine("Rider name is {0}, Rider intensity = {1}", m.driverName, m.driverIntensity);
        //    Console.ReadLine();
        //}
    }

    class MotorCycleRevised
    {
        public int driverIntensity;
        public string driverName;

        public MotorCycleRevised(int intensity = 0, string name = "")
        {
            driverIntensity = (intensity > 10) ? 10 : intensity;
            driverName = name;
        }

        //static void Main(string[] args)
        //{
        //    MotorCycleRevised m1 = new MotorCycleRevised();
        //    Console.WriteLine("Name = {0}, Intensity = {1}", m1.driverName, m1.driverIntensity);
        //    MotorCycleRevised m2 = new MotorCycleRevised(name: "Tiny");
        //    Console.WriteLine("Name = {0}, Intensity = {1}", m2.driverName, m2.driverIntensity);
        //    MotorCycleRevised m3 = new MotorCycleRevised(15);
        //    Console.WriteLine("Name = {0}, Intensity = {1}", m3.driverName, m3.driverIntensity);

        //    Console.ReadLine();
        //}
    }

    class ConstructorChain
    {
        static void Main(string[] args)
        {
            //MotorCycle c = new MotorCycle();
            //Console.WriteLine("Rider name is {0}, Rider intensity = {1}", c.driverName, c.driverIntensity);
            //MotorCycle m = new MotorCycle(5);
            //Console.WriteLine("Rider name is {0}, Rider intensity = {1}", m.driverName, m.driverIntensity);
            //Console.ReadLine();

            MotorCycleRevised m1 = new MotorCycleRevised();
            Console.WriteLine("Name = {0}, Intensity = {1}", m1.driverName, m1.driverIntensity);
            MotorCycleRevised m2 = new MotorCycleRevised(name: "Tiny");
            Console.WriteLine("Name = {0}, Intensity = {1}", m2.driverName, m2.driverIntensity);
            MotorCycleRevised m3 = new MotorCycleRevised(15);
            Console.WriteLine("Name = {0}, Intensity = {1}", m3.driverName, m3.driverIntensity);

            Console.ReadLine();

        }
    }
}
