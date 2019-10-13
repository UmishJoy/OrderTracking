using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracking
{
    interface IParseFile<T>
    {
        List<T> ParseFile();
    }
}
