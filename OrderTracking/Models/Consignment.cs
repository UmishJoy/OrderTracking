using System.Collections.Generic;
using System.Xml.Serialization;

namespace OrderTracking.Models
{
    public class Consignment
    {
        public Consignment()
        {
            Parcels = new List<Parcel>();
        }

        [XmlIgnore]
        public string OrderNo { get; set; }
        public string ConsignmentNo { get; set; }
        public string ConsigneeName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public List<Parcel> Parcels { get; set; }
        [XmlIgnore]
        public decimal TotalValue { get; set; }
        [XmlIgnore]
        public decimal TotalWeight { get; set; }

    }
}
