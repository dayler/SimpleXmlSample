using System.IO;
using NUnit.Framework;
using XMLNativeSerializerSample.Domain;
using XMLNativeSerializerSample.util.File;

namespace XMLNativeSerializerSample.Test.Domain
{
    [TestFixture]
    class PersonTest
    {
        private const string TestFirstName = "pepito";
        private const string TestLastName = "sanchez";
        private const string TestAddress = "B/San Gabriel SN";
        private const string TestCity = "Cochabamba";
        private const int TestAge = 25;

        private Person personToTest;

        [SetUp]
        public void Setup()
        {
            personToTest = new Person(TestFirstName, TestLastName, TestAge, TestAddress, TestCity);
        }

        [TearDown]
        public void TearDown()
        {
            personToTest = null;
        }

        [Test]
        public void TestPersonId()
        {
            Assert.NotNull(personToTest.PersonId, "The personID is null.");
        }

        [Test]
        public void FirstName()
        {
            Assert.NotNull(personToTest.FirstName, "FirstName is null.");
            Assert.AreEqual(TestFirstName, personToTest.FirstName, "FirstName is not the expected.");
        }

        [Test]
        public void LastName()
        {
            Assert.NotNull(personToTest.LastName, "LastName is null.");
            Assert.AreEqual(TestLastName, personToTest.LastName, "LastName is not the expected.");
        }

        [Test]
        public void Age()
        {
            Assert.AreEqual(TestAge, personToTest.Age, "The Age is not the expected.");
        }

        [Test]
        public void Address()
        {
            Assert.NotNull(personToTest.Address, "Address is null.");
            Assert.AreEqual(TestAddress, personToTest.Address, "Address is not the expected.");
        }

        [Test]
        public void City()
        {
            Assert.NotNull(personToTest.City, "City is null.");
            Assert.AreEqual(TestCity, personToTest.City, "City is not the expected.");
        }

        [Test]
        public void TestSerialize()
        {
            Stream testStream = new MemoryStream();
            Assert.DoesNotThrow(delegate { personToTest.Serialize(testStream); }, "An exception has been occurred.");
            Assert.NotNull(testStream, "Stream is null.");
        }

        [Test]
        public void TestSerializeToXmlFile()
        {
            Stream testStream = new MemoryStream();
            Assert.DoesNotThrow(delegate { personToTest.Serialize(testStream);}, "An exception has been occurred");
            Assert.DoesNotThrow(delegate { FileUtils.WriteToFile("PersonTest.xml", testStream); },
                "An error occurred when the serialized file is writing.");
        }

        [Test]
        public void TestDeserialize()
        {
        }
    }
}
