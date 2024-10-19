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
        Console.WriteLine("Enter your name:");
        string customerName = Console.ReadLine();

        Console.WriteLine("Enter your street address:");
        string streetAddress = Console.ReadLine();

        Console.WriteLine("Enter your city:");
        string city = Console.ReadLine();

        Console.WriteLine("Enter your state:");
        string state = Console.ReadLine();

        Console.WriteLine("Enter your country:");
        string country = Console.ReadLine();

        Address address = new Address(streetAddress, city, state, country);
        Customer customer = new Customer(customerName, address);

        Order order1 = new Order(customer);
        Order order2 = new Order(customer); // Create a second order for demonstration

        AddProductsToOrder(order1);
        AddProductsToOrder(order2);

        ProcessGift(order1);
        ProcessGift(order2);

        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void AddProductsToOrder(Order order)
    {
        Console.WriteLine("How many products would you like to add?");
        int productCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < productCount; i++)
        {
            Console.WriteLine($"Enter the name of product {i + 1}:");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter the product ID:");
            int productId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the price per unit:");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the quantity:");
            int quantity = int.Parse(Console.ReadLine());

            Product product = new Product(productName, productId, price, quantity);
            order.AddProduct(product);
        }
    }

    static void ProcessGift(Order order)
    {
        Console.WriteLine("Is this order a gift? (yes/no)");
        string isGiftResponse = Console.ReadLine().ToLower();
        Gift gift = null;

        if (isGiftResponse == "yes")
        {
            Console.WriteLine("Enter a gift note:");
            string giftNote = Console.ReadLine();
            Console.WriteLine("Hide product details on the package? (yes/no)");
            string hideDetailsResponse = Console.ReadLine().ToLower();
            bool hideDetails = hideDetailsResponse == "yes";
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