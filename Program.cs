using Microsoft.EntityFrameworkCore;
using SalesStatistics;
using SalesStatistics.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddXmlDataContractSerializerFormatter();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(new ReceiptsService(new StatisticsContext()));
builder.Services.AddSingleton(new SummaryOfTheDayService(new StatisticsContext()));



var relevantDay = new DateTime(2019, 7, 22);

using (var context = new StatisticsContext())
{

    var summarizedInfo = new MechanicsSummarizedInfo(context);
    summarizedInfo.SummarizeInfo(relevantDay);

    if (!context.Receipt.Any())
    {
        var deserialization = new Deserialization();

        for (int i = 1; i <= 5; i++)
        {
            var receiptFromXml = deserialization.DeserializeToObject<POSLogDomainSpecific>($"C:/Users/vaiva/Downloads/receipts/arts{i}.xml");

            var objectItem = receiptFromXml.Transaction[0].RetailTransaction[0].LineItem[0].Item;

            var nameOfProperty = "Quantity";
            var propertyInfo = objectItem.GetType().GetProperty(nameOfProperty);
            var value = (Array)propertyInfo.GetValue(objectItem, null);
            var itemsCount = value.GetValue(0).GetType().GetProperty("Value").GetValue(value.GetValue(0), null);

            var receipt = new Receipt
            {
                TransactionNr = receiptFromXml.Transaction[0].SequenceNumber.ToString(),
                StoreID = Int32.Parse(receiptFromXml.Transaction[0].BusinessUnit[0].UnitID.Value),
                Date = receiptFromXml.Transaction[0].EndDateTime[0].Value,
                Items = (int)(decimal)itemsCount,
                Amount = (decimal)receiptFromXml.Transaction[0].RetailTransaction[0].Total[0].Value,


            };

            context.Receipt.Add(receipt);

        }
        context.SaveChanges();

    }

}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
