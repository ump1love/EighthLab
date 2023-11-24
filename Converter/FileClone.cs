class FileClone
{
    public void CloneFormat()
    {
        Console.WriteLine("Enter source format: \n" +
                          "1. CSV\n" +
                          "2. JSON\n" +
                          "3. XML");

        char sourceFormat = Console.ReadKey().KeyChar;

        Console.WriteLine("\nEnter name of your file(it has to be in this folder: Converter\\bin\\Debug\\net6.0): ");
        string sourceName = Console.ReadLine();

        string extension = GetFileExtension(sourceFormat);
        string filepath = sourceName + extension;

        string[] originalContent = File.ReadAllLines(filepath);

        Protorype originalFile = new Protorype(filepath, originalContent);

        Protorype clonedFile = (Protorype)originalFile.Clone();

        clonedFile.Save("CLONED" + extension);

        Console.WriteLine("Clone successful");
    }

    private string GetFileExtension(char sourceFormat)
    {
        switch (sourceFormat)
        {
            case '1': return ".csv";
            case '2': return ".json";
            case '3': return ".xml";
            default: throw new ArgumentException("Invalid file format");
        }
    }
}