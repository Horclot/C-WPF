using System;

namespace Laba_12_Karytnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите фамилию и инициалы (в формате Иванов И.И.):");
                string input = Console.ReadLine();

                NameValidator.Validate(input);

                Console.WriteLine("Ввод корректен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            try
            {
                Console.WriteLine("Пример работы DivideByZeroException:");
                DivideByZeroExample(); 
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            try
            {
                Console.WriteLine("Пример работы IndexOutOfRangeException:");
                int[] array = { 1, 2, 3 };
                int value = array[3]; 
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey(); 
        }

        static void DivideByZeroExample()
        {
            int numerator = 5;
            int denominator = 0;
            int result = numerator / denominator; 
            Console.WriteLine($"Результат деления: {result}");
        }
    }

    internal class NameValidator
    {
        public static void Validate(string input)
        {
            string pattern = @"^[А-ЯЁ][а-яё]+\s[А-ЯЁ]\.[А-ЯЁ]\.$";
            if (input.Length > 30 || !System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
            {
                throw new ArgumentException("Неправильный ввод имени");
            }
        }
    }
}
