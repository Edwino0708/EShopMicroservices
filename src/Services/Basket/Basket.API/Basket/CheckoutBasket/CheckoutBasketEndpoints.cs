namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketRequest(BasketCheckoutDto CheckoutBasketDto);

public record CheckoutBasketReponse(bool IsSuccess);

public class CheckoutBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<CheckoutBasketCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CheckoutBasketReponse>();

            return Results.Ok(response);
        })
        .WithName("Checkout")
        .Produces<CheckoutBasketReponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Check Out")
        .WithDescription("Check Out"); ;
    }
}
