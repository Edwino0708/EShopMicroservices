using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
    {
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Laptop",
            Category = new List<string> { "Electronics", "Computers" },
            Description = "A high-performance laptop suitable for all your computing needs.",
            ImageFile = "laptop.jpg",
            Price = 1200.99m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Smartphone",
            Category = new List<string> { "Electronics", "Mobile" },
            Description = "A latest-generation smartphone with advanced features.",
            ImageFile = "smartphone.jpg",
            Price = 899.99m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Headphones",
            Category = new List<string> { "Electronics", "Audio" },
            Description = "Noise-cancelling over-ear headphones with superior sound quality.",
            ImageFile = "headphones.jpg",
            Price = 199.99m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Coffee Maker",
            Category = new List<string> { "Home Appliances", "Kitchen" },
            Description = "Automatic coffee maker with programmable features.",
            ImageFile = "coffeemaker.jpg",
            Price = 79.99m
        }
    };

}
