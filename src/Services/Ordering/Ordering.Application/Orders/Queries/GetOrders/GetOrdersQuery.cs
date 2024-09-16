using BuildingBlock.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

public record GetOrdersQuery(PaginatedRequest PaginateRequest)
    :IQuery<GetOrdersResult>;

public record GetOrdersResult(PaginateResult<OrderDto> Orders);
