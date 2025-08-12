using AutoMapper;
using Discounts.Grpc.Model;
using Discounts.Grpc.Protos;

namespace Discounts.Grpc.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupon, CouponRequest>().ReverseMap();
        }
    }
}
