using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Features.Orders.Commands.CreateOrder;

namespace Ordering.API.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        IMediator _meadiator; 
        ILogger<BasketCheckoutConsumer> _logger;
        IMapper _mapper;

        public  BasketCheckoutConsumer(IMediator meadiator,
        ILogger<BasketCheckoutConsumer> logger,
        IMapper mapper)
        {
            _meadiator = meadiator;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var orderData = _mapper.Map<CreateOrderCommand>(context.Message);
            bool isOrderConfirmed = await _meadiator.Send(orderData);
            if (isOrderConfirmed) 
            {
                _logger.LogInformation($"Basket Checkout Event has been consumed. Create order id: {orderData.UserName}");
            }
            else
            {
                _logger.LogInformation($"Basket checkout event failed for {orderData.UserName}");
            }
        }
    }
}
