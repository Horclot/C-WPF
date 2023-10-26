using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        // Задание 1
        string text1 = " Абв где жзи клм ";
        text1 = text1.Trim(); // удалить пробелы из начала и конца строки
        Console.WriteLine($"Количество символов в строке: {text1.Length}");
        Console.WriteLine($"Количество букв в строке: {text1.Replace(" ", "").Length}");
        Console.WriteLine($"Измененная строка: {SwapCase(text1)}");

        // Задание 2
        string text2 = "Кораблик нырял носом, кренился на борт, выпрямлялся, храбро проскакивал коварные водовороты и продолжал плавание вдоль Уитчем-стрит к светофору на перекрестке с Джексон-стрит. Во второй половине того осеннего дня 1957 года лампы не горели ни с одной из четырех сторон светофора, и дома вокруг тоже стояли темные. Дождь не переставая лил уже неделю, а последние два дня к нему прибавился ветер. Многие районы Дерри остались без электричества, и восстановить его подачу удалось не везде.";
        Console.WriteLine($"Количество слов в тексте: {CountWords(text2)}");
        Console.WriteLine($"Количество предложений в тексте: {CountSentences(text2)}");
        Console.WriteLine($"Количество букв 'а' в тексте: {CountLetterA(text2)}");

        // Задание 3
        StringBuilder sb = new StringBuilder("Меня зовут");
        sb.Insert(8, "Ваше имя"); // Вставляем имя после "Меня зовут"
        sb.Insert(7, " не"); // Вставляем "не" перед именем
        sb.Replace("Ваше имя", "Другое имя"); // Заменяем имя
        Console.WriteLine(sb);

        // Задание 4
        string reversedWord = ReverseWord("Hello");
        Console.WriteLine($"Результат работы метода ReverseWord: {reversedWord}");

        // Задание 5
        string transformedWord = TransformWord("apple");
        Console.WriteLine($"Результат работы метода TransformWord: {transformedWord}");
    }

    // Метод для инвертирования порядка символов в слове с сохранением регистра
    static string ReverseWord(string word)
    {
        char[] charArray = word.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    // Метод для замены буквы на ее порядковый номер с разделителем "-"
    static string TransformWord(string word)
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in word)
        {
            int charNumber = (int)c - (int)'a' + 1;
            result.Append(charNumber);
            result.Append("-");
        }
        result.Length--; // Убираем последний дефис
        return result.ToString();
    }

    // Метод для обмена регистра букв
    static string SwapCase(string text)
    {
        char[] charArray = text.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            if (char.IsLower(charArray[i]))
                charArray[i] = char.ToUpper(charArray[i]);
            else if (char.IsUpper(charArray[i]))
                charArray[i] = char.ToLower(charArray[i]);
        }
        return new string(charArray);
    }

    // Метод для подсчета слов в тексте
    static int CountWords(string text)
    {
        string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    // Метод для подсчета предложений в тексте
    static int CountSentences(string text)
    {
        string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        return sentences.Length;
    }

    // Метод для подсчета букв 'а' в тексте
    static int CountLetterA(string text)
    {
        return text.Count(c => c == 'а' || c == 'А');
    }
}
