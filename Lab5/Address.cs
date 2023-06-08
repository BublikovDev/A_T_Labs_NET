using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab5
{
    [Serializable]
    [XmlRoot(ElementName = "address")]
    public class Address
    {

        [XmlElement(ElementName = "city")]
        public string City { get; set; }

        [XmlElement(ElementName = "state")]
        public string State { get; set; }
    }
}
