namespace FileReaderLib.Core.Tests
{
    [TestClass()]
    public class FileTests
    {
        [TestMethod()]
        public void LoadContentTest1()
        {
            byte[] fileContent = [5, 8, 9, 10];
            string fileName = "FileTest1.txt";

            // Write to file.
            System.IO.File.WriteAllBytes(fileName, fileContent);

            // Read from file.
            File file = new (fileName);
            byte[] readContent = file.LoadContent();
             
            // Assert original and read values are the same. 
            CollectionAssert.AreEqual(fileContent, readContent);
        }

        [TestMethod()]
        public void LoadContentTest2()
        {
            byte[] fileContent = [1, 2, 3, 4, 240, 60, 80, 9,];
            string fileName = "FileTest2.txt";

            // Write to file.
            System.IO.File.WriteAllBytes(fileName, fileContent);

            // Read from file.
            File file = new (fileName);
            byte[] readContent = file.LoadContent();

            // Assert original and read values are the same. 
            CollectionAssert.AreEqual(fileContent, readContent);
        }
    }
}