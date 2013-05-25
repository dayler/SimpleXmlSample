using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using XMLNativeSerializerSample.Domain;
using XMLNativeSerializerSample.util.File;

namespace XMLNativeSerializerSample.Test.Domain
{
    [TestFixture]
    class TestSimpleOrganization
    {
        private const string TestFirstName = "pepito";
        private const string TestLastName = "sanchez";
        private const string TestAddress = "B/San Gabriel SN";
        private const string TestCity = "Cochabamba";
        private const int TestAge = 25;

        private SimpleOrganization testOrganization;

        private Person personToTest01;

        private Person personToTest02;

        [SetUp]
        public void Setup()
        {
            personToTest01 = new Person(TestFirstName, TestLastName, TestAge, TestAddress, TestCity);
            personToTest02 = new Person(TestFirstName, TestLastName, TestAge, TestAddress, TestCity);
//            testOrganization = new SimpleOrganization(new Dictionary<Guid, Person>()
//                {
//                    { personToTest01.PersonId, personToTest01 },
//                    { personToTest02.PersonId, personToTest02}
//                });
            testOrganization = new SimpleOrganization(new List<Person>() { personToTest01, personToTest02});
        }

        [TearDown]
        public void TearDown()
        {
            personToTest01 = null;
            personToTest02 = null;
            testOrganization = null;
        }

        [Test]
        public void TestSerialize()
        {
            Assert.NotNull(testOrganization, "Organization is null.");
            MemoryStream stream = new MemoryStream();
            Assert.DoesNotThrow(delegate { testOrganization.Serialize(stream);},
                "An exception occurred in serialization process");
        }

        [Test]
        public void TestSerializeToXmlWriteToFile()
        {
            MemoryStream stream = new MemoryStream();
            Assert.DoesNotThrow(delegate { testOrganization.Serialize(stream); },
                "An exception occurred in serialization process");
            Assert.DoesNotThrow(delegate { FileUtils.WriteToFile("SimpleOrganization.xml", stream);});
        }
    }
}
