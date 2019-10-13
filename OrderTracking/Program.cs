using System;
using System.Collections.Generic;
using System.IO;


namespace OrderTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Path(csv,xml,logs):"+ Path.Combine(Environment.CurrentDirectory, "Data"));
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
            ProcessCSVtoXML processCSVtoXML = new ProcessCSVtoXML();
            processCSVtoXML.CSVFileProcess();
            Console.WriteLine("Output path:" + Path.Combine(Environment.CurrentDirectory, "Data"));
            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }

       
    }
}
