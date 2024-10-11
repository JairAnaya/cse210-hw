using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("Asus TUF Gaming", "2024N11", 986, 1);
        Product product2 = new Product("Mouse", "2023J05", 27, 2);

        Address address1 = new Address("123 Main St", "Salt Lake City", "UT", "USA");
        Customer customer1 = new Customer("Steve Harkness", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine("Order 1 Details:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.GetTotalPrice():0.00}\n");

        Product product3 = new Product("iPhone 16 Pro Max", "2024O18", 1250, 1);
        Product product4 = new Product("Air buds 3 pro", "2023M06", 156, 2);

        Address address2 = new Address("706 Constitucion St", "Gomez Palacio", "DGO", "Mexico");
        Customer customer2 = new Customer("Jair Anaya", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine("Order 2 Details:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.GetTotalPrice():0.00}");
    }
}