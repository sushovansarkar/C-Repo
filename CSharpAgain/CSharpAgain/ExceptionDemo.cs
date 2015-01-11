using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    class CarIsDeadException: System.ApplicationException
    {
        //string messageDetails;

        public string CauseOfError { get; set; }

        public string ErrorTimeStamp { get; set; }

        public CarIsDeadException() { }

        public CarIsDeadException(string msg, string cause, string errorts): base(msg)
        {
            //messageDetails = msg;
            CauseOfError = cause;
            ErrorTimeStamp = errorts;
        }

        public override string Message
        {
            get
            {
                //return string.Format("Car Error Message: {0}", messageDetails);
                return base.Message;
            }
        }
    }

    class Radio
    {
        public void TurnOn(bool on)
        {
            if (on)
                Console.WriteLine("Jamming....");
            else
                Console.WriteLine("Quiet time....");
        }
    }

    class Car: IComparable  // Interface implemented to sort collection based on various keys
    {
        public const int MaxSpeed = 100;

        // Car properties.
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }
        public int CarID { get; set; }      // Property added to demonstrate Sorting of object based on different keys

        public static IComparer SortByPetName
        {
            get
            {
                return (IComparer)new PetNameComparer();
            }
        }

        // Is the car still operational?
        private bool CarIsDead;

        // A car has-a radio.
        private Radio theMusicBox = new Radio();
        
        // Constructors.
        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        public Car(string name, int currSp, int id)
        {
            CurrentSpeed = currSp;
            PetName = name;
            CarID = id;
        }


        public void CrankTunes(bool state)
        {
            theMusicBox.TurnOn(state);
        }

        // See if Car has overheated.
        public void Accelerate(int delta)
        {
            if (CarIsDead)
            {
                Console.WriteLine("{0} is out of order", PetName);
            }
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    //Console.WriteLine("{0} has overheated!", PetName);
                    CurrentSpeed = 0;
                    CarIsDead = true;
                    
                    //throw new Exception(string.Format("{0} has overheated!", PetName));
                    //Exception e = new Exception(string.Format("{0} has overheated!", PetName));
                    //e.HelpLink = "www.google.com";
                    //e.Data.Add("Timestamp", string.Format("The car exploded at {0}.", DateTime.Now));
                    //e.Data.Add("Cause", "You've a lead foot!");
                    CarIsDeadException e = new CarIsDeadException(string.Format("{0} has overheated, for God's sake!", PetName), 
                        "You have a lead foot", DateTime.Now.ToString());
                    throw e;
                }
                else
                {
                    Console.WriteLine("=> Current Speed = {0}", CurrentSpeed);
                }
            }
        }

        public int CompareTo(object obj)
        {
            Car newCar = obj as Car;
            if (newCar != null)
            {
                //return this.CarID.CompareTo(newCar.CarID);
                return this.PetName.CompareTo(newCar.PetName);
            }
            else
            {
                throw new ArgumentException("Parameter is not Car!!!!");
            }
        }
    }

    class ExceptionDemo
    {
        static void Main(string[] args)
        {
            Car car = new Car("Chevrolet", 20);
            car.CrankTunes(true);

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    car.Accelerate(10);
                }
            }
            //catch (Exception e)
            catch(CarIsDeadException e)
            {
                Console.WriteLine("Method: " + e.TargetSite);
                Console.WriteLine("Class defining member: " + e.TargetSite.DeclaringType);
                Console.WriteLine("Member type: " + e.TargetSite.MemberType);

                Console.WriteLine("Message: " + e.Message);
                Console.WriteLine("Source: " + e.Source);

                Console.WriteLine("Stack: " + e.StackTrace + "\n");

                Console.WriteLine("Help link: " + e.HelpLink);

                if (e.Data != null)
                {
                    Console.WriteLine("\nCustom Data:");
                    foreach (DictionaryEntry de in e.Data)
                    {
                        Console.WriteLine("-> {0}:{1}", de.Key, de.Value);
                    }
                }
                //throw;
            }

            Console.ReadLine();
        }
    }
}
