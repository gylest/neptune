namespace learncsharp.Dev;

class Program
{
    static void Main(string[] args)
    {
        // Basic console output
        Console.WriteLine("Hello, World!");
        int age = 845;
        Console.WriteLine($"Hello, Tony! You are {age} years old.");

        //
        // Basic Features
        //
        BasicFeatures basicFeatures = new BasicFeatures();
        basicFeatures.DemonstrateRecords();
        basicFeatures.FizzBuzz();

    }
}