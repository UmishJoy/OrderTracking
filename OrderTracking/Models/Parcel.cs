using System.Collections.Generic;
using System.Xml.Serialization;

namespace OrderTracking.Models
{
    public class Parcel
    {
        
        public Parcel()
        {
            ParcelItems = new List<ParcelItem>();
        }
        public string ParcelCode { get; set; }
        [XmlIgnore]
        public string ConsignmentNo { get; set; }
        public List<ParcelItem> ParcelItems { get; set; }
        [XmlIgnore]
        public decimal TotalValue { get; set; }
        [XmlIgnore]
        public decimal TotalWeight { get; set; }
    }
}
