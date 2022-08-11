using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SalesStatistics.Models
{
    public class SummaryOfTheDay
    {
   
        [BindProperty]
        [Key]
        public Guid SummaryId { get; set; }

        [BindProperty]
        public DateTime Date { get; set; }

        [BindProperty]
        public int StoreID { get; set; }

        [BindProperty]
        public int TotalItems { get; set; }

        [BindProperty]
        public decimal TotalAmount { get; set; }


        [BindProperty]
        public int TotalReceipts { get; set; }
    }
}

