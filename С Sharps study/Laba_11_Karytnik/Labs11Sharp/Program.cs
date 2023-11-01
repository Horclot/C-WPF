using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IShape
{
    double GetVolume();
    double GetArea();
    bool Exists();
}

class Rectangle : IShape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public double GetVolume() => 0;
    public double GetArea() => Length * Width;
    public bool Exists() => Length > 0 && Width > 0;
}

class Triangle : IShape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public double GetVolume() => 0;
    public double GetArea()
    {
        double p = (A + B + C) / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    public bool Exists() => A > 0 && B > 0 && C > 0 && (A + B > C) && (A + C > B) && (B + C > A);
}

class Circle : IShape
{
    public double Radius { get; set; }

    public double GetVolume() => 0;
    public double GetArea() => Math.PI * Radius * Radius;
    public bool Exists() => Radius > 0;
}

class RectangularParallelepiped : IShape
{
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public double GetVolume() => Length * Width * Height;
    public double GetArea() => 2 * (Length * Width + Length * Height + Width * Height);
    public bool Exists() => Length > 0 && Width > 0 && Height > 0;
}

class Sphere : IShape
{
    public double Radius { get; set; }

    public double GetVolume() => (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
    public double GetArea() => 4 * Math.PI * Math.Pow(Radius, 2);
    public bool Exists() => Radius > 0;
}

class CircularCone : IShape
{
    public double Radius { get; set; }
    public double Height { get; set; }

    public double GetVolume() => (1.0 / 3.0) * Math.PI * Math.Pow(Radius, 2) * Height;
    public double GetArea()
    {
        double slantHeight = Math.Sqrt(Math.Pow(Radius, 2) + Math.Pow(Height, 2));
        return Math.PI * Radius * (Radius + slantHeight);
    }

    public bool Exists() => Radius > 0 && Height > 0;
}

class Program
{
    static void Main()
    {
        Random random = new Random();
        IShape[] shapes = new IShape[1000];

        for (int i = 0; i < shapes.Length; i++)
        {
            int shapeType = random.Next(6);
            switch (shapeType)
            {
                case 0:
                    shapes[i] = new Rectangle { Length = random.Next(1, 101), Width = random.Next(1, 101) };
                    break;
                case 1:
                    shapes[i] = new Triangle { A = random.Next(1, 101), B = random.Next(1, 101), C = random.Next(1, 101) };
                    break;
                case 2:
                    shapes[i] = new Circle { Radius = random.Next(1, 101) };
                    break;
                case 3:
                    shapes[i] = new RectangularParallelepiped { Length = random.Next(1, 101), Width = random.Next(1, 101), Height = random.Next(1, 101) };
                    break;
                case 4:
                    shapes[i] = new Sphere { Radius = random.Next(1, 101) };
                    break;
                case 5:
                    shapes[i] = new CircularCone { Radius = random.Next(1, 101), Height = random.Next(1, 101) };
                    break;
            }
        }

        var existingFlatShapes = shapes.Where(shape => shape is IShape && shape.GetVolume() == 0 && shape.Exists());
        var existingSolidShapes = shapes.Where(shape => shape is IShape && shape.GetVolume() > 0 && shape.Exists());

        double minFlatArea = existingFlatShapes.Min(shape => shape.GetArea());
        double maxFlatArea = existingFlatShapes.Max(shape => shape.GetArea());
        double minSolidArea = existingSolidShapes.Min(shape => shape.GetArea());
        double maxSolidArea = existingSolidShapes.Max(shape => shape.GetArea());
        double minVolume = existingSolidShapes.Min(shape => shape.GetVolume());
        double maxVolume = existingSolidShapes.Max(shape => shape.GetVolume());
        double avgFlatArea = existingFlatShapes.Average(shape => shape.GetArea());
        double avgSolidArea = existingSolidShapes.Average(shape => shape.GetArea());
        double avgVolume = existingSolidShapes.Average(shape => shape.GetVolume());
        double sumFlatArea = existingFlatShapes.Sum(shape => shape.GetArea());
        double sumSolidArea = existingSolidShapes.Sum(shape => shape.GetArea());
        double sumVolume = existingSolidShapes.Sum(shape => shape.GetVolume());

        Console.WriteLine("Минимальная площадь плоских фигур: " + minFlatArea);
        Console.WriteLine("Максимальная площадь плоских фигур: " + maxFlatArea);
        Console.WriteLine("Минимальная площадь поверхности объемных фигур: " + minSolidArea);
        Console.WriteLine("Максимальная площадь поверхности объемных фигур: " + maxSolidArea);
        Console.WriteLine("Минимальный объем объемных фигур: " + minVolume);
        Console.WriteLine("Максимальный объем объемных фигур: " + maxVolume);
        Console.WriteLine("Средняя площадь плоских фигур: " + avgFlatArea);
        Console.WriteLine("Средняя площадь поверхности объемных фигур: " + avgSolidArea);
        Console.WriteLine("Средний объем объемных фигур: " + avgVolume);
        Console.WriteLine("Суммарная площадь плоских фигур: " + sumFlatArea);
        Console.WriteLine("Суммарная площадь поверхности объемных фигур: " + sumSolidArea);
        Console.WriteLine("Суммарный объем объемных фигур: " + sumVolume);
    }
}
