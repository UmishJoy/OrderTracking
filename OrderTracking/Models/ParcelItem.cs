using System.Xml.Serialization;

namespace OrderTracking.Models
{
    public class ParcelItem
    {
        public ParcelItem()
        {
            ItemCurrency = "GBP";
        }
        public int ItemQuantity { get; set; }
        public decimal ItemValue { get; set; }
        public decimal ItemWeight { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCurrency { get; set; }
        [XmlIgnore]
        public decimal TotalValue { get; set;}
        [XmlIgnore]
        public decimal TotalWeight { get; set; }
        [XmlIgnore]
        public string ParcelCode { get; set; }
       
    }
}
