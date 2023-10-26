using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class Figure
{
    public abstract double GetArea();

    public override string ToString()
    {
        return "Площадь фигуры";
    }
}

class Rectangle : Figure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double GetArea()
    {
        return Width * Height;
    }

    public override string ToString()
    {
        return $"Площадь фигуры прямоугольника с параметрами (ширина: {Width}, высота: {Height}) равна {GetArea()}";
    }
}

class Triangle : Figure
{
    public double Base { get; set; }
    public double Height { get; set; }

    public override double GetArea()
    {
        return 0.5 * Base * Height;
    }

    public override string ToString()
    {
        return $"Площадь фигуры треугольника с параметрами (основание: {Base}, высота: {Height}) равна {GetArea()}";
    }
}

class Circle : Figure
{
    public double Radius { get; set; }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override string ToString()
    {
        return $"Площадь фигуры круга с радиусом {Radius} равна {GetArea()}";
    }

    static void Main()
    {
        Rectangle rectangle1 = new Rectangle { Width = 4, Height = 6 };
        Rectangle rectangle2 = new Rectangle { Width = 3, Height = 5 };

        Triangle triangle1 = new Triangle { Base = 5, Height = 8 };
        Triangle triangle2 = new Triangle { Base = 4, Height = 7 };

        Circle circle1 = new Circle { Radius = 3 };
        Circle circle2 = new Circle { Radius = 2 };

        Console.WriteLine(rectangle1.ToString());
        Console.WriteLine(rectangle2.ToString());
        Console.WriteLine(triangle1.ToString());
        Console.WriteLine(triangle2.ToString());
        Console.WriteLine(circle1.ToString());
        Console.WriteLine(circle2.ToString());

        // Проверка хэш-кодов и сравнение объектов
        Console.WriteLine("Хэш-код прямоугольника 1: " + rectangle1.GetHashCode());
        Console.WriteLine("Хэш-код прямоугольника 2: " + rectangle2.GetHashCode());

        if (rectangle1.Equals(rectangle2))
        {
            Console.WriteLine("Объекты прямоугольников равны");
        }
        else
        {
            Console.WriteLine("Объекты прямоугольников не равны");
        }
    }
}
