using lab4.Entities;

namespace lab4;

class Program
{
    public static void CountingSortDescending(Student[] array)
    {
        if (array == null || array.Length == 0) return;

        int max = array[0].LabCount;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i].LabCount > max)
            {
                max = array[i].LabCount;
            }
        }

        int[] count = new int[max + 1];

        for (int i = 0; i < array.Length; i++)
        {
            count[array[i].LabCount]++;
        }

        for (int i = max - 1; i >= 0; i--)
        {
            count[i] += count[i + 1];
        }

        Student[] output = new Student[array.Length];

        for (int i = array.Length - 1; i >= 0; i--)
        {
            int val = array[i].LabCount;
            output[count[val] - 1] = array[i];
            count[val]--;
        }

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = output[i];
        }
    }

    public static void PrintArray(Student[] array)
    {
        Console.WriteLine(new string('-', 63));
        Console.WriteLine($"| {"Прізвище",-12} | {"Ім'я",-10} | {"Назва дисципліни",-20} | {"К-ть лаб.",-10} |");
        Console.WriteLine(new string('-', 63));
        foreach (var student in array)
        {
            Console.WriteLine(student.ToString());
        }
        Console.WriteLine(new string('-', 63));
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Student[] students = new Student[]
        {
                new Student("Шевченко", "Тарас", "Алгоритми та СД", 5),
                new Student("Косач", "Лариса", "Бази даних", 12),
                new Student("Франко", "Іван", "Алгоритми та СД", 8),
                new Student("Стус", "Василь", "Програмування C#", 12),
                new Student("Костенко", "Ліна", "Комп'ютерні мережі", 3),
                new Student("Тичина", "Павло", "Бази даних", 15)
        };

        Console.WriteLine("Вміст масиву студентів ДО сортування:");
        PrintArray(students);

        CountingSortDescending(students);

        Console.WriteLine("\nВміст масиву студентів ПІСЛЯ сортування (за спаданням к-ті лаб. робіт):");
        PrintArray(students);
    }
}
