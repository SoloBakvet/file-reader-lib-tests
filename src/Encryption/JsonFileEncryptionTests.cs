using FileReaderLib.Core;
using System.Text;
using System.Text.Json;

namespace FileReaderLib.Encryption.Tests
{
    [TestClass()]
    public class JsonFileEncryptionTests
    {
        [TestMethod()]
        public void ReverseEncryptionTest()
        {
            string fileContent =
                @"{
                    ""Restaurant"": ""Luigi's Italian All You Can Eat"",
                    ""Location"": ""Brussels"",
                    ""Score"": ""7.5"",
                    ""Type"": ""Italian""
                 }";

            string fileName = "JsonFileTest1.json";
            ReverseEncryptionStrategy encryptionStrategy = new();

            // Write to file.
            byte[] encryptedContent = encryptionStrategy.Encrypt(Encoding.UTF8.GetBytes(fileContent));
            System.IO.File.WriteAllBytes(fileName, encryptedContent);

            // Read from file.
            JsonFile file = new(fileName);
            file.SetEncryptionStrategy(encryptionStrategy);
            JsonDocument readContent = file.LoadContent();

            // Assert original and read values are the same. 
            readContent.RootElement.TryGetProperty("Restaurant", out JsonElement restaurant);
            readContent.RootElement.TryGetProperty("Location", out JsonElement location);
            readContent.RootElement.TryGetProperty("Type", out JsonElement type);
            Assert.AreEqual("Luigi's Italian All You Can Eat", restaurant.GetString());
            Assert.AreEqual("Brussels", location.GetString());
            Assert.AreEqual("Italian", type.GetString());
        }

        [TestMethod()]
        public void AesEncryptionTest()
        {
            string fileContent =
                @"{
                    ""Restaurant"": ""Luigi's Italian All You Can Eat"",
                    ""Location"": ""Brussels"",
                    ""Score"": ""7.5"",
                    ""Type"": ""Italian""
                 }";

            string fileName = "JsonFileTest1.json";
            AesEncryptionStrategy encryptionStrategy = new();

            // Write to file.
            byte[] encryptedContent = encryptionStrategy.Encrypt(Encoding.UTF8.GetBytes(fileContent));
            System.IO.File.WriteAllBytes(fileName, encryptedContent);

            // Read from file.
            JsonFile file = new(fileName);
            file.SetEncryptionStrategy(encryptionStrategy);
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
