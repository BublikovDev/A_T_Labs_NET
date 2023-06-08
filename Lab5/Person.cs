using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab5
{
    [Serializable]
    [XmlRoot(ElementName = "person")]
    public class Person
    {

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "age")]
        public int Age { get; set; }

        [XmlElement(ElementName = "isMarried")]
        public bool IsMarried { get; set; }

        [XmlElement(ElementName = "address")]
        public Address Address { get; set; }
    }
}
