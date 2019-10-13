using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracking
{
    public interface IFileWriter
    {
        void  WriteExceptionLog(Exception ex);
        void WriteFile(string data,string fileName);
    }
}
