
using Microsoft.AspNetCore.Mvc;
using SalesStatistics.Models.Services;

namespace SalesStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : Controller
    {
        public ReceiptsService _receiptsService;

        public ReceiptsController(ReceiptsService receiptsService)
        {
            _receiptsService = receiptsService;
        }

        [HttpGet("receipt-by-number/{transactionNr}")]

        public Receipt GetReceipt(string transactionNr)
        {
            var receivedReceipt = _receiptsService.GetReceipt(transactionNr);
            return receivedReceipt;
        }

    }

}
