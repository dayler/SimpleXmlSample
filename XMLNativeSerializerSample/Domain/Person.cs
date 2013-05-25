using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using IXmlSerializable = XMLNativeSerializerSample.util.xml.IXmlSerializable;

namespace XMLNativeSerializerSample.Domain
{
    public class Person : IXmlSerializable
    {
        private Guid personId = Guid.Empty;

        private String firstName = String.Empty;

        private String lastName = String.Empty;

        private int age = 0;

        private String address = String.Empty;

        private String city = String.Empty;

        public Person()
        {
            // No implemented, used for serialization.
        }

        public Person(String firstName, String lastName, int age, String address, String city)
        {
            PersonId = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Address = address;
            this.City = city;
        }

        [XmlElement]
        public Guid PersonId
        {
            get { return personId; }
            set { personId = value; }
        }

        [XmlElement]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [XmlElement]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [XmlElement]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        [XmlElement]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public void Serialize(Stream stream)
        {
            //stream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8);
            XmlSerializer serializer = new XmlSerializer(GetType());
            serializer.Serialize(xmlWriter, this);
        }
    }
}
