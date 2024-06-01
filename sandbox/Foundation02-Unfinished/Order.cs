public class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();
    private double _homeShippingCost;
    private double _nonHomeShippingCost;
    private double _shippingCost;

    // Constructors
    public Order(Customer customer, Product product)
    {
        _customer = customer;
        _products.Add(product);
        _homeShippingCost = 5;
        _nonHomeShippingCost = 35;
        GetShippingCost();  // cost determined based on customers address
    }
    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
        _homeShippingCost = 5;
        _nonHomeShippingCost = 35;
        GetShippingCost();  // cost determined based on customers address
    }

    // Methods
    public void SetHomeShippingCost(double price)
    {
        _homeShippingCost = price;
    }

    public void SetNonHomeShippingCost(double price)
    {
        _nonHomeShippingCost = price;
    }

    public double GetShippingCost()
    {
        double _shippingCost = _nonHomeShippingCost;

        if (_customer.LeaveInHome())
        {
            _shippingCost = _homeShippingCost;
        }

        return _shippingCost;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;
        // calculate total cost (The sum of the total cost of each product, plus
        // a one time shipping cost-[usa = 5$, non-usa = 35$; as the default value])

        // get total cost
        foreach (Product product in _products)
        {
            totalCost += product.CalculateCost();
        }

        // add shipping cost
        totalCost += GetShippingCost();

        return totalCost;
    }

    public void DisplayPackingLabel()
    {
        string labelHeader = $"{"SN",-3}|{"Product-Name",-32}{"ID",-10}{"Price",-10}{"Qty",-9}{"Cost",-13}";
        Console.WriteLine("\n-----------------------------------------------------------------------");
        Console.WriteLine(labelHeader);
        Console.WriteLine("-----------------------------------------------------------------------");
        // display product info with a count
        int sn = 1;
        foreach (Product product in _products)
        {
            Console.Write($"{sn + ".",-3}|");
            product.DisplayProductInfo();
            Console.WriteLine();  // for spacing purpose;
            // increment sn
            sn++;
        }
    }

    public void DisplayShippingLabel()
    {
        _customer.DisplayCustomerInfo();
    }

    public void displayShippingCost()
    {
        if (_customer.LeaveInHome())
        {
            Console.WriteLine($"Shipping Cost: ${GetShippingCost()} ({_customer.GetAddress().GetHome()})");
        }
        else
        {
            Console.WriteLine($"Shipping Cost: ${GetShippingCost()} (Non-{_customer.GetAddress().GetHome().ToUpper()})");
        }
    }
}