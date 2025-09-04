namespace learncsharp
{
    using Newtonsoft.Json;

    public class DataImport
    {
        // Add properties and methods for data import functionality here

        public Person ImportFile(string filePath)
        {
            Console.WriteLine($"Import file is:  {filePath} .");
            string json = File.ReadAllText(filePath);
            Person? person = JsonConvert.DeserializeObject<Person>(json);
            return person;
        }
    }
}
