namespace learncsharp.Dev;

class Program
{
    static void Main(string[] args)
    {
        // Basic console output
        Console.WriteLine("Start Learncsharp!");

        // Data Structures
        Arrays.StartHere();
        HashTables.StartHere();
        LinkedLists.StartHere();
        StacksAndQueues.StartHere();
        SortedDictionaryMethods.InvokeSortedDictionary();
        Graphs graphs = new Graphs();
        graphs.StartHere();
    }
}