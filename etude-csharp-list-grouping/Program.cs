List<Product> products =
[
    new Product { Id = 1, Category = "Electronics", Brand = "BrandA", Price = 1000 },
    new Product { Id = 2, Category = "Electronics", Brand = "BrandB", Price = 1200 },
    new Product { Id = 3, Category = "Electronics", Brand = "BrandA", Price = 1500 },
    new Product { Id = 4, Category = "Furniture"  , Brand = "BrandC", Price = 800 },
    new Product { Id = 5, Category = "Furniture"  , Brand = "BrandC", Price = 950 },
];

var groupedProducts = products
    .GroupBy(p => new { p.Category, p.Brand })
    .Select(g => new
    {
        g.Key.Category,
        g.Key.Brand,
        Products = g.ToList(),
        TotalPrice = g.Sum(p => p.Price)
    });

foreach (var group in groupedProducts)
{
    Console.WriteLine($"Category: {group.Category}, Brand: {group.Brand}");
    Console.WriteLine("Products:");
    foreach (var product in group.Products)
    {
        Console.WriteLine($"  Id: {product.Id}, Price: {product.Price}");
    }
    Console.WriteLine($"Total Price: {group.TotalPrice}");
    Console.WriteLine();
}

public class Product
{
    public required int Id { get; init; }
    public required string Category { get; init; }
    public required string Brand { get; init; }
    public required decimal Price { get; init; }
}