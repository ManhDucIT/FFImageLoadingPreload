using System;
namespace Sample
{
    public interface IFileManager
    {

        string GetPublicStorageDir();

        bool FileExists(string filePath);

    }
}
