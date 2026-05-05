

namespace lab9;

class Program
{
    static long Factorial(int n)
    {
        if (n < 0) return 0;
        long res = 1;
        for (int i = 1; i <= n; i++) res *= i;
        return res;
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Лабораторна робота 2.3: Комбінаторні алгоритми ===");
        Console.WriteLine("Варіант 4: Розклад дисциплін (Розміщення без повторень)");
        Console.WriteLine("------------------------------------------------------");

        try
        {
            Console.Write("Введіть загальну кількість дисциплін (n): ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Введіть кількість дисциплін у розкладі на день (k): ");
            int k = int.Parse(Console.ReadLine() ?? "0");

            if (k > n)
            {
                Console.WriteLine("Помилка: k не може бути більшим за n для вибірки без повторень.");
                return;
            }

            Console.WriteLine("\n--- Аналіз задачі ---");
            Console.WriteLine("Тип вибірки: Розміщення без повторень.");
            Console.WriteLine("Обґрунтування: Порядок предметів у розкладі важливий (1-ша, 2-га, 3-тя пари),");
            Console.WriteLine("а за умовою предмети мають бути різними.");

            long result = Factorial(n) / Factorial(n - k);

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"Формула: A({n},{k}) = {n}! / ({n} - {k})!");
            Console.WriteLine($"Кількість можливих варіантів розкладу: {result}");
            Console.WriteLine("------------------------------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка введення: {ex.Message}");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}
