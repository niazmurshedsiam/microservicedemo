﻿using MongoRepo.Context;

namespace Catalog.Api.Context
{
    public class CatalogDbContext : ApplicationDbContext
    {
        static IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();
        static string connectionString = configuration.GetConnectionString("Catalog.API");
        static string databaseName = configuration.GetValue<string>("DatabaseName");
        //static string connectionString = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true,true).Build().GetConnectionString("Catalog.API");
        public CatalogDbContext() : base(connectionString, databaseName)
        {
        }
    }
}
