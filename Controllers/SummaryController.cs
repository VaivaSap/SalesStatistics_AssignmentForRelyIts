using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesStatistics.Models;
using SalesStatistics.Models.Services;

namespace SalesStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase

    {
        public SummaryOfTheDayService _summaryOfTheDayService;

        public SummaryController(SummaryOfTheDayService summaryOfTheDayService)
        {
            _summaryOfTheDayService = summaryOfTheDayService;
        }

        [HttpGet("calculated-sales-data/{startDate}/{endDate}")]

        public CalculatedDataRange GetCalculatedSalesData(DateTime startDate, DateTime endDate)
        {
            var calculatedSalesOfOneDay = _summaryOfTheDayService.GetCalculatedSalesData(startDate, endDate);

            return calculatedSalesOfOneDay;
        }

    }

}