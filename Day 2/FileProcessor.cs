 // Define an abstraction for reading files
    public interface IFileReader
    {
        string ReadFile(string filePath);
    }

    // Define an abstraction for writing files
    public interface IFileWriter
    {
        void WriteFile(string filePath, string content);
    }

    // Implement concrete classes for reading and writing files
    public class FileReader : IFileReader
    {
        public string ReadFile(string filePath)
        {
            // Implementation to read file content
            return "File content";
        }
    }

    public class FileWriter : IFileWriter
    {
        public void WriteFile(string filePath, string content)
        {
            // Implementation to write file content
        }
    }

    // Modify FileProcessor to depend on abstractions rather than concrete implementations
    public class FileProcessor
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        public FileProcessor(IFileReader fileReader, IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }

        public void ProcessFile(string inputFilePath, string outputFilePath)
        {
            string fileContent = _fileReader.ReadFile(inputFilePath);
            _fileWriter.WriteFile(outputFilePath, fileContent);
        }
    }