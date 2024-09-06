namespace Discount.Grpc.Data;

public static class CouponSeed
{
    public static void SeedCoupons(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon
            {
                Id = 1,
                ProductName = "IPhone X",
                Description = "Get a discount on IPhone X",
                Amount = 50 // Puedes ajustar el valor del descuento
            },
            new Coupon
            {
                Id = 2,
                ProductName = "Samsung 10",
                Description = "Get a discount on Samsung 10",
                Amount = 75 // Puedes ajustar el valor del descuento
            }
        );
    }
}
