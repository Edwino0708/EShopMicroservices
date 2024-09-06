
namespace Basket.API.Basket.GetBasket;

//public record GetBasquestRequest(string UserName);

public record GetBasquestResponse(ShoppingCart Cart);

public class GetBasketEnpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) => 
        {
            var result = await sender.Send(new GetBasketQuery(userName));
            var response = result.Adapt<GetBasquestResponse>();
            return Results.Ok(response);
        })
            .WithName("GetBasket")
            .Produces<GetBasquestResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Basket")
            .WithDescription("Get Basket");
    }
}
