using System;
using System.Collections.Generic;
using System.Linq;

public class Address
{
    public string StreetAddress { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public Address(string streetAddress, string city, string state, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{StreetAddress}\n{City}, {State}\n{Country}";
    }
}

public class Customer
{
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool LivesInUSA()
    {
        return Address.IsInUSA();
    }
}

public class Product
{
    public string Name { get; private set; }
    public int ProductId { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public Product(string name, int productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public decimal TotalCost()
    {
        return Price * Quantity;
    }
}

public class Gift
{
    public bool IsGift { get; private set; }
    public string Note { get; private set; }
    public bool HideDetails { get; private set; }

    public Gift(bool isGift, string note = "", bool hideDetails = false)
    {
        IsGift = isGift;
        Note = note;
        HideDetails = hideDetails;
    }
}

public class Order
{
    private List<Product> products;
    public Customer Customer { get; private set; }
    private const decimal USA_Shipping_Cost = 5.00m;
    private const decimal International_Shipping_Cost = 35.00m;

    public Order(Customer customer)
    {
        products = new List<Product>();
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalProductCost = products.Sum(p => p.TotalCost());
        decimal shippingCost = Customer.LivesInUSA() ? USA_Shipping_Cost : International_Shipping_Cost;
        return totalProductCost + shippingCost;
    }

    public string GetPackingLabel(Gift gift = null)
    {
        var label = "Packing Label:\n";
        foreach (var product in products)
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
        return $"Shipping Label:\n{Customer.Name}\n{Customer.Address.GetFullAddress()}";
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
        
        Order order = new Order(customer);
        
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

        decimal totalCost = order.CalculateTotalCost();
        Console.WriteLine($"\nTotal Cost: ${totalCost}");

        Console.WriteLine("\n" + order.GetPackingLabel(gift));
        Console.WriteLine(order.GetShippingLabel());
    }
}