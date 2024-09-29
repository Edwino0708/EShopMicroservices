namespace Shopping.Web.Pages;

public class CheckoutModel (IBasketService basketService, ILogger<CheckoutModel> logger)
    : PageModel
{

    [BindProperty]
    public BasketCheckoutModel Order { get; set; } = default!;

    public ShoppingCartModel Cart { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync() 
    {
        Cart = await basketService.LoadUserBasket();
        return Page();
    }

    public async Task<IActionResult> OnPostCheckOutAsync() 
    {
        logger.LogInformation("Checkout button clicked");
        Cart = await basketService.LoadUserBasket();

        if (!ModelState.IsValid) 
        {
            return Page();
        }

        Order.CustomerId = new Guid("f1b227d4-8c55-4aeb-9f9a-3e7f62e3b45e");
        Order.UserName = Cart.UserName;
        Order.TotalPrice = Cart.TotalPrice;

        await basketService.CheckoutBasket(new CheckoutBasketRequest(Order));

        return RedirectToPage("Confirmation", "OrderSubmitted");
    }
}
