using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Задание 1
        string text1 = "Функция — это фрагмент программного кода, который имеет собственное " +
                       "имя и выполняет определённую задачу. Функция может принимать ряд " +
                       "параметров и возвращать некоторые значения. Для возвращения значений " +
                       "используется оператор return. Функция, которая ничего не возвращает, " +
                       "называется процедурой. Функция, которая находится в каком-нибудь классе, " +
                       "называется методом. В С# .NET любая функция принадлежит какому-либо " +
                       "классу и, следовательно, является методом.";

        // a) Подсчитываем общее количество букв
        int totalLetterCount = text1.Length;

        // b) Используя регулярные выражения, подсчитываем буквы кириллицы и латинского алфавита
        int cyrillicLetterCount = Regex.Matches(text1, "[А-Яа-я]").Count;
        int latinLetterCount = Regex.Matches(text1, "[A-Za-z]").Count;

        // c) Подсчитываем количество слов в тексте
        int wordCount = Regex.Matches(text1, @"\b\w+\b").Count;

        // d) Подсчитываем количество слов, состоящих из пяти букв
        int fiveLetterWordCount = Regex.Matches(text1, @"\b\w{5}\b").Count;

        // e) Выбираем слова, состоящие от 4 до 7 букв и выводим их на консоль
        var selectedWords = Regex.Matches(text1, @"\b\w{4,7}\b");
        Console.WriteLine("e) Выбранные слова:");
        foreach (Match word in selectedWords)
        {
            Console.WriteLine(word.Value);
        }

        // f) Подсчитываем, сколько раз в тексте используется слово "функция"
        int functionCount = Regex.Matches(text1, @"\bфункция\b").Count;

        // Выводим результаты на консоль
        Console.WriteLine($"a) Общее количество букв: {totalLetterCount}");
        Console.WriteLine($"b) Количество букв кириллицы: {cyrillicLetterCount}");
        Console.WriteLine($"   Количество букв латинского алфавита: {latinLetterCount}");
        Console.WriteLine($"c) Количество слов: {wordCount}");
        Console.WriteLine($"d) Количество слов, состоящих из пяти букв: {fiveLetterWordCount}");
        Console.WriteLine($"f) Количество слова 'функция': {functionCount}");

        // Задание 2
        Console.Write("Введите белорусский телефонный номер в международном формате (+375 ccc nnn-nn-nn): ");
        string phoneNumber = Console.ReadLine();

        string pattern = @"^\+375\d{3}\s\d{3}-\d{2}-\d{2}$";

        if (Regex.IsMatch(phoneNumber, pattern))
        {
            Console.WriteLine("Номер введен правильно.");
        }
        else
        {
            Console.WriteLine("Номер введен неправильно.");
        }

        // Задание 3
        string text2 = "Во второй половине того осеннего дня 1990 года лампы не горели ни с " +
                       "одной из четырех сторон светофора, и дома вокруг тоже стояли темные.";

        // c) Выводим измененный текст на консоль
        Console.WriteLine(text2);
    }
}
