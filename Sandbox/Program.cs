Product apple = new("apple", 1.10m, 15);
Product banana = new("banana", 0.85m, 20);
Product bread = new("bread", 2.50m, 10);

Cart cart = new(5);

cart.AddToCart(apple);
cart.AddToCart(banana);
cart.AddToCart(bread);
cart.AddToCart(bread);

cart.DisplayCart();

Console.WriteLine($"Your total price at checkout is {CheckoutHelper.CalculateTotal(cart.GetItems(), cart.GetCount())}");


public class Cart
{
    private Product[] _items;
    private int _count;
    public Cart(int maxItems)
    {
        _items = new Product[maxItems];
        _count = 0;
    }
    
    public void AddToCart(Product product)
    {
        if (_count < _items.Length)
        {
            _items[_count] = product;
            _count++;
            product.QuantityInStock--;
        }
        else
        {
            Console.WriteLine("Your shopping cart is full!");
        }
    }
    public void DisplayCart()
    {
        for (int i = 0;  i < _count; i++)
        {
            Console.WriteLine($"{_items[i].Name} | ${_items[i].Price}    | {_items[i].QuantityInStock}");
        }
    }

    public Product[] GetItems()
    {
        return _items;
    }

    public int GetCount()
    {
        return _count;
    }
}

public class Product
{
    public string Name;
    public decimal Price;
    public int QuantityInStock;

    public Product(string name, decimal price, int quantityInStock)
    {
        Name = name;
        Price = price;
        QuantityInStock = quantityInStock;
    }
}

public static class CheckoutHelper
{
    public static decimal CalculateTotal(Product[] items, int count)
    {
        decimal totalCost = 0m;
        for (int i = 0; i < count; i++)
        {
            totalCost += items[i].Price;
        }
        return totalCost;
    }
}