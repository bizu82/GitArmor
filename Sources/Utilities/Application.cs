using System.IO;

namespace Utilities
{
    public class Application : IApplication
    {
        public string GetApplicationDirectory()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }

    public interface IApplication
    {
        string GetApplicationDirectory();
    }
}
