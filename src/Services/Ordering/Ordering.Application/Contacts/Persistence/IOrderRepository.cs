using EF.Core.Repository.Interface.Repository;
using Ordering.Domain.Models;
using System;


namespace Ordering.Application.Contacts.Persistence
{
    public interface IOrderRepository:ICommonRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrderByUserName(string userName);
    }
}
