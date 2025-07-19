using System;
using Task1;

namespace Task1.ConsoleUI
{
    class Program
    {
        private static readonly SearchAlgorithms _searchAlgorithms = new SearchAlgorithms();

        static void Main(string[] args)
        {
            Console.WriteLine("=== Программа бинарного поиска ===");
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine();

            bool continueProgram = true;
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
            // 1. Запросить размер массива
            int arraySize = GetArraySize();
            
            // 2. Запросить элементы массива
            int[] array = GetArrayElements(arraySize);
            
            // 3. Проверить отсортированность
            if (!IsSorted(array))
            {
                Console.WriteLine("Ошибка: Массив должен быть отсортирован по возрастанию!");
                Console.WriteLine("Пример отсортированного массива: 1, 3, 5, 7, 9");
                return;
            }

            Console.WriteLine("Массив отсортирован корректно.");
            
            // 4. Запросить искомый элемент
            int target = GetTargetElement();
            
            // 5. Вызвать алгоритм поиска
            int result = _searchAlgorithms.Search(array, target);
            
            // 6. Показать результат
            DisplaySearchResult(array, target, result);
        }

        private static int GetArraySize()
        {
            while (true)
            {
                Console.Write("Введите размер массива (больше 0): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int size) && size > 0)
                {
                    return size;
                }

                Console.WriteLine("Некорректный ввод. Введите положительное целое число.");
            }
        }

        private static int[] GetArrayElements(int size)
        {
            int[] array = new int[size];
            Console.WriteLine($"Введите {size} элементов массива (в порядке возрастания):");

            for (int i = 0; i < size; i++)
            {
                while (true)
                {
                    Console.Write($"Элемент {i + 1}: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int element))
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
                string input = Console.ReadLine();

                if (int.TryParse(input, out int target))
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
                string input = Console.ReadLine()?.ToLower().Trim();

                switch (input)
                {
                    case "y":
                    case "yes":
                    case "да":
                    case "д":
                        Console.WriteLine();
                        return true;
                    case "n":
                    case "no":
                    case "нет":
                    case "н":
                        return false;
                    default:
                        Console.WriteLine("❌ Введите 'y' для продолжения или 'n' для выхода.");
                        break;
                }
            }
        }
    }
}