using System.ComponentModel.DataAnnotations;

namespace WebAPISalesTools.Models
{
    public class DetailFromSAP
    {
        [Key]
        public string OrderID { get; set; }
        public string OrderDate { get; set; }
        public int No { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int QuantityMain { get; set; }
        public string UnitMain { get; set; }
        public string UnitMainName { get; set; }
        public int QuantityMinor { get; set; }
        public string UnitMinor { get; set; }
        public string UnitMinorName { get; set; }
        public decimal Total { get; set; }
        public decimal Unit2Rate { get; set; }
        public decimal QuantityMinor3 { get; set; }
        public string UnitMinor3 { get; set; }
        public string UnitMinorName3 { get; set; }
        public string Discount_Rate { get; set; }
        public string Unit3Rate { get; set; }
        public string VAT { get; set; }
        public string TaxType { get; set; }
        public string OrderType { get; set; }
        public decimal TotalQuantity { get; set; }
        public string SaleUnit { get; set; }
        public decimal TotalExvat { get; set; }
        public decimal TotalInvat { get; set; }
        public decimal DiscountExvat { get; set; }
        public decimal DiscountInvat { get; set; }
        public string LotNumber { get; set; }

    }
}
