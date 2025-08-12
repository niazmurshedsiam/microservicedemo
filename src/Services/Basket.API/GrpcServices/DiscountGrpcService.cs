using Discounts.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        public readonly DiscountsProtoService.DiscountsProtoServiceClient _discountService;

        public DiscountGrpcService(DiscountsProtoService.DiscountsProtoServiceClient discountService) 
        {
            _discountService = discountService;
        }

        public async Task<CouponRequest> GetDiscount(string productId)
        {
            var getDisCountData = new GetDiscountRequest() { ProductId = productId };
            return await _discountService.GetDiscountAsync(getDisCountData);
        }
    }
}
