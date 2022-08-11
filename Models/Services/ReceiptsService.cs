namespace SalesStatistics.Models.Services
{
    public class ReceiptsService
    {
        private StatisticsContext _context;

        public ReceiptsService(StatisticsContext context)
        {
            _context = context;
        }

        public Receipt GetReceipt(string receiptId) => _context.Receipt.FirstOrDefault(o => o.TransactionNr == receiptId);

    }
}

