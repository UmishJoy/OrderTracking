using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderTracking.Models;
using System.IO;
using System.Net.Http;

namespace OrderTracking
{
    public class CsvFileRead : IFileReader
    {
       
        private IFileWriter _fileWriter;
        public CsvFileRead(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;                
        }
        public List<string> ReadFile(string fileName)
        {
            StreamReader reader = null;
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name cannot be null or white space.");
            }
            if (Path.GetExtension(fileName).ToUpper() != ".CSV")
            {
                throw new ArgumentException("File type should be .csv");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File is not found at given path");
            }
            try
            {
               
                reader = new StreamReader(File.OpenRead(fileName));                        
                List<string> csvFileData = new List<string>();                      
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();                                  
                    if (!String.IsNullOrWhiteSpace(row))
                    {                        
                        csvFileData.Add(row);
                    }
                }
               
                return csvFileData;
            }
            catch(Exception ex)
            {
                _fileWriter.WriteExceptionLog(ex);
                return null;
            }
            finally
            {
                if(reader!=null)
                reader.Close();
            }
        }
    }
}
