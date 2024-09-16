namespace Ordering.Application.Orders.Queries.GetOrders;

public class GetOrdersHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginateRequest.PageIndex;
        var pageSize = query.PaginateRequest.PageSize;

        var totalCount = await dbContext.OrderItems.LongCountAsync(cancellationToken);

        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new GetOrdersResult(
            new PaginateResult<OrderDto>(
                pageIndex,
                pageSize,
                totalCount,
                orders.ToOrderDtoList()
                )
            );
    }
}
