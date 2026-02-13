namespace Hypesoft.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public Guid CategoryId { get; private set; }
    public int StockQuantity { get; private set; }

    private Product() { }

    public Product(string name, string description, decimal price, Guid categoryId, int stockQuantity)
    {
        Id = Guid.NewGuid();
        UpdateDetails(name, description, price, categoryId);
        SetStock(stockQuantity);
    }

    public void UpdateDetails(string name, string description, decimal price, Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Product description cannot be empty.");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        if (categoryId == Guid.Empty)
            throw new ArgumentException("CategoryId is required.");

        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }

    public void IncreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Increase quantity must be greater than zero.");

        StockQuantity += quantity;
    }

    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Decrease quantity must be greater than zero.");

        if (StockQuantity - quantity < 0)
            throw new InvalidOperationException("Insufficient stock.");

        StockQuantity -= quantity;
    }

    public void SetStock(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("Stock cannot be negative.");

        StockQuantity = quantity;
    }

    public bool IsLowStock() => StockQuantity < 10;
}
