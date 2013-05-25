using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using XMLNativeSerializerSample.util.File;

namespace XMLNativeSerializerSample.Test.xml.File
{
    [TestFixture]
    internal class TestFileUtils
    {
        private const string TestTextToWrite = "<text>This is a text to test purpose.</text>";

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void WriteToFileTest()
        {
            MemoryStream testStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(TestTextToWrite));
            Assert.DoesNotThrow(delegate { FileUtils.WriteToFile("TestFile.xml", testStream); },
                "An exception occurs, the file cannot be writed.");
        }
    }
}
