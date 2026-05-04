using lab3.Entities;

namespace lab3;

public class BinaryTree
{
    private TreeNode root;

    public BinaryTree()
    {
        root = null;
    }

    public void Insert(Student student)
    {
        root = InsertRecursive(root, student);
    }

    private TreeNode InsertRecursive(TreeNode node, Student student)
    {
        if (node == null)
        {
            return new TreeNode(student);
        }

        if (student.StudentTicket < node.Data.StudentTicket)
        {
            node.Left = InsertRecursive(node.Left, student);
        }
        else if (student.StudentTicket > node.Data.StudentTicket)
        {
            node.Right = InsertRecursive(node.Right, student);
        }
        else
        {
            Console.WriteLine($"[Помилка] Студент з квитком {student.StudentTicket} вже існує в дереві!");
        }

        return node;
    }

    public void PrintTableHeader()
    {
        Console.WriteLine(new string('-', 71));
        Console.WriteLine($"| {"Квиток",-10} | {"Прізвище",-10} | {"Ім'я",-10} | {"Курс",-4} | {"Стать",-7} | {"Місце прожив.",-15} |");
        Console.WriteLine(new string('-', 71));
    }

    public void PrintTreeParallel()
    {
        PrintTableHeader();
        ParallelTraversal(root);
        Console.WriteLine(new string('-', 71));
    }

    private void ParallelTraversal(TreeNode node)
    {
        if (node != null)
        {
            ParallelTraversal(node.Left);
            Console.WriteLine(node.Data.ToString());
            ParallelTraversal(node.Right);
        }
    }
}