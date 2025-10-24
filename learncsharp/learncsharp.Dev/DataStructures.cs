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
