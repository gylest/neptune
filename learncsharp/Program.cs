// See https://aka.ms/new-console-template for more information

using System;


namespace learncsharp
{

    class Program
    {
        static void Main(string[] args)
        {
            // Basic console output
            Console.WriteLine("Hello, World!");
            int age = 845;
            Console.WriteLine($"Hello, Tony! You are {age} years old.");

            // Data import
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(projectRoot, "person_jd.json");
            
            // Use an absolute path for testing
            const string testFile = @"C:\Users\Tony Gyles\source\repos\neptune\learncsharp\person_jd.json";
            
            DataImport dataImport = new DataImport();
            Person? person = dataImport.ImportFile(testFile);
        }
    }

}