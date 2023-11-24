class Program
{
    public static void Main()
    {
        FileClone fileClone = new FileClone();

        char mainChoice;
        do
        {
            Console.WriteLine("Enter what you want to do\n" +
                              "1. Clone file\n" +
                              "2. Convert file\n" +
                              "3. Exit");
            mainChoice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (mainChoice)
            {
                case '1':
                    fileClone.CloneFormat();
                    break;
                case '2':
                    Console.WriteLine("Enter from what format you want to convert your file(for this you need at least one clone file)\n" +
                                      "1. CSV\n" +
                                      "2. JSON\n" +
                                      "3. XML\n" +
                                      "4. Exit");
                    char convertChoice = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    switch (convertChoice)
                    {
                        case '1':
                            Csv csv = new Csv();
                            csv.ChooseFormatCSV();
                            break;
                        case '2':
                            Json json = new Json();
                            json.ChooseFormatJSON();
                            break;
                        case '3':
                            Xml xml = new Xml();
                            xml.ChooseFormatXML();
                            break;
                        case '4': break;
                        default: Console.WriteLine("Invalid file format"); break;
                    }

                    break;
                case '3': Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("Invalid main choice"); break;
            }
        } while (mainChoice != '3');
    }
}