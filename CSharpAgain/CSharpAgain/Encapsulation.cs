using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    partial class Employee
    {
        private string empName;
        private int empAge;
        private string empID;
        private double curPay;
        private string ssn;

        //public string Name
        //{
        //    get { return empName; }
        //    set 
        //    { 
        //        if(value.Length > 15)
        //            Console.WriteLine("Error! Name must be 15 characters or less.");
        //        else
        //            empName = value; 
        //    }
        //}

        //public int Age
        //{
        //    get { return empAge; }
        //    set { empAge = value; }
        //}

        //public string ID
        //{
        //    get { return empID; }
        //    set { empID = value; }
        //}

        //public double Pay
        //{
        //    get { return curPay; }
        //    set { curPay = value; }
        //}

        //public void PayBonus(double amount)
        //{
        //    //curPay += amount;   // Conventional Approach
        //    Pay += amount;      // Modern Approach
        //}

        public Employee(string eName = "", int eAge = 0, string eID = "", double ePay = 0.0, string ssn = "")
        {
            //Traditional Approach
            //empName = eName;
            //empAge = eAge;
            //empID = eID;
            //curPay = ePay;

            //Advacned and Better Approach
            Name = eName;
            Age = eAge;
            ID = eID;
            Pay = ePay;
            this.ssn = ssn;
        }
    }


    partial class Employee
    {
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Error! Name must be 15 characters or less.");
                else
                    empName = value;
            }
        }

        public int Age
        {
            get { return empAge; }
            set { empAge = value; }
        }

        public string ID
        {
            get { return empID; }
            set { empID = value; }
        }

        public double Pay
        {
            get { return curPay; }
            set { curPay = value; }
        }

        //Read-Only Property
        public string SocialSecurityNumber
        {
            get { return ssn; }
        }
        

        public virtual void PayBonus(double amount)
        {
            //curPay += amount;   // Conventional Approach
            Pay += amount;      // Modern Approach
        }

        public virtual void DisplayStats()   {
            Console.WriteLine("Name: " + Name + "\tAge: " + Age + "\tEmp ID: " + ID + "\tSalary: " + Pay
                + "\tSSN: " + ssn);
        }
    }

    class Encapsulation
    {
        static void Main(string[] args)
        {
            //Employee emp = new Employee("Marvin", 23, "34354", 15.6);
            Employee emp = new Employee("Marvin is a nefarious person", 23);
            Console.WriteLine("Employee: " + emp.Name + "\tAge: " + emp.Age);

            emp.Age++;  // Members can be used in conjuntion with intrinsic C# operators
            Console.WriteLine("Current Age: " + emp.Age);   

            Employee e = new Employee(eName: "Sushovan", ePay: 30000.0, ssn: "MX3434JH");
            e.PayBonus(1500.0);
            Console.WriteLine("Employee: " + e.Name + "\tRevised Pay: " + e.Pay + "\tSSN: " + e.SocialSecurityNumber);

            Console.ReadLine();
        }
    }
}
