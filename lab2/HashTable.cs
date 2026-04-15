namespace lab2;

public class HashTable
{
    private Segment[] table;
    private int size;

    private const double A = 0.6180339887;

    public HashTable(int size)
    {
        this.size = size;
        table = new Segment[size];
    }

    private int HashFunction(double key)
    {
        // Дробова частина від (key * A)
        double fractionalPart = (key * A) - Math.Floor(key * A);
        return (int)Math.Floor(size * fractionalPart);
    }

    public bool Insert(Segment item)
    {
        double key = item.CalculateLength();
        int initialIndex = HashFunction(key);

        for (int i = 0; i < size; i++)
        {
            int index = (initialIndex + i * i) % size;

            if (table[index] == null)
            {
                table[index] = item;
                return true;
            }
        }

        Console.WriteLine($"[Помилка] Не вдалося додати відрізок L={key:F2}. Алгоритм зациклився (змініть розмір таблиці на більше просте число).");
        return false;
    }

    public void Display()
    {
        Console.WriteLine("\n--- Вміст Хеш-таблиці ---");
        for (int i = 0; i < size; i++)
        {
            if (table[i] != null)
            {
                Console.WriteLine($"Індекс {i,2} | Хеш-ключ (Довжина): {table[i].CalculateLength(),-5:F2} | {table[i]}");
            }
            else
            {
                Console.WriteLine($"Індекс {i,2} | [порожньо]");
            }
        }
        Console.WriteLine("-------------------------\n");
    }
}