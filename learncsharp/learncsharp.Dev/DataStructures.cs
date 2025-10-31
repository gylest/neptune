namespace learncsharp.Dev;

public static class Arrays
{

    public static void StaticArrays()
    {
        // Declaration and Initialization
        int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        // Accessing Elements
        numbers[6] = 42; // Modify the 7th element (index 6)
        int seventhElement = numbers[6];

        // Iteration
        for (int i = 0; i < numbers.Length; i++)
            Console.WriteLine(numbers[i]);

        foreach (var n in numbers)
            Console.WriteLine(n);

        // Searching
        bool found = numbers.Contains(10);
        int index = Array.IndexOf(numbers, 10);

        // Sorting
        Array.Sort(numbers);

        // Copying
        int[] copy = new int[numbers.Length];
        Array.Copy(numbers, copy, numbers.Length);

        // Reversing
        Array.Reverse(numbers);

        // Length
        int length = numbers.Length;
    }

    public static void DynamicArrays()
    {
        // Declaration and Initialization
        var letters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };

        // Adding Elements at and Inserting Elements at the Beginning
        letters.Add('h');
        letters.Insert(0, 'q');

        // Accessing Elements
        letters[1] = 'z'; // Modify the 2nd element (index 1)
        char ch = letters[5];

        // Iteration
        for (int i = 0; i < letters.Count; i++)
            Console.WriteLine(letters[i]);

        foreach (var n in letters)
            Console.WriteLine(n);

        // Searching
        bool found = letters.Contains('g');
        int index = letters.IndexOf('g');

        // Sorting and Reversing
        letters.Sort();
        letters.Reverse();

        // Copying
        var copy = new List<char>(letters);

        // count
        int count = letters.Count;
    }

    public static void StartHere()
    {
        StaticArrays();
        DynamicArrays();
    }

}

public static class HashTables
{
    public static void InvokeHashTables()
    {
        // Declaration and Initialization
        var capitals = new Dictionary<string, string>
        {
            { "USA", "Washington, D.C." },
            { "France", "Paris" },
            { "Japan", "Tokyo" },
            { "New Zealand", "Wellington" },
            { "Italy", "Rome" },
            { "Australia", "Canberra" },
            { "Brazil", "Brasilia" },
            { "Canada", "Ottawa" },
            { "UK", "London" }
        };

        // Adding Elements
        capitals["Germany"] = "Berlin";

        // Accessing Elements
        string capitalOfFrance = capitals["France"];

        if (capitals.TryGetValue("Australia", out string? val))
            Console.WriteLine($"The capital of Australia is {val}");

        // Iteration
        foreach (var kvp in capitals)
        {
            Console.WriteLine($"Country: {kvp.Key}, Capital: {kvp.Value}");
        }

        // Searching
        bool hasJapan = capitals.ContainsKey("Japan");
        bool hasCapitalTokyo = capitals.ContainsValue("Tokyo");

        // Removing Elements
        capitals.Remove("USA");

        // Count
        int count = capitals.Count;
    }
    public static void StartHere()
    {
        InvokeHashTables();

    }
}

public static class LinkedLists
{
    public static void InvokeLinkedLists()
    {
        // Declaration and Initialization
        var numbers = new LinkedList<int>([1, 2, 3, 4, 5]);

        // Adding Elements
        numbers.AddLast(6);
        numbers.AddFirst(0);
        var node = numbers.Find(3);
        if (node != null)
            numbers.AddAfter(node, 99);

        // Accessing Elements
        var first = numbers.First;
        var last = numbers.Last;

        // Iteration
        foreach (var n in numbers)
            Console.WriteLine(n);

        // Searching
        var searchNode = numbers.Find(4);
        bool found = searchNode != null;

        // Removing Elements
        numbers.Remove(2);
        numbers.RemoveFirst();
        numbers.RemoveLast();

        // Count
        int count = numbers.Count;
    }

    public static void StartHere()
    {
        InvokeLinkedLists();
    }
}

public static class StacksAndQueues
{
    //
    // Queue<T> is a FIFO (first-in, first-out) collection.
    // Ideal for scenarios like task scheduling, buffering, and breadth-first search.
    //
    public static void InvokeQueues()
    {
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(1); // Add to end
        queue.Enqueue(2);

        int first = queue.Dequeue(); // Remove from front (returns 1)
        int peek = queue.Peek();     // View front without removing (returns 2)
        bool isEmpty = queue.Count == 0;

        Console.WriteLine($"First dequeued: {first}, Next in queue: {peek}, Is empty: {isEmpty}");
    }

    //
    // Stack<T> is a LIFO (last-in, first-out) collection.
    // Ideal for scenarios like undo operations, parsing, and algorithmic tasks.
    //
    public static void InvokeStacks()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(1); // Add to top
        stack.Push(2);

        int top = stack.Pop();   // Remove and return top element (returns 2)
        int peek = stack.Peek(); // View top element without removing (returns 1)
        bool isEmpty = stack.Count == 0;

        Console.WriteLine($"Top popped: {top}, Next on stack: {peek}, Is empty: {isEmpty}");
    }

    public static void StartHere()
    {
        InvokeStacks();
        InvokeQueues();
    }
}

public class BinaryTreeNode<T>
{
    public T Value { get; set; }
    public BinaryTreeNode<T>? Left { get; set; }
    public BinaryTreeNode<T>? Right { get; set; }

    public BinaryTreeNode(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinaryTree<T>
{
    public BinaryTreeNode<T>? Root { get; set; }

    public BinaryTree()
    {
        Root = null;
    }

    public void Insert(T value)
    {
        if (Root == null)
        {
            Root = new BinaryTreeNode<T>(value);
        }
        else
        {
            InsertRec(Root, value);
        }
    }

    public void InsertRec(BinaryTreeNode<T> node, T value)
    {
        if (Comparer<T>.Default.Compare(value, node.Value) < 0)
        {
            if (node.Left == null)
                node.Left = new BinaryTreeNode<T>(value);
            else
                InsertRec(node.Left, value);
        }
        else
        {
            if (node.Right == null)
                node.Right = new BinaryTreeNode<T>(value);
            else
                InsertRec(node.Right, value);
        }
    }

    public void InOrderTraversal(BinaryTreeNode<T>? node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.WriteLine(node.Value);
            InOrderTraversal(node.Right);
        }
    }
    
    public bool LookupRec(BinaryTreeNode<T>? node, T value)
    {
        if (node == null)
            return false;
        if (Comparer<T>.Default.Compare(node.Value, value) == 0)
            return true;

        // Continue searching in the left or right subtree
        return LookupRec(node.Left, value) || LookupRec(node.Right, value);
    }

}


// A SortedDictionary is a collection of key-value pairs
// that are sorted by the keys based on their natural ordering.
// It provides efficient retrieval, addition, and removal of elements
// while maintaining the sorted order of keys.
// Common use cases include scenarios where sorted data access is required,
// such as in financial applications, leaderboards, and priority-based systems.
// Internally , it is typically implemented using a balanced binary search tree,
// ensuring logarithmic time complexity for key-based operations i.e., O(log n).
public class SortedDictionaryMethods
{
    public static void InvokeSortedDictionary()
    {
        // Initialize SortedDictionary
        SortedDictionary<string, int> sortedDict = new SortedDictionary<string, int>();
        sortedDict["banana"] = 3;
        sortedDict["apple"] = 4;
        sortedDict["pear"] = 1;
        sortedDict["orange"] = 2;
        sortedDict["cherry"] = 7;
        sortedDict["strawberry"] = 13;
        sortedDict["lime"] = 22;

        // Check if 'apple' exists
        if (sortedDict.ContainsKey("apple"))
        {
            Console.WriteLine("Contains 'apple' key: True");
        }

        // Remove 'apple' and check removal
        bool isRemoved = sortedDict.Remove("apple");
        Console.WriteLine("Removed 'apple': " + isRemoved); // Output: True

        // Attempt to fetch a non-existing key
        if (!sortedDict.TryGetValue("apple", out int value))
        {
            Console.WriteLine("Value: Not found"); // Output: Value: Not found
        }

        // Get the last key-value pair using LINQ
        var lastEntry = sortedDict.Last();
        Console.WriteLine($"Last entry: {lastEntry.Key}={lastEntry.Value}"); // Output: pear=1
    }
}

public class Graphs
{
    // Adjacency list representation
    private Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

    public void AddEdge(int vertex, int neighbor)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new List<int>();
        }
        adjacencyList[vertex].Add(neighbor);
    }

    public void PrintGraph()
    {
        foreach (var vertex in adjacencyList)
        {
            Console.Write(vertex.Key + " -> ");
            foreach (var neighbor in vertex.Value)
            {
                Console.Write(neighbor + " ");
            }
            Console.WriteLine();
        }
    }

    public  void StartHere()
    {
        Graphs graph = new Graphs();

        // Adding edges to the graph
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(3, 5);
        graph.AddEdge(4, 5);

        // Printing the graph
        graph.PrintGraph();
    }
}