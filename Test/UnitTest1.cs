using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryToXmlConverter;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        string filePath = @".\testfile.pdf";
        string basePath = @".\";

        public UnitTest1()
        {
            basePath = Directory.GetCurrentDirectory();
        }

        [TestMethod]
        public void TestConvertToBase64()
        {
            var converter = new BinaryToXmlConverterHelper();
            string base64 = converter.ConvertToBase64(filePath);
            string newFileName = Path.Combine(basePath, Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".pdf");
            converter.SaveBase64AsFile(base64, newFileName);
        }

        [TestMethod]
        public void TestConvertToXmlWithBase64()
        {
            var converter = new BinaryToXmlConverterHelper();
            var xml = converter.ConvertToXmlWithBase64(filePath);
            XDocument doc = new XDocument();
            var elem = XElement.Parse(xml);
            doc.Add(elem);
            var base64 = doc.Elements("serialized_binary").Select(e => e.Value).FirstOrDefault();
            string newFileName = Path.Combine(basePath, Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".pdf");
            converter.SaveBase64AsFile(base64, newFileName);
        }
    }
}
