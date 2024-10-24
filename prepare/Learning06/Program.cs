using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square mySquare = new Square("red", 1.5);
        shapes.Add(mySquare);
        Console.WriteLine(mySquare.GetColor());
        Console.WriteLine(mySquare.GetArea());

        Rectangle myRectangle = new Rectangle("blue", 2, 1);
        shapes.Add(myRectangle);
        Console.WriteLine(myRectangle.GetColor());
        Console.WriteLine(myRectangle.GetArea());

        Circle myCircle = new Circle("black", 2.3);
        shapes.Add(myCircle);
        Console.WriteLine(myCircle.GetColor());
        Console.WriteLine(myCircle.GetArea());

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}