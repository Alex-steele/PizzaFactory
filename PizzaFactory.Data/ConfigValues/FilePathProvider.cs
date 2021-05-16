namespace PizzaFactory.Data.ConfigValues
{
    public class FilePathProvider : IFilePathProvider
    {
        public FilePathProvider(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }
    }
}
