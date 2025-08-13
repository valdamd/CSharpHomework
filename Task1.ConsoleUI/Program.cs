// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task1.ConsoleUI;

using System.Globalization;

internal sealed class Program
{
    private static readonly SearchAlgorithms SearchAlgorithms = new SearchAlgorithms();

    private static readonly Dictionary<string, bool> YesNoAnswers = new(StringComparer.OrdinalIgnoreCase)
    {
        ["yes"] = true,
        ["y"] = true,
        ["да"] = true,
        ["д"] = true,
        ["no"] = false,
        ["n"] = false,
        ["нет"] = false,
        ["н"] = false,
    };

    private static void Main(string[] args)
    {
        Console.WriteLine("=== Программа бинарного поиска ===");
        Console.WriteLine("Добро пожаловать!");
        Console.WriteLine();

        var continueProgram = true;
        while (continueProgram)
        {
            try
            {
                RunSearchSession();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.WriteLine();
            continueProgram = AskToContinue();
        }

        Console.WriteLine("Программа завершена. До свидания!");
    }

    private static void RunSearchSession()
    {
        var arraySize = GetArraySize();

        int[] array = GetArray(arraySize);

        if (!IsSorted(array))
        {
            Console.WriteLine("Ошибка: Массив должен быть отсортирован по возрастанию!");
            Console.WriteLine("Пример отсортированного массива: 1, 3, 5, 7, 9");
            return;
        }

        Console.WriteLine("Массив отсортирован корректно.");

        var target = GetTargetElement();
        var result = SearchAlgorithms.Search(array, target);
        DisplaySearchResult(array, target, result);
    }

    private static int GetArraySize()
    {
        while (true)
        {
            Console.Write("Введите размер массива (больше 0): ");
            var input = Console.ReadLine()?.Trim();

            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int size) && size > 0)
            {
                return size;
            }

            Console.WriteLine("Некорректный ввод. Введите положительное целое число.");
        }
    }

    private static int[] GetArray(int size)
    {
        int[] array = new int[size];
        Console.WriteLine($"Введите {size} элементов массива (в порядке возрастания):");

        for (int i = 0; i < size; i++)
        {
            while (true)
            {
                Console.Write($"Элемент {i + 1}: ");
                var input = Console.ReadLine()?.Trim();

                if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int element))
                {
                    array[i] = element;
                    break;
                }

                Console.WriteLine("❌ Некорректный ввод. Введите целое число.");
            }
        }

        return array;
    }

    private static bool IsSorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
            {
                return false;
            }
        }

        return true;
    }

    private static int GetTargetElement()
    {
        while (true)
        {
            Console.Write("Введите искомый элемент: ");
            var input = Console.ReadLine()?.Trim();

            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int target))
            {
                return target;
            }

            Console.WriteLine("❌ Некорректный ввод. Введите целое число.");
        }
    }

    private static void DisplaySearchResult(int[] array, int target, int result)
    {
        Console.WriteLine();
        Console.WriteLine("=== Результат поиска ===");
        Console.WriteLine($"Массив: [{string.Join(", ", array)}]");
        Console.WriteLine($"Искомый элемент: {target}");

        if (result == -1)
        {
            Console.WriteLine($"❌ Элемент {target} не найден в массиве.");
        }
        else
        {
            Console.WriteLine($"✅ Элемент {target} найден на позиции {result} (индекс: {result})");
            Console.WriteLine($"Проверка: array[{result}] = {array[result]}");
        }
    }

    private static bool AskToContinue()
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write("Хотите выполнить еще один поиск? (y/n): ");
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("❌ Введите 'y' для продолжения или 'n' для выхода.");
                continue;
            }

            if (YesNoAnswers.TryGetValue(input, out bool shouldContinue))
            {
                if (shouldContinue)
                {
                    Console.WriteLine();
                }

                return shouldContinue;
            }

            Console.WriteLine("❌ Введите 'y' для продолжения или 'n' для выхода.");
        }
    }
}
