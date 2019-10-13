using OrderTracking.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderTracking
{
    public class ProcessCSVtoXML
    {
        private string _folderPath;
        private IFileWriter _fileWriter;
        public ProcessCSVtoXML()
        {
            //bin\Debug\Data
            _folderPath = Path.Combine(Environment.CurrentDirectory, "Data"); 
            _fileWriter = new FileWriter();
        }

        public void CSVFileProcess()
        {
            try
            {
                //Read CSV file from bin\Debug\Data
                CsvFileRead csvFileRead = new CsvFileRead(_fileWriter);
                List<string> records = csvFileRead.ReadFile(_folderPath + "\\CandidateTest_ManifestExample.csv");
                //Data validation and processing of data
                IFileValidation<string[]> validation = new CsvFileValidation();
                CsvFileParse csvFileParse = new CsvFileParse(records, validation);
                List<Order> Orders = csvFileParse.ParseFile();
                //Convert data object to xml and write the file to bin\Debug\Data
                XmlRootAttribute rootNode = new XmlRootAttribute("Orders");
                CreateXml objCreateXML = new CreateXml(_fileWriter);
                objCreateXML.ConvertToXMl(Orders, rootNode);
            }
            catch(Exception ex)
            {
                _fileWriter.WriteExceptionLog(ex);
            }
        }
    }
}
