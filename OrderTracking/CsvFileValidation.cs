using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderTracking.Models;

namespace OrderTracking
{
    public class CsvFileValidation:IFileValidation<string[]>
    {
        private bool _valid;
        public CsvFileValidation()
        {
            _valid = true;
        }
        public bool Validate(string[] row)
        {

            if (row.Length < 14)
                _valid = false;
            else
            {
                if (string.IsNullOrWhiteSpace(row[0]))
                    _valid = false;
                if (string.IsNullOrWhiteSpace(row[1]))
                    _valid = false;
                if (string.IsNullOrWhiteSpace(row[2]))
                    _valid = false;
                if (string.IsNullOrWhiteSpace(row[3]))
                    _valid = false;
                if (string.IsNullOrWhiteSpace(row[4]))
                    _valid = false;
                if (string.IsNullOrWhiteSpace( row[9]))
                    _valid = false;
                else
                {
                    int n;
                    if (!int.TryParse(row[9].ToString(), out n))
                        _valid = false;
                }
                if (string.IsNullOrWhiteSpace(row[10]))
                    _valid = false;
                else
                {
                    decimal d;
                    if (!decimal.TryParse(row[10].ToString(), out d))
                        _valid = false;
                }
                if (string.IsNullOrWhiteSpace(row[11]))
                    _valid = false;
                else
                {
                    decimal d;
                    if (!decimal.TryParse(row[11].ToString(), out d))
                        _valid = false;
                }
                
            }
            return _valid;
        }
    }
}
