using System;
using OrderTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace OrderTrackingTest
{
    [TestClass]
    public class CSVFileTest
    {
       
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void File_Name_Null_Exception()
        {
            IFileWriter fileWriter = new FileWriter();
            var obj = new CsvFileRead(fileWriter);
            obj.ReadFile(null);
           
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void File_Name_WhiteSpace_Exception()
        {
            IFileWriter fileWriter = new FileWriter();
            var obj = new CsvFileRead(fileWriter);
            obj.ReadFile(" ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void File_Type_Failed()
        {
            IFileWriter fileWriter = new FileWriter();
            var obj = new CsvFileRead(fileWriter);
            obj.ReadFile("Test.txt");                 
        }
        [TestMethod]     
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFound()
        {
            IFileWriter fileWriter = new FileWriter();
            var obj = new CsvFileRead(fileWriter);
            obj.ReadFile("Test.csv");         
        }
    }
}
