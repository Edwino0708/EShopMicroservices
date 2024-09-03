﻿namespace Catalog.API.Products.GetProductById;

public record GetProductByIdReponse(Product Product);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = sender.Send(new GetProductByIdQuery(id));
            var response = result.Adapt<GetProductByIdReponse>();

            return Results.Ok(response);
        })
            .WithName("GetProductBy")
            .Produces<GetProductByIdReponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By Id");
    }
}
