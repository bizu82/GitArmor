using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.FileSystem
{
    public class DirectoryUtilities : IDirectoryUtilities
    {
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }

        public DirectoryInfo CreateDirectory(string path)
        {
            return Directory.CreateDirectory(path);
        }
    }

    public interface IDirectoryUtilities
    {
        bool Exists(string path);
        DirectoryInfo CreateDirectory(string path);
    }
}
