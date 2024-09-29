namespace Shopping.Web.Pages;

public class OrderListModel(IOrderingService orderingService, ILogger<OrderListModel> logger)
    : PageModel
{

    public IEnumerable<OrderModel> Orders { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        var customerId = new Guid("f1b227d4-8c55-4aeb-9f9a-3e7f62e3b45e");

        var response = await orderingService.GetOrdersByCustomer(customerId);
        Orders = response.Orders;

        return Page();
    }
}
