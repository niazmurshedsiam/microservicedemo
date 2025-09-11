using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Infrastructure;
using Ordering.Application.Contacts.Persistence;
using Ordering.Application.Models;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        public IOrderRepository _repository;
        public IMapper _mapper;
        public IEmailService _emailService;
        public CreateOrderHandler(IOrderRepository repository, IMapper mapper, IEmailService emailService) 
        {
            _repository = repository;
            _mapper = mapper;
            _emailService = emailService;
        }
        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            bool isOrderPlaced =  await _repository.AddAsync(order);
            if (isOrderPlaced) {
                EmailMessage email = new EmailMessage();
                email.Subject = "Your Order has been placed";
                email.To = order.UserName;
                email.Body = $"Dear {order.FirstName + " " + order.LastName} <br/><br/> We are excited for you to reacived your order #{order.Id} and with notify you one it's way. <br/>";
                await _emailService.SendEmailAsync(email);
            }
            return isOrderPlaced;
        }
    }
}
