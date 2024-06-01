using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        // Change Console Figure Colors
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(">>>>>>>>Welcome to Danism Online Order<<<<<<<<");

        // store all individual customer order
        List<Order> allOrders = new List<Order>();


        // CREATE PRODUCT OBJECTS
        // iPhone
        Product iPhone15 = new Product("iPhone 15", 001, 799);
        Product iPhone15ProMax = new Product("iPhone 15 Pro Max", 004, 1199);
        // iPad
        Product iPadPro12inch = new Product("iPad Pro (12.9-inch)", 102, 1099);
        Product iPadAir = new Product("iPad Air", 105, 599);
        // MacBook
        Product macBookAir13 = new Product("MacBook Air (13-inch M2)", 201, 1099);
        Product macBookPro13 = new Product("MacBook Pro (13-inch M2)", 203, 1299);
        // Apple Watch
        Product appleWatchSeries9 = new Product("Apple Watch Series 9 (GPS)", 301, 399);
        Product appleWatchUltra2 = new Product("Apple Watch Ultra 2", 303, 799);
        // Home Products
        Product appleTv4k = new Product("Apple TV 4K", 501, 129);
        Product HomePodMini = new Product("HomePod mini", 502, 99);


        // CREATE ADDRESSES AND CUSTOMERS OBJECTS
        // customer 1
        Address danielAddr = new Address("2, Fanalou Off Country Home", "Benin", "Edo", "Nigeria");
        Customer danielOpute = new Customer("Daniel Opute", danielAddr);
        // customer 2
        Address gabrielAddr = new Address("Michigan Avenue", "Lansing", "Michigan", "USA");
        Customer gabrielOpute = new Customer("Gabriel Opute", gabrielAddr);
        // customer 3
        Address alexAddr = new Address("400 South", "Salt Lake", "Utah", "USA");
        Customer alexChristensen = new Customer("Alex Christensen", alexAddr);


        // CREATE CUSTOMER ORDERS OBJECTS
        // Daniel Order (Products)
        // product 1
        Product danielMacBookAir = macBookAir13;
        // set quantity
        danielMacBookAir.SetQuantity(3);
        // product 2
        Product danielAppleTv = appleTv4k;
        danielAppleTv.SetQuantity(2);
        // product 3
        Product danielAppleWatchUltra2 = appleWatchUltra2;
        danielAppleTv.SetQuantity(4);

        Order danielOrder = new Order(danielOpute, danielMacBookAir);
        danielOrder.AddProduct(danielAppleTv);
        danielOrder.AddProduct(danielAppleWatchUltra2);

        // add daniel order to all order list
        allOrders.Add(danielOrder);

        // Gabriel Opute Order (Products)
        // product 1
        Product gabrielMacBookPro = macBookPro13;
        // set quantity
        gabrielMacBookPro.SetQuantity(2);
        // product 2
        Product gabrielIphone15 = iPhone15;  // quantity is set to 1 by default
        // product 3
        Product gabrielIpadPro12 = iPadPro12inch;
        gabrielIpadPro12.SetQuantity(3);
        // product 4
        Product gabrielAppleWatchSeries9 = appleWatchSeries9;
        gabrielAppleWatchSeries9.SetQuantity(2);

        List<Product> gabrielProductsOrder = [
            gabrielMacBookPro,
            gabrielIphone15,
            gabrielIpadPro12,
            gabrielAppleWatchSeries9
        ];

        // Create Order Object
        Order gabrielOrder = new Order(gabrielOpute, gabrielProductsOrder);

        // add gabriel order to all order list
        allOrders.Add(gabrielOrder);

        // Alex Christensen Order (Products)
        // product 1
        Product alexIphone15ProMax = iPhone15ProMax;  // quantity set to be 1 by default
        // product 2
        Product alexIpadAir = iPadAir;
        alexIpadAir.SetQuantity(2);
        // product 2
        Product alexHomePodMini = HomePodMini;
        alexHomePodMini.SetQuantity(3);

        // Create Order Object
        Order alexOrder = new Order(alexChristensen, alexIphone15ProMax);
        alexOrder.AddProduct(alexIpadAir);
        alexOrder.AddProduct(alexHomePodMini);

        // add alex order to all order list
        allOrders.Add(alexOrder);


        // DISPLAY EACH INDIVIDUAL ORDER DETAILS
        Console.WriteLine("\n\t\tAll CUSTOMERS ORDER");
        int count = 1;
        foreach (Order order in allOrders)
        {
            // display packing label
            Console.Write($"\nPACKING LABEL ({count})");
            order.DisplayPackingLabel();
            // display shipping label
            order.DisplayShippingLabel();
            // display total Cost
            order.displayShippingCost();
            double totalCost = order.CalculateTotalCost();
            Console.WriteLine($"Total Cost: ${totalCost}");
            Console.WriteLine("_______________________________________________________________________");
            // increment count
            count++;
        }
    }
}