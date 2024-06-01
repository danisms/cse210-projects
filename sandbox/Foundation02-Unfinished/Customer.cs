public class Customer
{
    private string _name;
    private Address _address;

    // Constructors
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public Address GetAddress()
    {
        return _address;
    }
    // methods
    public bool LeaveInHome()
    {
        return _address.InHome();
    }

    public void DisplayCustomerInfo()
    {
        string info = $"Name: {_name}\nAddress: {_address.GetAddress()}";
        // display info
        Console.WriteLine(info);
    }
}