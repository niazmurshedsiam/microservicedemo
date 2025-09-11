using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData();
            new Order
            {
                Id = 1,
                UserName = "Test",
                FirstName = "Test",
                LastName = "Test",
                EmailAddress = "test@gmail.com",
                Address = "Test",
                TotalPrice = 170,
                City = "Dhaka"
            };
        }
    }
}
