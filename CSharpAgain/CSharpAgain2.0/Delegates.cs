using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain2._0
{
    class CarEngineEventsArgs: EventArgs 
    {
        private readonly string msg;
        public CarEngineEventsArgs(string msg)
        {
            this.msg = msg;
        }

        public string Message 
        {
            get
            {   return msg;    }
        }
    }


    class Car
    {
        //public delegate void CarEngineHandler(string msg);  // Define the Delegate


        /********** Microsoft's pattern of declaring Delegate **********/
        public delegate void CarEngineHandler(object sender, CarEngineEventsArgs e);


        private CarEngineHandler listOfHandlers;            // Declare the Delegate object
        
        public string PetName { get; set; }
        public int MaxSpeed { get; set; }
        public int CurrentSpeed { get; set; }

        private bool CarIsDead;

        //public event CarEngineHandler AboutToBlow;
        //public event CarEngineHandler CarExploded;

        public event EventHandler<CarEngineEventsArgs> AboutToBlow;     // EventHandler<T> (object sender, T e) is a custom generic delegate
        public event EventHandler<CarEngineEventsArgs> CarExploded;     // This generic overcomes the need of declaring a separate delegate
        
        public Car()
        {
            MaxSpeed = 10;
            CarIsDead = false;
        }
        public Car(string name, int maxSpeed, int curSpeed)
        {
            PetName = name;
            MaxSpeed = maxSpeed;
            CurrentSpeed = curSpeed;
            CarIsDead = false;
        }

        public void RegisterWithCarEngine(CarEngineHandler carHandler)  // Helper method to add the Delegate object
        {
            listOfHandlers = carHandler;
        }

        public void Accelerate(int delta)       // Method that sends message to the caller
        {
            if (CarIsDead)
            {
                //if (listOfHandlers != null)
                //{
                //    listOfHandlers("Sorry!! This car is Dead..");
                //}
                if (CarExploded != null)
                {
                    //CarExploded("Sorry!! This car is Dead..");
                    CarExploded(this, new CarEngineEventsArgs("Sorry!! This car is Dead.."));
                }
            }
            else
            {
                CurrentSpeed += delta;
                //if ((MaxSpeed - CurrentSpeed) == 10 && listOfHandlers != null)
                //{
                //    listOfHandlers("Careful buddy.. The engine is gonna blow..");
                //}

                if ((MaxSpeed - CurrentSpeed) == 10 && AboutToBlow != null)
                {
                    //AboutToBlow("Careful buddy.. The engine is gonna blow..");
                    AboutToBlow(this, new CarEngineEventsArgs("Careful buddy.. The engine is gonna blow.."));
                }

                if (CurrentSpeed >= MaxSpeed && CarExploded != null)
                {
                    //listOfHandlers("Car has exploded....");
                    CarExploded(this, new CarEngineEventsArgs("Car has exploded...."));
                    CarIsDead = true;
                }
                else
                {
                    Console.WriteLine("Current Speed: {0}", CurrentSpeed);
                }
            }
        }
    }

    class Delegates
    {
        static void Main(string[] args)
        {
            Car C = new Car("SlugBug", 100, 10);
            //C.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            //C.RegisterWithCarEngine(OnCarEngineEvent);      // Method Group Conversion
            
            
            //C.AboutToBlow += new Car.CarEngineHandler(CarIsAlmostDoomed);
            //C.AboutToBlow += CarIsAlmostDoomed;     // Events can be registered using the Method Group Conversion syntax
            //C.AboutToBlow += C_AboutToBlow;     
            //C.CarExploded += C_CarExploded;

            
            // Anonymous Methods
            C.AboutToBlow += delegate(object sender, CarEngineEventsArgs e)
            {
                Console.WriteLine("=> Critical Message from Car: {0}", e.Message);
            };

            C.AboutToBlow += delegate   // It's OK to not recieve arguments sent by an event
            {
                Console.WriteLine("The car is going too fast. Slow down!!");
                //Console.WriteLine("=> AboutToBlow Message from Car: {0}", e.Message);
            };

            C.CarExploded += delegate(object sender, CarEngineEventsArgs e)
            {
                Console.WriteLine("=> Exploded Message from Car: {0}", e.Message);
            };


            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 10; i++)
            {
                C.Accelerate(10);
            }
           
            Console.ReadLine();
        }


        //static void C_CarExploded(string msg)
        static void C_CarExploded(object sender, CarEngineEventsArgs e)
        {
            //Console.WriteLine("=> Exploded Message from Car: {0}", msg);
            Console.WriteLine("=> Exploded Message from Car: {0}", e.Message);
        }

        //static void C_AboutToBlow(string msg)
        static void C_AboutToBlow(object sender, CarEngineEventsArgs e)
        {
            //Console.WriteLine("=> AboutToBlow Message from Car: {0}", msg);
            Console.WriteLine("=> AboutToBlow Message from Car: {0}", e.Message);
        }

        //static void CarIsAlmostDoomed(string msg)
        static void CarIsAlmostDoomed(object sender, CarEngineEventsArgs e)
        {
            Console.WriteLine("=> Critical Message from Car: {0}", e.Message);
        }

        public static void OnCarEngineEvent(string msg)     // Method that listens
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************\n");
        }
    }
}
