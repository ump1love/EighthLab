class Protorype : IClone
{
    private string filepath;
    private string[] fileContent;

    public string Filepath
    {
        get { return filepath; }
        set { filepath = value; }
    }
    public string[] FileContent
    {
        get { return fileContent; }
        set { fileContent = value; }
    }
    public Protorype(string filepath, string[] fileContent)
    {
        Filepath = filepath;
        FileContent = fileContent;
    }
    public IClone Clone()
    {
        return new Protorype(Filepath, (string[])FileContent.Clone());
    }
    public void Save(string newFilePath)
    {
        File.WriteAllLines(newFilePath, FileContent);
    }
}