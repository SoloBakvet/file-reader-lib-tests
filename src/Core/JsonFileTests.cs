using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace FileReaderLib.Core.Tests
{
    [TestClass()]
    public class JsonFileTests
    {
        [TestMethod()]
        public void LoadContentTest1()
        {
            string fileContent =
                @"{
                    ""Restaurant"": ""Luigi's Italian All You Can Eat"",
                    ""Location"": ""Brussels"",
                    ""Score"": ""7.5"",
                    ""Type"": ""Italian""
                 }";

            string fileName = "JsonFileTest1.json";

            // Write to file.
            System.IO.File.WriteAllText(fileName, fileContent);

            // Read from file.
            JsonFile file = new(fileName);
            JsonDocument readContent = file.LoadContent();

            // Assert original and read values are the same. 
            readContent.RootElement.TryGetProperty("Restaurant", out JsonElement restaurant);
            readContent.RootElement.TryGetProperty("Location", out JsonElement location);
            readContent.RootElement.TryGetProperty("Type", out JsonElement type);
            Assert.AreEqual("Luigi's Italian All You Can Eat", restaurant.GetString());
            Assert.AreEqual("Brussels", location.GetString());
            Assert.AreEqual("Italian", type.GetString());
        }
    }
}
