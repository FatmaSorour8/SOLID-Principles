namespace DependencyInversionPrinciple
{
    // Define an interface for file reading
    public interface IFileReader
    {
        string ReadFile(string filePath);
    }

    // Define an interface for file writing
    public interface IFileWriter
    {
        void WriteFile(string filePath, string content);
    }

    // FileProcessor class depends on abstractions (interfaces) instead of concrete implementations
    public class FileProcessor
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        // Constructor injection to inject dependencies
        public FileProcessor(IFileReader fileReader, IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }

        public void ProcessFile(string inputFilePath, string outputFilePath)
        {
            string fileContent = _fileReader.ReadFile(inputFilePath);
            // Process the file content
            _fileWriter.WriteFile(outputFilePath, fileContent);
        }
    }

    // Implementations of the interfaces
    public class FileReader : IFileReader
    {
        public string ReadFile(string filePath)
        {
            // Code to read file content
            return "File content";
        }
    }

    public class FileWriter : IFileWriter
    {
        public void WriteFile(string filePath, string content)
        {
            // Code to write file content
        }
    }



    internal class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
