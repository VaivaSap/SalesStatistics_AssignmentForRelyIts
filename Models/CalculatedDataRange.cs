using Microsoft.AspNetCore.Mvc;

namespace SalesStatistics.Models

{
    public class CalculatedDataRange
    {
        public int TotalItems { get; set; }

        public decimal TotalAmount { get; set; }

        public int TotalReceipts { get; set; }
    }
}
