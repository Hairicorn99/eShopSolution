using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eShopSolution.Data.EF
{
    public class eShopDbContextFactory : IDesignTimeDbContextFactory<eShopDbContext>
    {
        public eShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connnectionString = configuration.GetConnectionString("eShopSolutionDb");

            var optionBuilder = new DbContextOptionsBuilder<eShopDbContext>();
            optionBuilder.UseSqlServer(connnectionString);

            return new eShopDbContext(optionBuilder.Options);
        }
    }
}
