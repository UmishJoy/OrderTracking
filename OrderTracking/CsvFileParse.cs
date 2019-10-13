using System;
using System.Collections.Generic;
using System.Linq;
using OrderTracking.Models;

namespace OrderTracking
{
    public class CsvFileParse : IParseFile<Order>
    {
        private List<string> _csvData;
        private IFileValidation<string[]> _fileValidation;
        private IFileWriter _fileWriter;

        public CsvFileParse(List<string> csvData,IFileValidation<string []> fileValidation)
        {
            _csvData = csvData;
            _fileValidation = fileValidation;
            _fileWriter = new FileWriter();
        }

        public List<Order> ParseFile()
        {
            
            int recordIndex = 0;
            List<Order> orders = new List<Order>();
            List<ParcelItem> parcelItems = new List<ParcelItem>();           
            List<Parcel> parcels = new List<Parcel>();           
            List<Consignment> Consignments = new List<Consignment>();
            try
            {
                foreach (string record in _csvData)
                {
                    if (recordIndex > 0)
                    {
                        
                        string[] Coloumns = record.Split(',');
                        if (_fileValidation.Validate(Coloumns))
                        {                     
                            ParcelItem parcelItem = new ParcelItem();

                            parcelItem.ParcelCode=Convert.ToString(Coloumns[2]);//parcel code
                            parcelItem.ItemQuantity = Convert.ToInt32(Coloumns[9]);
                            parcelItem.ItemValue = Convert.ToDecimal(Coloumns[10]);
                            parcelItem.ItemWeight = Convert.ToDecimal(Coloumns[11]);
                            parcelItem.ItemDescription = Convert.ToString(Coloumns[12]);
                            parcelItem.ItemCurrency = Convert.ToString(Coloumns[13]) != "" ? Convert.ToString(Coloumns[13]) : "GBP";
                            parcelItem.TotalValue = parcelItem.ItemValue * parcelItem.ItemQuantity;
                            parcelItem.TotalWeight = parcelItem.ItemWeight * parcelItem.ItemQuantity;

                            parcelItems.Add(parcelItem);

                            if (!parcels.Any(x => x.ParcelCode == Convert.ToString(Coloumns[2])))
                            {
                                Parcel parcel = new Parcel();
                                parcel.ConsignmentNo = Convert.ToString(Coloumns[1]);
                                parcel.ParcelCode = Convert.ToString(Coloumns[2]);
                                parcel.ParcelItems.Add(parcelItem);
                                parcel.TotalValue = parcelItem.TotalValue;
                                parcel.TotalWeight = parcelItem.TotalWeight;
                                parcels.Add(parcel);
                            }
                            else
                            {
                                Parcel parcel = parcels.Find(x => x.ParcelCode == Convert.ToString(Coloumns[2]));
                                parcel.ParcelItems.Add(parcelItem);
                                parcel.TotalValue = parcel.ParcelItems.Sum(x => x.TotalValue);
                                parcel.TotalWeight = parcel.ParcelItems.Sum(x => x.TotalWeight);
                            }

                            if (!Consignments.Any(x => x.ConsignmentNo == Convert.ToString(Coloumns[1])))
                            {
                                Consignment consignment = new Consignment();
                                consignment.OrderNo = Convert.ToString(Coloumns[0]);
                                consignment.ConsignmentNo = Convert.ToString(Coloumns[1]);
                                consignment.ConsigneeName = Convert.ToString(Coloumns[3]);
                                consignment.Address1 = Convert.ToString(Coloumns[4]);
                                consignment.Address2 = Convert.ToString(Coloumns[5]);
                                consignment.City = Convert.ToString(Coloumns[6]);
                                consignment.State = Convert.ToString(Coloumns[7]);
                                consignment.CountryCode = Convert.ToString(Coloumns[8]);
                                Parcel objparcel = parcels.Find(x => x.ParcelCode == Convert.ToString(Coloumns[2]));
                                consignment.Parcels.Add(objparcel);
                                consignment.TotalValue = objparcel.TotalValue;
                                consignment.TotalWeight = objparcel.TotalWeight;
                                Consignments.Add(consignment);
                            }
                            else
                            {
                                Consignment consignment = Consignments.Find(x => x.ConsignmentNo == Convert.ToString(Coloumns[1]));
                               List< Parcel> objparcels = parcels.FindAll(x => x.ConsignmentNo == Convert.ToString(Coloumns[1]));
                                consignment.Parcels = objparcels;
                                consignment.TotalValue = objparcels.Sum(x => x.TotalValue);
                                consignment.TotalWeight = objparcels.Sum(x => x.TotalWeight);
                            }

                            if (!orders.Any(x => x.OrderNo == Convert.ToString(Coloumns[0])))
                            {
                                Order order = new Order();
                                order.OrderNo = Convert.ToString(Coloumns[0]);                                
                                Consignment objConsign = Consignments.Find(x => x.ConsignmentNo == Convert.ToString(Coloumns[1]));                               
                                order.Consignments.Add(objConsign);
                                order.TotalValue = objConsign.TotalValue;
                                order.TotalWeight = objConsign.TotalWeight;
                                orders.Add(order);
                            }
                            else
                            {
                                Order order = orders.Find(x => x.OrderNo == Convert.ToString(Coloumns[0]));
                                List<Consignment> objconsignments = Consignments.FindAll(x => x.OrderNo == Convert.ToString(Coloumns[0]));                                
                                order.Consignments = objconsignments;
                                order.TotalValue = objconsignments.Sum(x => x.TotalValue);
                                order.TotalWeight = objconsignments.Sum(x => x.TotalWeight);
                            }

                        }                        

                    }                    
                    recordIndex++;
                }
            }
            catch (Exception ex)
            {
                _fileWriter.WriteExceptionLog(ex);
            }
            return orders;
        }
    }
}
