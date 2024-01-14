using System.Xml;

namespace FileReaderLib.Core.Tests
{
    [TestClass()]
    public class XMLFileTests
    {
        [TestMethod()]
        public void LoadContentTest1()
        {
            string fileContent =
                @"<menu>
                    <dish name=""Chicken breasts with rice"" price=""25"" />
                    <dish name=""Pancakes"" price=""16"" />
                    <dish name=""Beef stew with fries"" price=""22""  />
                  </menu>";

            string fileName = "XmlFileTest1.xml";

            // Write to file.
            System.IO.File.WriteAllText(fileName, fileContent);

            // Read from file.
            XmlFile file = new(fileName);
            XmlDocument readContent = file.LoadContent();

            // Assert original and read values are the same. 
            Assert.AreEqual("menu", readContent.FirstChild.Name );
            Assert.AreEqual("dish", readContent.FirstChild.LastChild.Name);
            Assert.AreEqual("Beef stew with fries", readContent.FirstChild.LastChild.Attributes.GetNamedItem("name").Value);
            Assert.AreEqual("22", readContent.FirstChild.LastChild.Attributes.GetNamedItem("price").Value);
        }
   
        [TestMethod()]
        public void LoadContentTest2()
        {
            string fileContent =
                @"<movies>
                    <movie name=""Lord of the Rings: The Fellowship of the Ring"" director=""Peter Jackson"" score=""8.9"" />
                    <movie name=""Titanic"" director=""James Cameron"" score=""7.9"" />
                </movies>";

            string fileName = "XmlFileTest2.xml";

            // Write to file.
            System.IO.File.WriteAllText(fileName, fileContent);

            // Read from file.
            XmlFile file = new(fileName);
            XmlDocument readContent = file.LoadContent();

            // Assert original and read values are the same. 
            Assert.AreEqual("movies", readContent.FirstChild.Name);
            Assert.AreEqual("movie", readContent.FirstChild.LastChild.Name);
            Assert.AreEqual("Lord of the Rings: The Fellowship of the Ring", readContent.FirstChild.FirstChild.Attributes.GetNamedItem("name").Value);
            Assert.AreEqual("Peter Jackson", readContent.FirstChild.FirstChild.Attributes.GetNamedItem("director").Value);
            Assert.AreEqual("8.9", readContent.FirstChild.FirstChild.Attributes.GetNamedItem("score").Value);
        }
    }
}
