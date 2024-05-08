public class Fraction
{
    private int _top;
    private int _bottom;

    // Creating Constructors
    public Fraction()  // no argument
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int numerator)  // one argument
    {
        _top = numerator;
        _bottom = 1;
    }
    public Fraction(int numerator, int denominator)  // two arguments
    {
        _top = numerator;
        _bottom = denominator;
    }


    //Creating getter(accessors) and setters(modulators) methods
    public int GetTop()  // get top property
    {
        return _top;
    }
    public void SetTop(int top)  // set value to the _top property
    {
        _top  = top;
    }

    public int GetBottom()  // get bottom property
    {
        return _bottom;
    }
    public void SetBottom(int bottom)  // set value to the _bottom property
    {
        _bottom = bottom;
    }

    // CREATING OTHER METHODS

    // get fraction in a string format of top/bottom
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // get fraction in a decimal form (double)
    public double GetDecimalValue()
    {
        return (double)_top/_bottom;
    }
} 