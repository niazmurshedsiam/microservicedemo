using CoreApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CreateOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrderByUserName;
using System.Net;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : BaseController
    {
        IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderVm>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult>GetOrderByUserName(string userName)
        {
            try
            {
                var order = await _mediator.Send(new GetOrderByUserQuery(userName));
                return CustomResult("Order load successfully.",order);
            }
            catch ( Exception ex)
            {
              return  CustomResult(ex.Message,HttpStatusCode.BadRequest);
                
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand createOrderCommand)
        {
            try
            {
                var isOrderPlaced = await _mediator.Send(createOrderCommand);
                if (isOrderPlaced)
                {
                    return CustomResult("Order has been Placed.");
                }
                else {
                    return CustomResult("Order Not Placed.",HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand updateOrderCommand)
        {
            try
            {
                var isOrderModify = await _mediator.Send(updateOrderCommand);
                if (isOrderModify)
                {
                    return CustomResult("Order has been Modify.");
                }
                else
                {
                    return CustomResult("Order Modify Fail.", HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var isOrderDelete = await _mediator.Send(new DeleteOrderCommand { Id = id});
                if (isOrderDelete)
                {
                    return CustomResult("Order has been Delete.");
                }
                else
                {
                    return CustomResult("Order Delete Fail.", HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }
        }
    }
}
