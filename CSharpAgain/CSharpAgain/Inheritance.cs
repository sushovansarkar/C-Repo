using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    class Manager: Employee
    {
        public int StockOptions { get; set; }

        public Manager(string eName = "", int eAge = 0, string eID = "", double ePay = 0.0, string ssn = "", int options = 0)
            : base(eName, eAge, eID, ePay, ssn)
        {
            StockOptions = options;
        }

        public override void PayBonus(double amount)
        {
            base.PayBonus(amount);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Stock options: " + StockOptions);
        }
    }

    class SalesPerson: Employee
    {
        public int SalesNumber { get; set; }

        public override void PayBonus(double amount)
        {
               base.PayBonus(amount);
        }
    }

    partial class Employee
    {
        public class BenefitPackage
        {
            public enum BenefitPackageLevel
            {
                Standard, Platinum, Gold
            }

            public double PayDeduction()
            {
                return 125.0;
            }
        }
    }


    class Inheritance
    {
        static void GivePromotion(Employee emp)
        {
            if (emp is Manager)
            {
                Console.WriteLine("Manager Name: " + emp.Name + "\tStock options: " + ((Manager)emp).StockOptions);
            }
            else if (emp is SalesPerson)
            {
                
            }
        }
        
        static void Main(string[] args)
        {
            Manager m = new Manager("Fred", 12);
            m = new Manager(eName: "Sushovan", ssn: "YU983824FD", options: 15);
            m.DisplayStats();

            Employee.BenefitPackage.BenefitPackageLevel  benefitLevel = Employee.BenefitPackage.BenefitPackageLevel.Gold;

            GivePromotion(m);
            GivePromotion(new SalesPerson());
        }
    }
}
