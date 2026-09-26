using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main St",
            "Provo",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Order order1 = new Order(customer1);

        Product laptop = new Product(
            "Laptop",
            "L001",
            1000,
            1
        );

        order1.AddProduct(laptop);
        
        Product mouse = new Product(
            "Mouse",
            "M002",
            25,
            2
        );

        order1.AddProduct(mouse);

        Address address2 = new Address(
             "45 Avenida Central",
             "Hermosillo",
             "Sonora",
             "Mexico"
        );

        Customer customer2 = new Customer(
             "Carlos Garcia",
            address2
        );

        Order order2 = new Order(customer2);
  
       Product shoes = new Product(
            "Shoes",
            "S001",
            80,
            2
        );

        order2.AddProduct(shoes);

        Product shirt = new Product(
            "Shirt",
            "SH001",
            30,
            3
        );

        order2.AddProduct(shirt);

        Console.WriteLine("ORDER 1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}");

        Console.WriteLine();
        Console.WriteLine("ORDER 2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }

}