using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrderByUserName
{
    public class GetOrderByUserQuery:IRequest<List<OrderVm>>
    {
        public string UserName { get; set; }
        public GetOrderByUserQuery(string userName) 
        {
            UserName = userName;
        
        }
    }
}
