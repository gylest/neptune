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

        //
        // Data import
        //
        string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(projectRoot, "person_jd.json");

        DataImport dataImport = new DataImport();
        Person? person = dataImport.ImportFile(filePath);

        //
        // Control Patterns
        //
        Order order = new Order { Total = 1200.00m, CustomerTier = 'G' };
        string discountLevel = ControlPatterns.ComputeDiscountLevel(order);
        Console.WriteLine($"Discount level for order total {order.Total} is {discountLevel}");

    }
}