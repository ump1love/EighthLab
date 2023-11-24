using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

class Csv
{
    private static string csvFilePath = "CLONED.csv";

    public void ChooseFormatCSV()
    {
        Console.WriteLine("Choose format to convert from json\n" +
                          "1. CSV -> JSON\n" +
                          "2. CSV -> XML");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();

        ConverterCSV(choice);
    }

    private void ConverterCSV(char choice)
    {
        switch (choice)
        {
            case '1':
                string jsonFilePath = "CONVERTED(CSV).json";
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<dynamic>().ToList();

                    string jsonString = JsonConvert.SerializeObject(records, Formatting.Indented);

                    File.WriteAllText(jsonFilePath, jsonString);
                }
                Console.WriteLine("Converted successfully");
                break;
            case '2':
                string xmlFilePath = "CONVERTED(CSV).xml";
                DataTable dataTable = new DataTable("Data");

                using (StreamReader reader = new StreamReader(csvFilePath))
                {
                    string[] headers = reader.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        string columnName = header.Trim().Replace(" ", "_");
                        dataTable.Columns.Add(columnName);
                    }

                    while (!reader.EndOfStream)
                    {
                        string[] rows = reader.ReadLine().Split(',');
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < headers.Length; i++)
                        {
                            dataRow[i] = rows[i].Trim();
                        }

                        dataTable.Rows.Add(dataRow);
                    }
                }

                using (XmlWriter writer = XmlWriter.Create(xmlFilePath))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement(dataTable.TableName);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        writer.WriteStartElement("Row");

                        foreach (DataColumn col in dataTable.Columns)
                        {
                            string elementName = col.ColumnName.Replace(" ", "_");
                            writer.WriteStartElement(elementName);
                            writer.WriteValue(row[col]);
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                Console.WriteLine("Converted successfully");
                break;
            default: Console.WriteLine("Wrong target format."); break;
        }
    }
}