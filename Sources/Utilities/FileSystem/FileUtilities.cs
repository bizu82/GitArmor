using System.IO;

namespace Utilities.FileSystem
{
    public class FileUtilities : IFileUtilities
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public void Delete(string path)
        {
            File.Delete(path);
        }

        public TextWriter CreateText(string path)
        {
            return File.CreateText(path);
        }

        public TextReader OpenText(string path)
        {
            return File.OpenText(path);
        }

        public void Copy(string sourceFileName, string destFileName, bool overwrite = false)
        {
            File.Copy(sourceFileName, destFileName, overwrite);
        }
    }

    public interface IFileUtilities
    {
        bool Exists(string path);
        void Delete(string path);
        TextWriter CreateText(string path);
        TextReader OpenText(string path);
        void Copy(string sourceFileName, string destFileName, bool overwrite = false);
    }
}
