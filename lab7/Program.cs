using System.Globalization;

namespace lab7
{
    class Program
    {
        static double f(double x) => 0.5 * Math.Exp(Math.Sqrt(1 + 2 * x));

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo ci = CultureInfo.InvariantCulture;

            Console.WriteLine("=== Лабораторна робота 2.1 (Варіант 4) ===");

            try
            {
                Console.Write("Введіть нижню межу (a): ");
                double a = double.Parse((Console.ReadLine() ?? "1").Replace(',', '.'), ci);

                Console.Write("Введіть верхню межу (b): ");
                double b = double.Parse((Console.ReadLine() ?? "2").Replace(',', '.'), ci);

                Console.Write("Введіть крок (h): ");
                double h = double.Parse((Console.ReadLine() ?? "0.2").Replace(',', '.'), ci);

                int n = (int)Math.Round(Math.Abs(b - a) / h);
                if (n <= 0) n = 1;
                double actualH = (b - a) / n;

                Console.WriteLine($"\nПараметри: n = {n}, h = {actualH:F4}");
                Console.WriteLine(new string('-', 45));
                Console.WriteLine("{0,-25} | {1,15}", "Метод", "Значення");
                Console.WriteLine(new string('-', 45));

                double rectSum = 0;
                for (int i = 0; i < n; i++) rectSum += f(a + i * actualH + actualH / 2);
                Console.WriteLine("{0,-25} | {1,15:F8}", "Прямокутників", rectSum * actualH);

                double trapSum = (f(a) + f(b)) / 2.0;
                for (int i = 1; i < n; i++) trapSum += f(a + i * actualH);
                Console.WriteLine("{0,-25} | {1,15:F8}", "Трапецій", trapSum * actualH);

                int nS = (n % 2 == 0) ? n : n + 1;
                double hS = (b - a) / nS;
                double simpsonSum = f(a) + f(b);
                for (int i = 1; i < nS; i++)
                {
                    double x = a + i * hS;
                    simpsonSum += (i % 2 != 0) ? 4 * f(x) : 2 * f(x);
                }
                Console.WriteLine("{0,-25} | {1,15:F8}", "Сімпсона", (hS / 3.0) * simpsonSum);

                Console.WriteLine(new string('-', 45));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.WriteLine("\nРобота завершена. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}