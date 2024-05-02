using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public class FileProcessor
    {
        private FileReader _fileReader; 
        private FileWriter _fileWriter;
        public FileProcessor()
        {
            _fileReader = new FileReader(); _fileWriter = new FileWriter(); 
        }
        public void ProcessFile(string inputFilePath, string outputFilePath)
        {
            string fileContent = _fileReader.ReadFile(inputFilePath);
            //Process the file content
            _fileWriter.WriteFile(outputFilePath, fileContent);
        }
    }
    public class FileReader
    {
        public string ReadFile(string filePath)
        {
            //Code to read file content
            return "File content";
        }
    }
    public class FileWriter
    {
        public void WriteFile(string filePath, string content)
        {
            // Code to write file content 
        }
    }
}
