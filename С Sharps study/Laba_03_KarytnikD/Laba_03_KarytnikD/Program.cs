using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_03_KarytnikD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание B: Вывод квадратов чисел от 1 до 10");
            for (int i = 1; i <= 10; i++)
            {
                int square = i * i;
                Console.WriteLine($"Квадрат числа {i} равен {square}");
            }
            Console.WriteLine();
            Console.ReadKey();
           


            Console.WriteLine("Задание C: Вывод квадратных корней чисел от 1 до 10");
            int j = 1;
            while (j <= 10)
            {
                double sqrt = Math.Sqrt(j);
                Console.WriteLine($"Квадратный корень из числа {j} равен {sqrt}");
                j++;
            }
            Console.WriteLine();
            Console.ReadKey();




            Console.WriteLine("Задание D: Вывод квадратов и квадратных корней для чисел от 1 до 10");
            for (int k = 1; k <= 10; k++)
            {
                if (k % 2 == 0)
                {
                    int square = k * k;
                    Console.WriteLine($"Квадрат числа {k} равен {square}");
                }
                else
                {
                    double sqrt = Math.Sqrt(k);
                    Console.WriteLine($"Квадратный корень из числа {k} равен {sqrt}");
                }
            }
            Console.WriteLine();
            Console.ReadKey();



            Console.WriteLine("Задание E: Введите порядковый номер месяца (1-12):");

            int monthNumber = 0;
            Int32.TryParse(Console.ReadLine(),out monthNumber);
            string monthName;
            switch (monthNumber)
            {
                case 1:
                    monthName = "Январь";
                    break;
                case 2:
                    monthName = "Февраль";
                    break;
                case 3:
                    monthName = "Март";
                    break;
                case 4:
                    monthName = "Апрель";
                    break;
                case 5:
                    monthName = "Май";
                    break;
                case 6:
                    monthName = "Июнь";
                    break;
                case 7:
                    monthName = "Июль";
                    break;
                case 8:
                    monthName = "Август";
                    break;
                case 9:
                    monthName = "Сентябрь";
                    break;
                case 10:
                    monthName = "Октябрь";
                    break;
                case 11:
                    monthName = "Ноябрь";
                    break;
                case 12:
                    monthName = "Декабрь";
                    break;
                default:
                    monthName = "Неверный номер месяца";
                    break;
            }
            Console.WriteLine($"Название месяца: {monthName}");
            Console.ReadKey();


        }
    }
}