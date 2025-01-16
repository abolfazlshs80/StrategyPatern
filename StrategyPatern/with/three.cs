using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class three
    {
        public three()
        {
        FileCompressor fileCompressor = new();

        fileCompressor.SetCompressionStrategy(new ZipCompression());
        fileCompressor.CompressFile("example.txt"); // Output: Compressing example.txt using Zip.

        fileCompressor.SetCompressionStrategy(new RarCompression());
        fileCompressor.CompressFile("example.txt"); // Output: Compressing example.txt using Rar.

    }
}
public interface ICompressionStrategy
{
    void Compress(string fileName);
}

public class ZipCompression : ICompressionStrategy
{
    public void Compress(string fileName)
    {
        Console.WriteLine($"Compressing {fileName} using Zip.");
    }
}

public class RarCompression : ICompressionStrategy
{
    public void Compress(string fileName)
    {
        Console.WriteLine($"Compressing {fileName} using Rar.");
    }
}
public class FileCompressor
{
    private ICompressionStrategy _compressionStrategy;

    public void SetCompressionStrategy(ICompressionStrategy compressionStrategy)
    {
        _compressionStrategy = compressionStrategy;
    }

    public void CompressFile(string fileName)
    {
        _compressionStrategy.Compress(fileName);
    }
}
