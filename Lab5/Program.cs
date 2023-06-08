using Lab5;
using Newtonsoft.Json;
using System.Xml.Serialization;

JSONTask();

XMLTask();

static void JSONTask()
{
    string json = File.ReadAllText("E:\\University\\A_T\\A_T_Labs_NET\\Lab5\\input.json");

    // d) Deserialize JSON to POJO
    Person person = JsonConvert.DeserializeObject<Person>(json);

    // e) Change a few fields
    person.Name = "Alice";
    person.Age = 25;
    person.IsMarried = false;
    person.Address.City = "San Francisco";

    // Serialize POJO to JSON
    string outputJson = JsonConvert.SerializeObject(person, Formatting.Indented);

    // Save it to "output.json"
    File.WriteAllText("E:\\University\\A_T\\A_T_Labs_NET\\Lab5\\output.json", outputJson);

    Console.WriteLine("Serialized and saved the modified object to 'output.json'.");
}

static void XMLTask()
{
    // Read XML from "input.xml"
    string xml = File.ReadAllText("E:\\University\\A_T\\A_T_Labs_NET\\Lab5\\input.xml");

    // Deserialize XML to POJO
    Person person;
    using (StringReader reader = new StringReader(xml))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        person = (Person)serializer.Deserialize(reader);
    }

    // Change a few fields
    person.Name = "Alice";
    person.Age = 25;
    person.IsMarried = false;
    person.Address.City = "San Francisco";

    // Serialize POJO to XML
    string outputXml;
    using (StringWriter writer = new StringWriter())
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        serializer.Serialize(writer, person);
        outputXml = writer.ToString();
    }

    // Save it to "output.xml"
    File.WriteAllText("E:\\University\\A_T\\A_T_Labs_NET\\Lab5\\output.xml", outputXml);

    Console.WriteLine("Serialized and saved the modified object to 'output.xml'.");
}