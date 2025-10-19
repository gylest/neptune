namespace learncsharp.Dev;

public class DataImport
{
    // Add properties and methods for data import functionality here

    public Person ImportFile(string filePath)
    {
        Console.WriteLine($"Import file is:  {filePath} .");
        string json = File.ReadAllText(filePath);
        Person? person = JsonConvert.DeserializeObject<Person>(json);
        if (person == null)
        {
            throw new InvalidOperationException("Failed to deserialize Person from the provided file.");
        }
        return person;
    }
}
