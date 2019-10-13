using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderTracking
{
    public class CreateXml
    {
        private IFileWriter _fileWriter;
        public CreateXml(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }
        public void ConvertToXMl(object input, XmlRootAttribute xmlRoot)
        {

            string xmlString = string.Empty;
            string fileName = "CSV_XML" + DateTime.Now.ToString("yyMMddHHmmss") + ".xml";
            try
            {
                XmlSerializer ser = new XmlSerializer(input.GetType(), xmlRoot);
                using (MemoryStream memStm = new MemoryStream())
                {
                    ser.Serialize(memStm, input);
                    memStm.Position = 0;
                    xmlString = new StreamReader(memStm).ReadToEnd();
                    _fileWriter.WriteFile(xmlString, fileName);
                }
            }
            catch(Exception ex)
            {
                _fileWriter.WriteExceptionLog(ex);
            }
        }
    }
}
