using lab1.Models;

namespace lab1;



public class LinkedStack
{
    private Node? top;

    public LinkedStack()
    {
        top = null;
    }

    public bool IsEmpty()
    {
        return top == null;
    }

    public void Push(double value)
    {
        Node newNode = new Node(value);

        newNode.Next = top;
        top = newNode;
        Console.WriteLine($"Додано: {value}");
    }

    public double Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Помилка: Стек порожній!");
        }

        if (top == null)
        {
            Console.WriteLine("Немає вершини стека");
            return 0;
        }

        double value = top.Data;
        top = top.Next;
        return value;
    }

    public void PrintContent()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Стек порожній.");
            return;
        }

        Console.Write("Вміст стека (від вершини): ");

        Node? current = top;

        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}