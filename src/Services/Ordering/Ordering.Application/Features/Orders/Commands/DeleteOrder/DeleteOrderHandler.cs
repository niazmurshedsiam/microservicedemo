using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistence;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        public IOrderRepository _repository;
        public IMapper _mapper;
        public DeleteOrderHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
           
            return await _repository.DeleteAsync(new Order() { Id = request.Id});
        }
    }
}
