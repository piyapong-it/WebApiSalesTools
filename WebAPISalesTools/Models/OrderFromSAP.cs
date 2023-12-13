using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPISalesTools.Models
{
    public class OrderFromSAP
    {
        [Key]
        public string OrderID { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public string OrderType { get; set; }
        public string DeliveryDate { get; set; }
        public string Optional3 { get; set; }
        public string DocumentID { get; set; }
        public string CompanyID { get; set; }
        public string SaleUnit { get; set; }
        public string SaleCode { get; set; }
        public string Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Address { get; set; }
        public decimal Total { get; set; }
        public decimal Money { get; set; }
        public decimal VATRate { get; set; }
        public decimal VATValue { get; set; }
        public string Discount_Rate { get; set; }
        public decimal Discount_Amount { get; set; }
        public string WarehouseID { get; set; }
        public string SaleType { get; set; }
        public string Remark { get; set; }
        public string SHIPTO { get; set; }
        public string BILLTO { get; set; }
        public string RefNo { get; set; }
        public string RefNo2 { get; set; }
        public string RefNo3 { get; set; }
        public string REF_15 { get; set; }
        public decimal Total_Remain { get; set; }
        public string PONO { get; set; }
        public string PODDate { get; set; }
        public string PODTime { get; set; }
        public string REF_1 { get; set; }
        public string REF_2 { get; set; }
        public string REF_3 { get; set; }
        public string REF_5 { get; set; }
        public string REF_6 { get; set; }
        public string REF_7 { get; set; }
        public string REF_8 { get; set; }
        public string REF_10 { get; set; }
        public string REF_11 { get; set; }
        public string REF_12 { get; set; }
        public string VAT { get; set; }
        public string ApproverStatus { get; set; }
        public string Canceled { get; set; }
        public string PRICELEVEL { get; set; }
        public decimal QuantityNotSend { get; set; }
        public string NDocumentID { get; set; }

        public DetailFromSAP[] Detail { get; set; }
    }
}
