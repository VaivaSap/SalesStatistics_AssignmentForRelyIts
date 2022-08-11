using SalesStatistics.Models;
using System.Transactions;

namespace SalesStatistics
{

    public class MechanicsSummarizedInfo
    {
        private readonly StatisticsContext _context;


        public MechanicsSummarizedInfo(StatisticsContext context)
        {

            _context = context;

        }

        public void SummarizeInfo(DateTime relevantDay)

        {
            //If the day is the same, the receipt is relevant, by using "GroupBy" the receipts are shuffled to different stores by their ID 
            var allReceiptsTogether = _context.Receipt.Where(o => o.Date.Date == relevantDay.Date).ToList().GroupBy(o => o.StoreID).ToList();



            foreach (var receiptGroup in allReceiptsTogether)
            {

                var sumItems = 0;
                decimal sumAmount = 0;

                foreach (var receipt in receiptGroup)
                {

                    sumItems = sumItems + receipt.Items;
                    sumAmount = sumAmount + receipt.Amount;

                }

                var summaryByStore = new SummaryOfTheDay
                {
                    SummaryId = Guid.NewGuid(),
                    StoreID = receiptGroup.Key,
                    Date = relevantDay,
                    TotalItems = sumItems,
                    TotalAmount = sumAmount,
                    TotalReceipts = receiptGroup.Count(),
                };

              
                    _context.SummaryOfTheDay.Add(summaryByStore);


                }

            _context.SaveChanges();

        }

    }

}



