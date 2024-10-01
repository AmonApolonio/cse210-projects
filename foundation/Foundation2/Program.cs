using System;

class Program
{
    static void Main(string[] args)
    {
        Customer customer1 = new Customer("Maria Oliveira", new Address("Avenida Paulista, 1578", "Campinas", "São Paulo", "Brazil"));
        Customer customer2 = new Customer("Jessica Martinez", new Address("303 Cedar Lane", "Austin", "Texas", "USA"));

        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);

        order1.AddProduct(new Product("Graphics Card", 110, 499.99, 20));
        order1.AddProduct(new Product("Monitor", 107, 299.99, 30));
        order1.AddProduct(new Product("Smartwatch", 104, 149.99, 75));

        Console.WriteLine("\n======== ORDER - 1 ========");
        Console.WriteLine("Packing Label");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label");
        Console.WriteLine(order1.GetShippingLabel());
        Console.Write($"\nTOTAL: {order1.CalculateTotalCost()}\n");

        order2.AddProduct(new Product("Laptop", 101, 999.99, 50));
        order2.AddProduct(new Product("Wireless Mouse", 105, 29.99, 300));

        Console.WriteLine("\n======== ORDER - 2 ========");
        Console.WriteLine("Packing Label");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label");
        Console.WriteLine(order2.GetShippingLabel());
        Console.Write($"\nTOTAL: {order2.CalculateTotalCost()}\n");
    }
}