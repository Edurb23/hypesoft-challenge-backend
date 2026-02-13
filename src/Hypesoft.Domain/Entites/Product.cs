namespace Hypesoft.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public Guid CategoryId { get; private set; }
    public int StockQuantity { get; private set; }

    private Product() { } // EF Constructor

    public Product(string name, string description, decimal price, Guid categoryId, int stockQuantity)
    {
        Id = Guid.NewGuid();
        SetName(name);
        SetDescription(description);
        SetPrice(price);
        SetStock(stockQuantity);
        CategoryId = categoryId;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty.");

        Name = name;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Product description cannot be empty.");

        Description = description;
    }

    public void SetPrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        Price = price;
    }

    public void SetStock(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("Stock cannot be negative.");

        StockQuantity = quantity;
    }

    public bool IsLowStock() => StockQuantity < 10;
}
