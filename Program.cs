using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите путь к папке:");
        string? directoryPath = Console.ReadLine();

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Указанная папка не существует.");
            return;
        }

        string[] files = Directory.GetFiles(directoryPath);

        if (files.Length == 0)
        {
            Console.WriteLine("В указанной папке нет файлов.");
            return;
        }

        // Группируем файлы по расширению
        var groupedFiles = files
            .GroupBy(file => Path.GetExtension(file).ToLower()) // группируем по расширению файла
            .OrderBy(group => group.Key);  // сортируем группы по расширению

        // Выводим файлы, отсортированные по типу
        foreach (var group in groupedFiles)
        {
            Console.WriteLine($"\nФайлы типа {group.Key}:");

            foreach (var file in group)
            {
                Console.WriteLine(Path.GetFileName(file)); // выводим только имя файла
            }
        }
    }
}
