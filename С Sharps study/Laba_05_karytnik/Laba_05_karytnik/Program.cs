using System;
using System.Collections.Generic;

public class College
{
    public string Name { get; set; }
    private Dictionary<int, List<string>> groups = new Dictionary<int, List<string>>();

    // Индексатор для доступа к списку студентов в группе по индексу
    public List<string> this[int index]
    {
        get
        {
            if (groups.ContainsKey(index))
            {
                return groups[index];
            }
            else
            {
                return new List<string>();
            }
        }
        set
        {
            groups[index] = value;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        College college = new College();
        college.Name = "Мой колледж";

        // Добавление студентов в группы
        for (int i = 101; i <= 110; i++)
        {
            List<string> students = new List<string>();
            for (int j = 1; j <= 5; j++)
            {
                students.Add($"Студент {i * 10 + j}");
            }
            college[i] = students;
        }

        // Вывод списка студентов в группе 102
        Console.WriteLine("Список студентов в группе 102:");
        List<string> group102Students = college[102];
        foreach (string student in group102Students)
        {
            Console.WriteLine(student);
        }
    }
}
