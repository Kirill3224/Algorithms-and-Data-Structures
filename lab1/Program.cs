using System;
using lab1.Models;
using lab1;

namespace Lab1;


class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        LinkedStack stack = new LinkedStack();

        Console.WriteLine("--- Додавання елементів ---");
        stack.Push(10.5);
        stack.Push(20.75);
        stack.Push(3.14);
        stack.Push(42.0);

        stack.PrintContent();

        Console.WriteLine("\n--- Видалення 2-х елементів ---");
        try
        {
            Console.WriteLine($"Вилучено елемент: {stack.Pop()}");
            Console.WriteLine($"Вилучено елемент: {stack.Pop()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        stack.PrintContent();

        Console.ReadKey();
    }
}
