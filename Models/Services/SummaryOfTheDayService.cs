namespace SalesStatistics.Models.Services
{
    public class SummaryOfTheDayService
    {
        private StatisticsContext _context;

        public SummaryOfTheDayService(StatisticsContext context)
        {
            _context = context;
        }



        public CalculatedDataRange GetCalculatedSalesData(DateTime startDate, DateTime endDate)
        {
            var listOfSummaries = _context.SummaryOfTheDay.Where(o => startDate <= o.Date && o.Date <= endDate).ToList();

            var calculatedItemsInRange = 0;
            decimal calculatedAmountsPaidInRange = 0;
            var calculatedReceiptsInRange = 0;

            foreach (var summary in listOfSummaries)
            {

                calculatedItemsInRange = calculatedItemsInRange + summary.TotalItems;
                calculatedAmountsPaidInRange = calculatedAmountsPaidInRange + summary.TotalAmount;
                calculatedReceiptsInRange = calculatedReceiptsInRange + summary.TotalReceipts;

            }

            var calculatedDataRange = new CalculatedDataRange
            {
                TotalItems = calculatedItemsInRange,
                TotalAmount = calculatedAmountsPaidInRange,
                TotalReceipts = calculatedReceiptsInRange,
            };

            return calculatedDataRange;

        }

    }
}






