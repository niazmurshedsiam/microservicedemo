using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrderByUserName
{
    public class GetOrderByUserHandler : IRequestHandler<GetOrderByUserQuery, List<OrderVm>>
    {
        public IOrderRepository _orderRepository;
        public IMapper _mapper;
        public GetOrderByUserHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<List<OrderVm>> Handle(GetOrderByUserQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrderByUserName(request.UserName);
            return _mapper.Map<List<OrderVm>>(orders);
        }
    }
}
