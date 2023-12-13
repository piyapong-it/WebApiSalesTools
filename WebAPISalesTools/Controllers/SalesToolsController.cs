using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using System.Text;
using WebAPISalesTools.Data;
using WebAPISalesTools.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace WebAPISalesTools.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class SalesToolsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        string connectionString = string.Empty;
        public SalesToolsController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
        }
        [HttpPost("PostSalesTools")]
        public async Task<IActionResult> PostSalesTools(List<OrderFromSAP> orderLists)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            int result = 0;
            foreach (OrderFromSAP order in orderLists)
            {
                string queryOrder = "SELECT * FROM  Order_List";
                SqlCommand commandSpOrder = new SqlCommand(queryOrder, conn);
                commandSpOrder.CommandText = "SpInsertOrder";
                commandSpOrder.CommandType = CommandType.StoredProcedure;
                commandSpOrder.Parameters.AddWithValue("@OrderID", order.OrderID);
                commandSpOrder.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                commandSpOrder.Parameters.AddWithValue("@OrderTime", order.OrderTime);
                commandSpOrder.Parameters.AddWithValue("@OrderType", order.OrderType);
                commandSpOrder.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
                commandSpOrder.Parameters.AddWithValue("@Optional3", order.Optional3);
                commandSpOrder.Parameters.AddWithValue("@DocumentID", order.DocumentID);
                commandSpOrder.Parameters.AddWithValue("@CompanyID", order.CompanyID);
                commandSpOrder.Parameters.AddWithValue("@SaleUnit", order.SaleUnit);
                commandSpOrder.Parameters.AddWithValue("@SaleCode", order.SaleCode);
                commandSpOrder.Parameters.AddWithValue("@Customer_Id", order.Customer_Id);
                commandSpOrder.Parameters.AddWithValue("@Customer_Name", order.Customer_Name);
                commandSpOrder.Parameters.AddWithValue("@Customer_Address", order.Customer_Address);
                commandSpOrder.Parameters.AddWithValue("@Total", order.Total);
                commandSpOrder.Parameters.AddWithValue("@Money", order.Money);
                commandSpOrder.Parameters.AddWithValue("@VATRate", order.VATRate);
                commandSpOrder.Parameters.AddWithValue("@VATValue", order.VATValue);
                commandSpOrder.Parameters.AddWithValue("@Discount_Rate", order.Discount_Rate);
                commandSpOrder.Parameters.AddWithValue("@Discount_Amount", order.Discount_Amount);
                commandSpOrder.Parameters.AddWithValue("@WarehouseID", order.WarehouseID);
                commandSpOrder.Parameters.AddWithValue("@SaleType", order.SaleType);
                commandSpOrder.Parameters.AddWithValue("@Remark", order.Remark);
                commandSpOrder.Parameters.AddWithValue("@SHIPTO", order.SHIPTO);
                commandSpOrder.Parameters.AddWithValue("@BILLTO", order.BILLTO);
                commandSpOrder.Parameters.AddWithValue("@RefNo", order.RefNo);
                commandSpOrder.Parameters.AddWithValue("@RefNo2", order.RefNo2);
                commandSpOrder.Parameters.AddWithValue("@RefNo3", order.RefNo3);
                commandSpOrder.Parameters.AddWithValue("@RefNo15", order.REF_15);
                commandSpOrder.Parameters.AddWithValue("@Total_Remain", order.Total_Remain);
                commandSpOrder.Parameters.AddWithValue("@PONO", order.PONO);
                commandSpOrder.Parameters.AddWithValue("@PODDate", order.PODDate);
                commandSpOrder.Parameters.AddWithValue("@PODTime", order.PODTime);
                commandSpOrder.Parameters.AddWithValue("@REF_1", order.REF_1);
                commandSpOrder.Parameters.AddWithValue("@REF_2", order.REF_2);
                commandSpOrder.Parameters.AddWithValue("@REF_3", order.REF_3);
                commandSpOrder.Parameters.AddWithValue("@REF_5", order.REF_5);
                commandSpOrder.Parameters.AddWithValue("@REF_6", order.REF_6);
                commandSpOrder.Parameters.AddWithValue("@REF_7", order.REF_7);
                commandSpOrder.Parameters.AddWithValue("@REF_8", order.REF_8);
                commandSpOrder.Parameters.AddWithValue("@REF_10", order.REF_10);
                commandSpOrder.Parameters.AddWithValue("@REF_11", order.REF_11);
                commandSpOrder.Parameters.AddWithValue("@REF_12", order.REF_12);
                commandSpOrder.Parameters.AddWithValue("@VAT", order.VAT);
                commandSpOrder.Parameters.AddWithValue("@ApproverStatus", order.ApproverStatus);
                commandSpOrder.Parameters.AddWithValue("@Canceled", order.Canceled);
                commandSpOrder.Parameters.AddWithValue("@PRICELEVEL", order.PRICELEVEL);
                commandSpOrder.Parameters.AddWithValue("@QuantityNotSend", order.QuantityNotSend);
                commandSpOrder.Parameters.AddWithValue("@NDocumentID", order.NDocumentID);
                result = commandSpOrder.ExecuteNonQuery();

                foreach (DetailFromSAP orderDetail in order.Detail)
                {
                    string queryDetail = "SELECT * FROM  Order_Detail";
                    SqlCommand commandSpDetail = new SqlCommand(queryDetail, conn);
                    commandSpDetail.CommandText = "SpInsertOrderDetail";
                    commandSpDetail.CommandType = CommandType.StoredProcedure;
                    commandSpDetail.Parameters.AddWithValue("@OrderIDDetail", orderDetail.OrderID);
                    commandSpDetail.Parameters.AddWithValue("@OrderDateDetail", orderDetail.OrderDate);
                    commandSpDetail.Parameters.AddWithValue("@NoDetail", orderDetail.No);
                    commandSpDetail.Parameters.AddWithValue("@ProductIDDetail", orderDetail.ProductID);
                    commandSpDetail.Parameters.AddWithValue("@ProductNameDetail", orderDetail.ProductName);
                    commandSpDetail.Parameters.AddWithValue("@PriceDetail", orderDetail.Price);
                    commandSpDetail.Parameters.AddWithValue("@DiscountDetail", orderDetail.Discount);
                    commandSpDetail.Parameters.AddWithValue("@QuantityMainDetail", orderDetail.QuantityMain);
                    commandSpDetail.Parameters.AddWithValue("@UnitMainDetail", orderDetail.UnitMain);
                    commandSpDetail.Parameters.AddWithValue("@UnitMainNameDetail", orderDetail.UnitMainName);
                    commandSpDetail.Parameters.AddWithValue("@QuantityMinorDetail", orderDetail.QuantityMinor);
                    commandSpDetail.Parameters.AddWithValue("@UnitMinorDetail", orderDetail.UnitMinor);
                    commandSpDetail.Parameters.AddWithValue("@UnitMinorNameDetail", orderDetail.UnitMinorName);
                    commandSpDetail.Parameters.AddWithValue("@TotalDetail", orderDetail.Total);
                    commandSpDetail.Parameters.AddWithValue("@Unit2RateDetail", orderDetail.Unit2Rate);
                    commandSpDetail.Parameters.AddWithValue("@QuantityMinor3Detail", orderDetail.QuantityMinor3);
                    commandSpDetail.Parameters.AddWithValue("@UnitMinor3Detail", orderDetail.UnitMinor3);
                    commandSpDetail.Parameters.AddWithValue("@UnitMinorName3Detail", orderDetail.UnitMinorName3);
                    commandSpDetail.Parameters.AddWithValue("@Discount_RateDetail", orderDetail.Discount_Rate);
                    commandSpDetail.Parameters.AddWithValue("@Unit3RateDetail", orderDetail.Unit3Rate);
                    commandSpDetail.Parameters.AddWithValue("@VATDetail", orderDetail.VAT);
                    commandSpDetail.Parameters.AddWithValue("@TaxTypeDetail", orderDetail.TaxType);
                    commandSpDetail.Parameters.AddWithValue("@OrderTypeDetail", orderDetail.OrderType);
                    commandSpDetail.Parameters.AddWithValue("@TotalQuantityDetail", orderDetail.TotalQuantity);
                    commandSpDetail.Parameters.AddWithValue("@SaleUnitDetail", orderDetail.SaleUnit);
                    commandSpDetail.Parameters.AddWithValue("@TotalExvatDetail", orderDetail.TotalExvat);
                    commandSpDetail.Parameters.AddWithValue("@TotalInvatDetail", orderDetail.TotalInvat);
                    commandSpDetail.Parameters.AddWithValue("@DiscountExvatDetail", orderDetail.DiscountExvat);
                    commandSpDetail.Parameters.AddWithValue("@DiscountInvatDetail", orderDetail.DiscountInvat);
                    commandSpDetail.Parameters.AddWithValue("@LotNumber", orderDetail.LotNumber);
                    result = commandSpDetail.ExecuteNonQuery();
                }
            }
            conn.Close();
            return Ok(new
            {
                Results = orderLists,
                StatusCode = result > 0 ? StatusCode(201) : StatusCode(400),
            });
        }
        [HttpPost("PostSalesToolsToSAP")]
        [Produces("application/json")]
        public async Task<IActionResult> PostSalesToolsToSAP(ParamsSapToSalesTools ParamsOrder)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            bool result = Int64.TryParse(ParamsOrder.OrderID, out long number);
            Console.WriteLine(result);
            if (!result)
            {
                return Ok(new
                {
                    StatusCode = StatusCode(404),
                });
            } 
            string queryDetail = "SELECT Remark, PODDate, PODTime FROM  Order_List WHERE OrderID = '"+ Int64.Parse(ParamsOrder.OrderID) + "' "; 
            Console.WriteLine(queryDetail);
            SqlCommand commandSp = new SqlCommand(queryDetail, conn);
            DataToSAP[] allRecords = null;
            var list = new List<DataToSAP>();
            SqlDataReader reader = commandSp.ExecuteReader();
            Console.WriteLine(reader);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(new DataToSAP { Remark = reader.GetString(0),
                         PODDate = reader.GetString(1),
                         PODTime = reader.GetString(2)
                    });
                    allRecords = list.ToArray();
                }
            }
            conn.Close();
            var resultTotal = "";
            resultTotal = list.Count().ToString();
            return Ok(new
            {
                Results = resultTotal == "0" ? [] :  allRecords,
                StatusCode = resultTotal == "0" ?  StatusCode(404) : StatusCode(200),
                resultTotals = resultTotal
            });
        }
    }
}
