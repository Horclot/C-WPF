using System;

namespace GeometryFigures
{
    public enum FigureType
    {
        Sphere = 1,
        RectangularPrism,
        CircularCone
    }

    public class Figure
    {
        private FigureType figureType;
        public FigureType FigureType
        {
            get { return figureType; }
            set
            {
                if (!Enum.IsDefined(typeof(FigureType), value))
                {
                    throw new ArgumentException("Неверное значение для типа фигуры");
                }
                figureType = value;
            }
        }

        public string FigureName
        {
            get
            {
                switch (figureType)
                {
                    case FigureType.Sphere:
                        return "Шар";
                    case FigureType.RectangularPrism:
                        return "Прямоугольный параллелепипед";
                    case FigureType.CircularCone:
                        return "Прямой круговой конус";
                    default:
                        throw new InvalidOperationException("Неизвестный тип фигуры");
                }
            }
        }

        public double Radius { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public delegate void InputDataDelegate();
        public delegate double CalculateVolumeDelegate();

        public Figure(FigureType figureType)
        {
            FigureType = figureType;
        }

        public void InputData()
        {
            switch (figureType)
            {
                case FigureType.Sphere:
                    Console.WriteLine("Введите радиус шара:");
                    Radius = double.Parse(Console.ReadLine());
                    break;
                case FigureType.RectangularPrism:
                    Console.WriteLine("Введите длину прямоугольного параллелепипеда:");
                    Length = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите ширину прямоугольного параллелепипеда:");
                    Width = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите высоту прямоугольного параллелепипеда:");
                    Height = double.Parse(Console.ReadLine());
                    break;
                case FigureType.CircularCone:
                    Console.WriteLine("Введите радиус основания кругового конуса:");
                    Radius = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите высоту кругового конуса:");
                    Height = double.Parse(Console.ReadLine());
                    break;
                default:
                    throw new InvalidOperationException("Неизвестный тип фигуры");
            }
        }

        public double CalculateVolume()
        {
            switch (figureType)
            {
                case FigureType.Sphere:
                    return 4.0 / 3.0 * Math.PI * Math.Pow(Radius, 3);
                case FigureType.RectangularPrism:
                    return Length * Width * Height;
                case FigureType.CircularCone:
                    return 1.0 / 3.0 * Math.PI * Math.Pow(Radius, 2) * Height;
                default:
                    throw new InvalidOperationException("Неизвестный тип фигуры");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Figure sphere = new Figure(FigureType.Sphere);
                sphere.InputData();
                Console.WriteLine($"{sphere.FigureName}, объем: {sphere.CalculateVolume()}");

                Figure rectangularPrism = new Figure(FigureType.RectangularPrism);
                rectangularPrism.InputData();
                Console.WriteLine($"{rectangularPrism.FigureName}, объем: {rectangularPrism.CalculateVolume()}");

                Figure circularCone = new Figure(FigureType.CircularCone);
                circularCone.InputData();
                Console.WriteLine($"{circularCone.FigureName}, объем: {circularCone.CalculateVolume()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
