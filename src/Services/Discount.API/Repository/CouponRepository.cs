using Dapper;
using Discount.API.Model;
using Npgsql;

namespace Discount.API.Repository
{
    public class CouponRepository : ICouponRepository
    {
        IConfiguration _configuration;
        public CouponRepository(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public Task<bool> CreateDiscount(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDiscount(string productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Coupon> GetDiscount(string productId)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("select 8 from coupon where ProductId = @ProductId", new { ProductId = productId });
            if (coupon == null) 
            {
                return new Coupon() { Amount = 0, ProductId = "No Discount" };
            }
            return coupon;
        }

        public Task<bool> UpdateDiscount(Coupon coupon)
        {
            throw new NotImplementedException();
        }
    }
}
