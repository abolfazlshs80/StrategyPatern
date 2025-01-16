using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatern.without;

    internal class three
    {
        public three()
        {
        FileCompressor fileCompressor = new();
        fileCompressor.CompressFile("example.txt", "Zip"); // Output: Compressing example.txt using Zip.
        fileCompressor.CompressFile("example.txt", "Rar"); // Output: Compressing example.txt using Rar.

    }
}
public class FileCompressor
{
    public void CompressFile(string fileName, string method)
    {
        if (method == "Zip")
        {
            Console.WriteLine($"Compressing {fileName} using Zip.");
        }
        else if (method == "Rar")
        {
            Console.WriteLine($"Compressing {fileName} using Rar.");
        }
        else
        {
            throw new ArgumentException("Invalid compression method");
        }
    }
}
