using AutoMapper;
using Discount.Grpc.Repository;
using Discounts.Grpc.Protos;
using Grpc.Core;

namespace Discounts.Grpc.Services
{
    public class DiscountsService: DiscountsProtoService.DiscountsProtoServiceBase
    {
        ICouponRepository _couponRepository;
        ILogger<DiscountsService> _logger;
        IMapper _mapper;
        public DiscountsService(ICouponRepository couponRepository, ILogger<DiscountsService> logger, IMapper mapper) {
            _couponRepository = couponRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<CouponRequest> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _couponRepository.GetDiscount(request.ProductId);
            if (coupon == null) 
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Discount not found."));

            }
            _logger.LogInformation("Discount is retrived for ProductName : {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);

           // return new CouponRequest { ProductId = coupon.ProductId, ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount};
            return _mapper.Map<CouponRequest>(coupon);
        }
    }
}
