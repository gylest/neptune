namespace learncsharp.Dev;

class Program
{
    static void Main(string[] args)
    {
        // Basic console output
        Console.WriteLine("Start Learncsharp!");

        // Language Features
        BasicFeatures basicFeatures = new BasicFeatures();
        basicFeatures.DemonstrateRecords();
        basicFeatures.FizzBuzz();

        // Data Structures
        Arrays.StartHere();
        HashTables.StartHere();

    }
}