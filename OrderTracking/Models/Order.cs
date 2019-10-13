using System.Collections.Generic;


namespace OrderTracking.Models
{
    public class Order
    {       
        public Order()
        {
            Consignments = new List<Consignment>();
        }
        public string OrderNo { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalWeight { get; set; }
        public List<Consignment> Consignments { get; set; }
    }
}
