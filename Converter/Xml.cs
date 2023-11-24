using CsvHelper;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using System.Xml;

class Xml
{
    public void ChooseFormatXML()
    {
        Console.WriteLine("Choose format to convert from xml\n" +
                          "1. XML -> CSV\n" +
                          "2. XML -> JSON");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();

        ConverterXML(choice);
    }
    private void ConverterXML(char choice)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("CLONED.xml");

        switch (choice)
        {
            case '1':
                using (StreamWriter writer = new StreamWriter("CONVERTER(XML).csv"))
                {
                    XmlNodeList headers = doc.SelectNodes("//item[1]/*");
                    writer.WriteLine(string.Join(",", GetNodeValues(headers)));

                    XmlNodeList items = doc.SelectNodes("//item");
                    foreach (XmlNode item in items)
                    {
                        XmlNodeList values = item.SelectNodes("*");
                        writer.WriteLine(string.Join(",", GetNodeValues(values)));
                    }
                }
                static string[] GetNodeValues(XmlNodeList nodes)
                {
                    string[] values = new string[nodes.Count];
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        values[i] = nodes[i].InnerText;
                    }
                    return values;
                }
                Console.WriteLine("Converted successfully");
                break;
            case '2':
                string jsonContent = JsonConvert.SerializeXmlNode(doc);
                File.WriteAllText("CONVERTED(XML).json", jsonContent);
                Console.WriteLine("Converted successfully");
                break;
            default:
                Console.WriteLine("Wrong target format.");
                break;
        }
    }
}