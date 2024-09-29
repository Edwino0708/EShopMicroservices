namespace Shopping.Web.Models.Ordering;

public record OrderModel(
    Guid Id,
    Guid CustomerId,
    string OrderName,
    AddressModel ShippingAddress,
    AddressModel BillingAddress,
    PaymentModel Payment,
    OrdersStatus Status,
    List<OrderItemModel> OrderItems
);

public record OrderItemModel(Guid OrderId, Guid ProductId, int Quantity, decimal Price);

public record AddressModel(string FirstName, string LastName, string EmailAddress, string AddressLine, string Country, string State, string ZipCode);

public record PaymentModel(string CardName, string CardNumber, string Expiration, string Cvv, int PaymentMethod);

public enum OrdersStatus 
{
    Draft = 1,
    Pending = 2,
    Completed = 3,
    Cancelled = 4
}

public record GetOrdersReponse(PaginateResult<OrderModel> Orders);

public record GetOrdersByNameReponse(IEnumerable<OrderModel> Orders);

public record GetOrdersByCustomerReponse(IEnumerable<OrderModel> Orders);