using lab5.Entities;

namespace lab5;

class Program
{
    public static int BinarySearch(Student[] array, int count, string targetLastName)
    {
        int left = 0;
        int right = count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparisonResult = string.Compare(array[mid].LastName, targetLastName, StringComparison.OrdinalIgnoreCase);

            if (comparisonResult == 0)
            {
                return mid;
            }
            else if (comparisonResult < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }

    public static void PrintArray(Student[] array, int count)
    {
        Console.WriteLine(new string('-', 63));
        Console.WriteLine($"| {"Прізвище",-12} | {"Ім'я",-10} | {"Курс",-4} | {"Група",-8} | {"Місто",-12} |");
        Console.WriteLine(new string('-', 63));
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(array[i].ToString());
        }
        Console.WriteLine(new string('-', 63));
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int maxCapacity = 25;
        Student[] students = new Student[maxCapacity];
        int currentCount = 20;

        students[0] = new Student("Шевченко", "Тарас", 2, "КН-21", "Київ");
        students[1] = new Student("Бойко", "Іван", 1, "ПЗ-11", "Львів");
        students[2] = new Student("Косач", "Лариса", 3, "КН-31", "Луцьк");
        students[3] = new Student("Іванов", "Олег", 2, "ПЗ-21", "Донецьк");
        students[4] = new Student("Петров", "Максим", 4, "КН-41", "Харків");
        students[5] = new Student("Стус", "Василь", 1, "ПЗ-12", "Вінниця");
        students[6] = new Student("Григоренко", "Анна", 2, "КН-22", "Одеса");
        students[7] = new Student("Лисенко", "Микола", 3, "ПЗ-31", "Полтава");
        students[8] = new Student("Сидоров", "Андрій", 1, "КН-11", "Донецьк");
        students[9] = new Student("Франко", "Іван", 4, "ПЗ-41", "Львів");
        students[10] = new Student("Костенко", "Ліна", 2, "КН-21", "Ржищів");
        students[11] = new Student("Ткаченко", "Марія", 1, "ПЗ-11", "Київ");
        students[12] = new Student("Котляревський", "Іван", 3, "КН-32", "Полтава");
        students[13] = new Student("Морозов", "Олексій", 2, "ПЗ-22", "Дніпро");
        students[14] = new Student("Залужний", "Валерій", 4, "КН-42", "Житомир");
        students[15] = new Student("Павленко", "Олена", 1, "ПЗ-12", "Суми");
        students[16] = new Student("Романенко", "Ігор", 2, "КН-22", "Чернігів");
        students[17] = new Student("Мельник", "Софія", 3, "ПЗ-32", "Тернопіль");
        students[18] = new Student("Коваль", "Дмитро", 1, "КН-12", "Ужгород");
        students[19] = new Student("Бондар", "Яна", 4, "ПЗ-42", "Чернівці");

        Console.WriteLine("Початковий масив (Невпорядкований):");
        PrintArray(students, currentCount);

        Console.WriteLine("\n[Система] Сортуємо масив за прізвищем для коректної роботи бінарного пошуку...");
        Array.Sort(students, 0, currentCount);

        Console.WriteLine("\nМасив після сортування:");
        PrintArray(students, currentCount);

        string targetName = "Іванов";

        Console.WriteLine($"\nШукаємо студента з прізвищем '{targetName}' бінарним пошуком...");
        int foundIndex = BinarySearch(students, currentCount, targetName);

        if (foundIndex != -1)
        {
            Console.WriteLine($"Студента знайдено! Місто проживання: {students[foundIndex].City}");

            if (students[foundIndex].City.Equals("Донецьк", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"[Дія] Студент проживає у Донецьку. Виконуємо видалення...");

                for (int i = foundIndex; i < currentCount - 1; i++)
                {
                    students[i] = students[i + 1];
                }
                students[currentCount - 1] = null;
                currentCount--;

                Console.WriteLine("[Успіх] Студента видалено.");
            }
            else
            {
                Console.WriteLine($"[Відміна] Студент '{targetName}' не проживає у Донецьку. Видалення не потрібне.");
            }
        }
        else
        {
            Console.WriteLine($"[Помилка] Студента з прізвищем '{targetName}' не знайдено.");
        }

        Console.WriteLine("\nФінальний вміст масиву:");
        PrintArray(students, currentCount);
    }
}
