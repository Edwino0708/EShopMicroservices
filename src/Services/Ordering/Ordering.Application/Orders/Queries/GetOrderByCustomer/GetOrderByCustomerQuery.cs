namespace Ordering.Application.Orders.Queries;

public record GetOrderByCustomerQuery(Guid CustomerId)
    : IQuery<GetOrdersByCustomerResult>;

public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);
