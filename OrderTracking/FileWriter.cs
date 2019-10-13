using System;
using System.IO;


namespace OrderTracking
{
    public class FileWriter : IFileWriter
    {
        private string _folderPath;
        public FileWriter()
        {
            //bin\Debug\Data
            _folderPath = Path.Combine(Environment.CurrentDirectory, "Data"); 
        }
        public void WriteExceptionLog(Exception ex)
        {
            try
            {
                if (!Directory.Exists(_folderPath))
                    Directory.CreateDirectory(_folderPath);

                using (StreamWriter writer = File.AppendText(_folderPath + "\\" + "ExceptionLog.txt"))
                {
                    writer.Write("\r\nLog Entry : ");
                    writer.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());                   
                    writer.WriteLine("{0}: {1}","StackTrace", ex.StackTrace);
                    writer.WriteLine("{0}: {1}","Error", ex.Message);
                    writer.WriteLine("-----------------------------------------------------------");
                }
            }
            catch (Exception exc)
            {
            }
        }

        public void WriteFile(string data,string fileName)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(_folderPath + "\\" + fileName))
                {
                    
                    writer.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                WriteExceptionLog(ex);
            }
        }
    }
}
