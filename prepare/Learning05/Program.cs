using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello! Welcome To Learning05!");
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("red", 20));
        shapes.Add(new Rectangle("blue", 10, 15));
        shapes.Add(new Circle("yellow", 15));

        foreach (Shape shape in shapes)
        {
            // get color and area of the shape
            string color = shape.GetColor();
            double area = shape.GetArea();
            // display the result
            Console.WriteLine($"Shape Color: {color}; Shape Area: {area}");
        }
    }
}