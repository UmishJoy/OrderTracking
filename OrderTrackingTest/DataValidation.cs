using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderTracking;

namespace OrderTrackingTest
{
    [TestClass]
    public class DataValidation
    {
        [TestMethod]
        [DataRow(new string[] { },DisplayName ="Length of the data array")]
        [DataRow(new string[] {null,null,null,null,null,null,null, null, null, null, null, null, null,null },DisplayName ="All null")]
        [DataRow(new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },DisplayName ="All White Space")]
        [DataRow(new string[] { "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test" },DisplayName ="All String")]
        [DataRow(new string[] { "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "2", "Test", "Test", "Test", "Test" },DisplayName ="Quantity only right")]
        [DataRow(new string[] { "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "2.5", "Test", "Test", "Test" }, DisplayName = "Item value only right")]
        [DataRow(new string[] { "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", ".001", "Test", "Test" }, DisplayName = "Item weight only right")]
        public void Validate_returnFalse(string[] input)
        {
            CsvFileValidation obj = new CsvFileValidation();            
            Assert.IsFalse(obj.Validate(input));
            
        }
        [TestMethod]
        [DataRow(new string[] { "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "2", "10", ".001", "Test", "Test" }, DisplayName = "Check Numbers")]
        [DataRow(new string[] { "Test", "Test", "Test", "Test", "Test", "", "", "", "", "2", "10.2", "1.001", "", "" }, DisplayName = "Check optional fields")]
        public void Validate_returnTrue(string[] input)
        {
            CsvFileValidation obj = new CsvFileValidation();
            Assert.IsTrue(obj.Validate(input));

        }
        
    }
}
