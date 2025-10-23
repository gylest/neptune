using System;
using System.IO;
using Xunit;

namespace learncsharp.Tests
{
    public class DataImportTests
    {
        [Fact]
        public void ImportFile_ShouldReturnPersonObject_WhenJsonIsValid()
        {
            // Arrange
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(projectRoot, "person_jd.json");
            var dataImport = new DataImport();

            // Act
            Person? person = dataImport.ImportFile(filePath);

            // Assert
            Assert.NotNull(person);
            Assert.False(string.IsNullOrEmpty(person.FirstName));
            Assert.False(string.IsNullOrEmpty(person.LastName));
            Assert.NotNull(person.BirthDate);
        }
    }
}