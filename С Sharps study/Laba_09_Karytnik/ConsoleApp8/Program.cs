using System;

namespace Laba_09_Karytnik
{
    public enum Months
    {
        Январь,
        Февраль,
        Март,
        Апрель,
        Май,
        Июнь,
        Июль,
        Август,
        Сентябрь,
        Октябрь,
        Ноябрь,
        Декабрь
    }

    public enum ZodiacSigns
    {
        Овен,
        Телец,
        Близнецы,
        Рак,
        Лев,
        Дева,
        Весы,
        Скорпион,
        Стрелец,
        Козерог,
        Водолей,
        Рыбы
    }

    public class Horoscope
    {
        public struct ZodiacInfo
        {
            public ZodiacSigns Sign { get; }
            public Months StartMonth { get; }
            public Months EndMonth { get; }

            public ZodiacInfo(ZodiacSigns sign, Months startMonth, Months endMonth)
            {
                Sign = sign;
                StartMonth = startMonth;
                EndMonth = endMonth;
            }
        }

        private ZodiacInfo[] zodiacInfoArray;

        public Horoscope()
        {
            // Инициализация массива с информацией о знаках зодиака
            zodiacInfoArray = new ZodiacInfo[]
            {
                new ZodiacInfo(ZodiacSigns.Овен, Months.Март, Months.Апрель),
                new ZodiacInfo(ZodiacSigns.Телец, Months.Апрель, Months.Май),
                // Добавьте остальные знаки зодиака
            };
        }

        public ZodiacInfo[] GetZodiacInfoArray()
        {
            return zodiacInfoArray;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Horoscope horoscope = new Horoscope();

            Console.WriteLine("Информация о знаках зодиака:");

            // Цикл while
            int i = 0;
            while (i < horoscope.GetZodiacInfoArray().Length)
            {
                Horoscope.ZodiacInfo info = horoscope.GetZodiacInfoArray()[i];
                Console.WriteLine($"{info.Sign} ({info.StartMonth} - {info.EndMonth})");
                i++;
            }

            // Цикл for
            for (int j = 0; j < horoscope.GetZodiacInfoArray().Length; j++)
            {
                Horoscope.ZodiacInfo info = horoscope.GetZodiacInfoArray()[j];
                Console.WriteLine($"{info.Sign} ({info.StartMonth} - {info.EndMonth})");
            }

            // Цикл foreach
            foreach (Horoscope.ZodiacInfo info in horoscope.GetZodiacInfoArray())
            {
                Console.WriteLine($"{info.Sign} ({info.StartMonth} - {info.EndMonth})");
            }
        }
    }
}
