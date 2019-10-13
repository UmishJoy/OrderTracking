using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderTracking.Models;

namespace OrderTracking
{
    interface IFileReader
    {
        List<string> ReadFile(string fileName);
    }
}
