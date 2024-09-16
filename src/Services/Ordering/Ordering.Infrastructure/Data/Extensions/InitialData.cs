namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
    new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("f1b227d4-8c55-4aeb-9f9a-3e7f62e3b45e")), "mehmet", "mehmet@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("d3c5e6f8-6a76-4a2b-8d8a-7b5d4c8e6f09")), "john", "john@gmail.com")
    };

    public static IEnumerable<Product> Products =>
    new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("e8c1a6ab-0a94-4b84-b8d6-51c3b2a3d229")), "laptop", 899.99m),
        Product.Create(ProductId.Of(new Guid("2f2d7d57-0f71-4a9e-a0c0-5c670f1d781c")), "tablet", 399.99m),
        Product.Create(ProductId.Of(new Guid("b7b8a7d3-3a45-4a44-89b8-1d5d8b15a7e0")), "mouse", 29.99m),
        Product.Create(ProductId.Of(new Guid("5d3e3b59-7f3b-4f92-bc57-6d0c2bb9879a")), "keyboard", 49.99m)
    };

    public static IEnumerable<Order> OrdersWithItems 
    {
        get 
        {
            // Identificadores de clientes y productos
            string customerId1 = "f1b227d4-8c55-4aeb-9f9a-3e7f62e3b45e";
            string customerId2 = "d3c5e6f8-6a76-4a2b-8d8a-7b5d4c8e6f09";

            string productId1 = "e8c1a6ab-0a94-4b84-b8d6-51c3b2a3d229";
            string productId2 = "2f2d7d57-0f71-4a9e-a0c0-5c670f1d781c";

            // Crear direcciones
            var shippingAddress = Address.Of("mehmet","ozkaya", "mehmet@gmail.com", "123 Main St", "Springfield", "IL", "62701");
            var billingAddress = Address.Of("john", "doe", "john@gmail.com", "123 Main St", "Springfield", "IL", "62701");

            // Crear métodos de pago
            var payment1 = Payment.Of("mehmet", "5555555555444444", "12/28","355", 1);
            var payment2 = Payment.Of("john", "888888888555554444", "06/30" , "222", 2);

            // Crear órdenes
            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid(customerId1)),
                OrderName.Of("ORD_1"),
                shippingAddress,
                billingAddress,
                payment1
            );
            order1.Add(ProductId.Of(new Guid(productId1)), 1, 899.99m); // Agrega un producto

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid(customerId1)),
                OrderName.Of("ORD_2"),
                shippingAddress,
                billingAddress,
                payment2
            );
            order2.Add(ProductId.Of(new Guid(productId2)), 1, 399.99m); // Agrega un producto

            // Devuelve la lista de órdenes
            return new List<Order> { order1, order2 };
        }
    }
}
