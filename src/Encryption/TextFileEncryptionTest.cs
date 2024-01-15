using FileReaderLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderLib.Encryption.Tests
{
    [TestClass()]
    public class TextFileEncryptionTests
    {
        [TestMethod()]
        public void ReverseEncryptionTest()
        {
            string fileContent = "Hello world, this is a test.";
            string fileName = "TextFileTest1.txt";
            ReverseEncryptionStrategy encryptionStrategy = new();

            // Write to file.
            byte[] encryptedContent = encryptionStrategy.Encrypt(Encoding.UTF8.GetBytes(fileContent));
            System.IO.File.WriteAllBytes(fileName, encryptedContent);

            // Read from file.
            TextFile file = new(fileName);
            file.SetEncryptionStrategy(encryptionStrategy);
            string readContent = file.LoadContent();

            // Assert original and read value are the same. 
            Assert.AreEqual(fileContent, readContent);
        }

        [TestMethod()]
        public void AesEncryptionTest()
        {
            string fileContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            string fileName = "TextFileTest1.txt";
            AesEncryptionStrategy encryptionStrategy = new();

            // Write to file.
            byte[] encryptedContent = encryptionStrategy.Encrypt(Encoding.UTF8.GetBytes(fileContent));
            System.IO.File.WriteAllBytes(fileName, encryptedContent);

            // Read from file.
            TextFile file = new(fileName);
            file.SetEncryptionStrategy(encryptionStrategy);
            string readContent = file.LoadContent();

            // Assert original and read value are the same. 
            Assert.AreEqual(fileContent, readContent);
        }
    }
}
