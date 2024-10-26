using System;
using System.Collections.Generic;
using System.Linq;

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_state}\n{_country}";
    }
}

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    public string Name => _name;
    public Address Address => _address;
}

public class Product
{
    private string _name;
    private int _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, int productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal TotalCost()
    {
        return _price * _quantity;
    }

    public string Name => _name;
    public int ProductId => _productId;
    public int Quantity => _quantity;
}

public class Gift
{
    private bool _isGift;
    private string _note;
    private bool _hideDetails;

    public Gift(bool isGift, string note = "", bool hideDetails = false)
    {
        _isGift = isGift;
        _note = note;
        _hideDetails = hideDetails;
    }

    public bool IsGift => _isGift;
    public string Note => _note;
    public bool HideDetails => _hideDetails;
}

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const decimal _usaShippingCost = 5.00m;
    private const decimal _internationalShippingCost = 35.00m;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalProductCost = _products.Sum(p => p.TotalCost());
        decimal shippingCost = _customer.LivesInUSA() ? _usaShippingCost : _internationalShippingCost;
        return totalProductCost + shippingCost;
    }

    public string GetPackingLabel(Gift gift = null)
    {
        var label = "Packing Label:\n";
        foreach (var product in _products)
        {
            if (gift == null || !gift.HideDetails)
            {
                label += $"{product.Name} (ID: {product.ProductId}) - Quantity: {product.Quantity}\n";
            }
            else
            {
                label += $"{product.Name} - Quantity: {product.Quantity}\n";
            }
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Sample Data for Customer
        string customerName = "John Doe";
        Address address = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer = new Customer(customerName, address);

        Order order1 = new Order(customer);
        Order order2 = new Order(customer); // Create a second order for demonstration

        // Sample Products
        AddSampleProductsToOrder(order1);
        AddSampleProductsToOrder(order2);

        // Sample Gift Processing
        ProcessGift(order1, true, "Happy Birthday!", false);
        ProcessGift(order2, false);

        // Display Order Details
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void AddSampleProductsToOrder(Order order)
    {
        // Sample Product Data
        order.AddProduct(new Product("Laptop", 101, 999.99m, 1));
        order.AddProduct(new Product("Mouse", 102, 49.99m, 2));
    }

    static void ProcessGift(Order order, bool isGift, string giftNote = "", bool hideDetails = false)
    {
        Gift gift = null;

        if (isGift)
        {
            gift = new Gift(true, giftNote, hideDetails);
        }

        Console.WriteLine($"\nTotal Cost for Order: ${order.CalculateTotalCost()}");
        Console.WriteLine("\n" + order.GetPackingLabel(gift));
        Console.WriteLine(order.GetShippingLabel());
    }

    static void DisplayOrderDetails(Order order)
    {
        decimal totalCost = order.CalculateTotalCost();
        Console.WriteLine($"\nTotal Cost for Order: ${totalCost}");
        Console.WriteLine("\n" + order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
    }
}