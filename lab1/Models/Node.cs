namespace lab1.Models;

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