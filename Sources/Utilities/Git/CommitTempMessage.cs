using System.IO;

namespace Utilities.Git
{
    public interface ICommitTempMessage
    {
        string Read();
        void Write(string message);
    }

    public class CommitTempMessage : ICommitTempMessage
    {
        private readonly string m_commitMessageFilePath;

        public CommitTempMessage(string repositoryDirectory)
        {
            m_commitMessageFilePath = Path.Combine(repositoryDirectory, @".git\COMMITMESSAGE");
        }

        public string Read()
        {
            return File.ReadAllText(m_commitMessageFilePath);
        }

        public void Write(string message)
        {
            using (var file = new StreamWriter(m_commitMessageFilePath))
            {
                file.WriteLine(message);
            }
        }
    }
}