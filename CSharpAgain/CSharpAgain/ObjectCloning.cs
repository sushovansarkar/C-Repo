using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    class PointsDescription
    {
        public string PetName { get; set; }
        public Guid PointsID { get; set; }

        public PointsDescription()
        {
            PetName = "No Name";
            PointsID = Guid.NewGuid();
        }
    }
    
    class Points: ICloneable    // Depicts a HAS-A relationship with 'PointsDescription' class
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointsDescription pd = new PointsDescription();

        
        public Points() { }

        public Points(int X1, int Y1)
        {
            X = X1;
            Y = Y1;
        }

        public Points(int x, int y, string name)
        {
            X = x;
            Y = y;
            pd.PetName = name;
        }


        public override string ToString()
        {
            //return string.Format("X = {0}; Y = {1}", X, Y);
            return string.Format("X = {0}; Y = {1}; Name = {2};\nID = {3}\n",
                                X, Y, pd.PetName, pd.PointsID);
        }


        public object Clone()
        {
            //return new Points(X, Y);
            //return this.MemberwiseClone();     // Use this for shallow-copying
            
            // 1st obtain a shallow copy then, perform a deep copy for types that has reference type fields.
            Points p = (Points)this.MemberwiseClone();
            //PointsDescription desc = new PointsDescription();
            //desc.PetName = this.pd.PetName;
            //p.pd = desc;           
            p.pd = new PointsDescription();
            p.pd.PetName = this.pd.PetName;

            return p;
        }
    }   

    class ObjectCloning
    {
        static void Main(string[] args)
        {
            //Points p3 = new Points(100, 100);
            //Points p4 = (Points)p3.Clone();
            //p4.X = 0;
            
            //Console.WriteLine(p3);
            //Console.WriteLine(p4);

            Points p3 = new Points(100, 100, "Jane");
            Points p4 = (Points)p3.Clone();

            Console.WriteLine("Before modification:");
            Console.WriteLine("p3: {0}", p3);
            Console.WriteLine("p4: {0}", p4);

            p4.X = 9;
            p4.pd.PetName = "Abcdef";

            Console.WriteLine("After modification:");
            Console.WriteLine("p3: {0}", p3);
            Console.WriteLine("p4: {0}", p4);

            Console.ReadLine();
        }
    }
}
