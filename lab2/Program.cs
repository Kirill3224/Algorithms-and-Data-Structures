
namespace lab2;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть розмір хеш-таблиці (рекомендується просте число > 11, напр. 13 або 17): ");
        if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0)
        {
            size = 13;
            Console.WriteLine("Встановлено розмір за замовчуванням: 13.");
        }

        HashTable hashTable = new HashTable(size);

        Console.WriteLine("\nДодаємо базові відрізки...");
        hashTable.Insert(new Segment(0, 0, 3, 4));
        hashTable.Insert(new Segment(1, 1, 7, 9));
        hashTable.Insert(new Segment(0, 0, 8, 15));

        Console.WriteLine("\nСтворюємо штучну колізію (додаємо відрізки з однаковою довжиною)...");
        hashTable.Insert(new Segment(1, 1, 4, 5));
        hashTable.Insert(new Segment(2, 2, 5, 6));
        hashTable.Insert(new Segment(10, 10, 13, 14));

        hashTable.Display();
    }
}
