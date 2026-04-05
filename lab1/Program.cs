using System;

namespace Lab1
{
    public class Node
    {
        public double Data;
        public Node? Next;

        public Node(double data)
        {
            Data = data;
            Next = null;
        }
    }

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
}