using System;
using System.IO;
using Sample.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileManager))]
namespace Sample.Droid
{
    public class FileManager : IFileManager
    {

        public string GetPublicStorageDir()
        {
            return Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath);
        }

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

    }
}
