using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Xml;

class Json
{
    private string jsonContent = File.ReadAllText("CLONED.json");

    public void ChooseFormatJSON()
    {
        Console.WriteLine("Choose format to convert from json\n" +
                          "1. JSON -> CSV\n" +
                          "2. JSON -> XML");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();

        ConverterJSON(choice);
    }

    private void ConverterJSON(char choice)
    {
        switch (choice)
        {
            case '1':
                string csvFilePath = "CONVERTED(JSON).csv";
                JArray jsonArray = JArray.Parse(jsonContent);

                List<string> headers = new List<string>();
                foreach (JObject jsonObject in jsonArray)
                {
                    foreach (var property in jsonObject.Properties())
                    {
                        string header = property.Name;
                        if (!headers.Contains(header))
                        {
                            headers.Add(header);
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(csvFilePath))
                {
                    writer.WriteLine(string.Join(",", headers));

                    foreach (JObject jsonObject in jsonArray)
                    {
                        List<string> rowData = new List<string>();

                        foreach (string header in headers)
                        {
                            JToken value;
                            if (jsonObject.TryGetValue(header, out value))
                            {
                                rowData.Add(value.ToString());
                            }
                            else
                            {
                                rowData.Add("");
                            }
                        }

                        writer.WriteLine(string.Join(",", rowData));
                    }
                }
                Console.WriteLine("Converted successfully");

                break;
            case '2':
                jsonContent = $"{{ \"root\": {jsonContent} }}";
                XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonContent, "root");
                doc.Save("CONVERTED(JSON).xml");
                Console.WriteLine("Converted successfully");
                break;
            default: Console.WriteLine("Wrong target format."); break;
        }
    }

}