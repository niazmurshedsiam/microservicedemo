using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands
{
    public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation()
        {
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Please Enter Your Name");
            RuleFor(c => c.EmailAddress).NotEmpty().EmailAddress().WithMessage("Email Address Should be Valid");
        }
    }
}
