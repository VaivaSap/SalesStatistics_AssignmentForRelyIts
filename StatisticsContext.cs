using Microsoft.EntityFrameworkCore;
using SalesStatistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStatistics
{
    public class StatisticsContext : DbContext
    {
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<SummaryOfTheDay> SummaryOfTheDay { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=SalesStatisticsDb; Trusted_Connection=True");
        }


    }

}
