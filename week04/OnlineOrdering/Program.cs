using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // --------- 1st Order (USA Customer) ---------
        Address address1 = new Address("123 Main Street", "Salt Lake City", "UT", "USA");
        Customer customer1 = new Customer("Joseph Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-100", 19.99m, 2));
        order1.AddProduct(new Product("Keyboard", "KB-200", 39.50m, 1));

        // --------- 2nd Order (International Customer) ---------
        Address address2 = new Address("123 Main Street", "Cape Town", "Western Cape", "South Africa");
        Customer customer2 = new Customer("Anyway Kambeva", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Laptop Stand", "LS-300", 29.99m, 1));
        order2.AddProduct(new Product("USB-C", "HB-400", 24.99m, 3));

        // Put orders in a list
        List<Order> orders = new List<Order> { order1, order2 };

        // --------- Display each order ---------
        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Order #{orderNumber}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}");
            Console.WriteLine();
            orderNumber++;
        }

        Console.WriteLine("Done. Press Enter to exit.");
        Console.ReadLine();
    }
}
