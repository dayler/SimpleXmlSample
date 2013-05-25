using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using IXmlSerializable = XMLNativeSerializerSample.util.xml.IXmlSerializable;

namespace XMLNativeSerializerSample.Domain
{
    public class SimpleOrganization: IXmlSerializable
    {
        //private Dictionary<Guid, Person> employes = new Dictionary<Guid, Person>();
        private List<Person> employes = new List<Person>();

        public SimpleOrganization()
        {
            // No op
        }

//        public SimpleOrganization(Dictionary<Guid, Person> employes)
//        {
//            this.employes = employes;
//        }
        public SimpleOrganization(List<Person> employes)
        {
            this.employes = employes;
        }

//        public Dictionary<Guid, Person> Employes
//        {
//            get { return employes; }
//        }
        public List<Person> Employes
        {
            get { return employes; }
        }

        public void AddEmploye(Person employe)
        {
            Guid personId = employe.PersonId;

            if (employes.Contains(employe))//employes.ContainsKey(personId))
            {
                // employes[personId] = employe;
                employes.Remove(employe);
            }
            else
            {
                //employes.Add(personId, employe);
                employes.Add(employe);
            }
        }

        public void Serialize(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(GetType());
            serializer.Serialize(stream, this);
        }
    }
}
