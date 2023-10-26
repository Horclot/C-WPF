using System;

namespace Laba_06_karytnik
{
    // Задание 1: Создаем класс Planet
    class Planet
    {
        // Приватные поля для хранения информации о планете
        private string name;
        private double distance;
        private double diameter;
        private int satellitesNumber;

        // Конструктор класса для инициализации полей
        public Planet(string name, double distance, double diameter, int satellitesNumber)
        {
            this.name = name;
            this.distance = distance;
            this.diameter = diameter;
            this.satellitesNumber = satellitesNumber;
        }

        // Методы для получения значений полей
        public string GetName()
        {
            return name;
        }

        public double GetDistance()
        {
            return distance;
        }

        public double GetDiameter()
        {
            return diameter;
        }

        public int GetSatellitesNumber()
        {
            return satellitesNumber;
        }
    }

    class SolarSystem
    {
        // Задание 2: Создаем массив планет
        private Planet[] planets;

        // Индексатор для доступа к планетам по индексу
        public Planet this[int index]
        {
            get
            {
                if (index >= 0 && index < planets.Length)
                {
                    return planets[index];
                }
                else
                {
                    // Возвращаем пустую планету, если индекс некорректный
                    return new Planet("Нет данных", 0, 0, 0);
                }
            }
        }

        // Конструктор класса SolarSystem
        public SolarSystem()
        {
            // Создаем 8 планет с заданными параметрами
            planets = new Planet[]
            {
                new Planet("Mercury", 0.39, 4878, 0),
                new Planet("Venus", 0.72, 12100, 0),
                new Planet("Earth", 1, 12742, 1),
                new Planet("Mars", 1.52, 6794, 2),
                new Planet("Jupiter", 5.2, 139800, 16),
                new Planet("Saturn", 9.54, 116000, 30),
                new Planet("Uranus", 19.19, 50800, 15),
                new Planet("Neptune", 30.07, 48600, 6),};
        }

        // Задание 3: Индексатор уже определен выше (см. задание 2)
        // Мы используем индексатор для доступа к планетам
        public int Length
        {
            get { return planets.Length; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект класса SolarSystem
            SolarSystem solarSystem = new SolarSystem();

            // Выводим информацию о планетах с использованием индексатора
            for (int i = 0; i < solarSystem.Length; i++)
            {
                Planet planet = solarSystem[i];
                Console.WriteLine($"Планета {i + 1}:");
                Console.WriteLine($"Название: {planet.GetName()}");
                Console.WriteLine($"Расстояние до Солнца: {planet.GetDistance()} км");
                Console.WriteLine($"Диаметр: {planet.GetDiameter()} км");
                Console.WriteLine($"Количество спутников: {planet.GetSatellitesNumber()}");
                Console.WriteLine();
            }

            // Ждем, пока пользователь нажмет Enter, чтобы консоль не закрылась сразу
            Console.ReadLine();
        }
    }
}