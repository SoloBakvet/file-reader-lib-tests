namespace FileReaderLib.Core.Tests
{
    [TestClass()]
    public class TextFileTests
    {
        [TestMethod()]
        public void LoadContentTest1()
        {
            string fileContent = "Hello world, this is a test.";
            string fileName = "TextFileTest1.txt";

            // Write to file.
            System.IO.File.WriteAllText(fileName, fileContent);

            // Read from file.
            TextFile file = new(fileName);
            string readContent = file.LoadContent();

            // Assert original and read value are the same. 
            Assert.AreEqual(fileContent, readContent);
        }

        [TestMethod()]
        public void LoadContentTest2()
        {
            string fileContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            string fileName = "TextFileTest1.txt";

            // Write to file.
            System.IO.File.WriteAllText(fileName, fileContent);

            // Read from file.
            TextFile file = new(fileName);
            string readContent = file.LoadContent();

            // Assert original and read value are the same. 
            Assert.AreEqual(fileContent, readContent);
        }
    }
}