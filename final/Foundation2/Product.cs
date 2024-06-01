public class Product
{
    private string _name;
    private int _productId;
    private double _price;
    private int _quantity;

    // Constructor
    public Product(string name, int productId, double price)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = 1;
    }

    // Methods
    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
    }

    public double CalculateCost()
    {
        double totalCost;

        // calculate total cost (price * quantity)
        totalCost = _price * _quantity;

        return totalCost;
    }

    public void DisplayProductInfo()
    {
        string info = $"{_name,-32}{_productId,-10}${_price, -10}{_quantity, -8}${CalculateCost(), -13}";
        // display info
        Console.WriteLine(info);
    }
}