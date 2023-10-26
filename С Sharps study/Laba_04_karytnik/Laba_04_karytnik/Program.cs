using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_04_karytnik
{
    class Program
    {
        static void Main()
        {
            // Задание B: Вывести квадраты чисел от 1 до 10
            PrintSquares(1, 10);

            // Задание C: Найти наибольшее из двух чисел
            int num1 = 5;
            int num2 = 8;
            int maxNumber = FindMax(num1, num2);
            Console.WriteLine($"Наибольшее число между {num1} и {num2} равно {maxNumber}");

            // Задание D: Проверить, является ли год високосным
            int year = 2024;
            bool isLeapYear = IsLeapYear(year);
            Console.WriteLine($"{year} - високосный год: {isLeapYear}");

            // Задание E: Проверить существование треугольника
            double side1, side2, side3;
            Console.WriteLine("Введите длины сторон треугольника:");
            Console.Write("Сторона 1: ");
            side1 = double.Parse(Console.ReadLine());
            Console.Write("Сторона 2: ");
            side2 = double.Parse(Console.ReadLine());
            Console.Write("Сторона 3: ");
            side3 = double.Parse(Console.ReadLine());

            bool isTriangle = IsTriangle(side1, side2, side3);
            Console.WriteLine($"Треугольник с заданными сторонами существует: {isTriangle}");
        }

        // Задание B: Вывести квадраты чисел от start до end
        static void PrintSquares(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                int square = CalculateSquare(i);
                Console.WriteLine($"Квадрат числа {i} равен {square}");
            }
        }

        // Метод для вычисления квадрата числа
        static int CalculateSquare(int number)
        {
            return number * number;
        }

        // Задание C: Найти наибольшее из двух чисел
        static int FindMax(int num1, int num2)
        {
            return Math.Max(num1, num2);
        }

        // Задание D: Проверить, является ли год високосным
        static bool IsLeapYear(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Задание E: Проверить существование треугольника
        static bool IsTriangle(double side1, double side2, double side3)
        {
            return (side1 + side2 > side3) && (side1 + side3 > side2) && (side2 + side3 > side1);
        }
    }
}
