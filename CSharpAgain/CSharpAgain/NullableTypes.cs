using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAgain
{
    class DBReader
    {
        int? noOfFields = null;
        bool? status = true;

        public int? GetNoOfFields()
        { return noOfFields; }
        public bool? GetStatus()
        { return status; }
    }
    class NullableTypes
    {
        static void Main(string[] args)
        {
            DBReader dbr = new DBReader();
            int fieldNo = dbr.GetNoOfFields() ?? 0;
            bool stat = dbr.GetStatus() ?? false;

            if (dbr.GetNoOfFields().HasValue && dbr.GetStatus().HasValue)
            {
                Console.WriteLine("No. of fields: {0} \t Status: {1}", dbr.GetNoOfFields().Value, dbr.GetStatus());
            }
            else
            {
                Console.WriteLine("No. of fields: {0} \t Status: {1}", fieldNo, stat);
            }

            Console.ReadLine();
        }
    }
}
