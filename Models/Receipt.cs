using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesStatistics
{
    public class Receipt
    {
        [BindProperty]
        [Key]
        public string TransactionNr { get; set; }

        [BindProperty]
        public int StoreID { get; set; }

        [BindProperty]
        public DateTime Date { get; set; }

        [BindProperty]
        public int Items { get; set; }

        [BindProperty]
        public decimal Amount { get; set; }

    }
}


