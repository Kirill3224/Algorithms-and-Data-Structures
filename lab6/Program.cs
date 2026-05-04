
using System.Diagnostics;

namespace lab6;

class Program
{
    public static void ShellSort(int[] array)
    {
        int n = array.Length;

        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = array[i];
                int j;

                for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                {
                    array[j] = array[j - gap];
                }

                array[j] = temp;
            }
        }
    }

    public static int[] GenerateRandomArray(int size)
    {
        Random rand = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = rand.Next(1, 100000);
        }
        return array;
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int n1 = 100;
        int n2 = 100 * 100;
        int n3 = 100 * 100 * 100;

        int[] sizes = { n1, n2, n3 };

        Console.WriteLine("=================================================");
        Console.WriteLine(" Дослідження часу виконання сортування Шелла");
        Console.WriteLine("=================================================");
        Console.WriteLine($"{"Кількість елементів (N)",-25} | {"Час виконання (мс)"}");
        Console.WriteLine("-------------------------------------------------");

        foreach (int size in sizes)
        {
            int[] array = GenerateRandomArray(size);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            ShellSort(array);
            stopwatch.Stop();

            Console.WriteLine($"{size,-25} | {stopwatch.ElapsedMilliseconds} мс");
        }
        Console.WriteLine("=================================================");
        Console.WriteLine("\nЗапишіть ці дані для побудови графіка в Excel.");
    }
}