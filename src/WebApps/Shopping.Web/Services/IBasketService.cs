namespace Shopping.Web.Services;

public interface IBasketService
{
    [Get("/basket-service/basket/{userName}")]
    Task<GetBasketReponse> GetBasket(string userName);

    [Post("/basket-service/basket")]
    Task<StoreBasketResponse> StoreBasket(StoreBasketRequest request);

    [Delete("/bascket-service/basket/{userName}")]
    Task<DeleteBasketReponse?> DeleteBasket(string userName);

    [Post("/basket-service/basket/checkout")]
    Task<CheckoutBasketReponse> CheckoutBasket(CheckoutBasketRequest request);
    
    public async Task<ShoppingCartModel> LoadUserBasket()
    {
        var userName = "swn";
        ShoppingCartModel basket;

        try
        {
            var getBasketReponse = await GetBasket(userName);
            basket = getBasketReponse.Cart;
        }
        catch (ApiException apiException) when (apiException.StatusCode == HttpStatusCode.NotFound)
        {
            basket = new ShoppingCartModel
            {
                UserName = userName,
                Items = []
            };
        }

        return basket;
    }

}
