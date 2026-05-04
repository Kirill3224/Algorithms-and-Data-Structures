using lab3.Entities;

namespace lab3;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        BinaryTree tree = new BinaryTree();

        Console.WriteLine("Додавання елементів до дерева...");

        tree.Insert(new Student("Шевченко", "Тарас", 3, 105, "Чол", "Київ"));
        tree.Insert(new Student("Косач", "Лариса", 2, 102, "Жін", "Луцьк"));
        tree.Insert(new Student("Франко", "Іван", 4, 108, "Чол", "Львів"));
        tree.Insert(new Student("Стус", "Василь", 1, 101, "Чол", "Вінниця"));
        tree.Insert(new Student("Костенко", "Ліна", 3, 106, "Жін", "Ржищів"));

        tree.Insert(new Student("Котляревський", "Іван", 2, 105, "Чол", "Полтава"));

        Console.WriteLine("\nВміст дерева (Паралельний обхід):");
        tree.PrintTreeParallel();
    }
}