namespace learncsharp.Dev;

public static class Arrays
{

    public static void StaticArrays()
    {
        // Declaration and Initialization
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

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
