using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharpAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (string item in args)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine("Command Line Arguments:-");
            foreach (var item in Environment.GetCommandLineArgs())
            {
                Console.WriteLine(item);
            }

            
            Console.WriteLine();
            foreach (var drives in Environment.GetLogicalDrives())
            {
                Console.WriteLine("Drive: {0}", drives);
            }

            Console.WriteLine("OS Version: {0}", Environment.OSVersion);
            Console.WriteLine("User Name : {0}", Environment.UserName);
            Console.WriteLine("Processor Count: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Framework Version: {0}", Environment.Version);

            Console.WriteLine("\nList of environment variables:-");
            foreach (DictionaryEntry envVar in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine(envVar.Key + " = " + envVar.Value);    
            }

            Console.Read();
        }
    }
}
