using System.IO;

namespace BubbleGit.Runner.IssueTracker
{
    public interface ILastIssue
    {
        void Save(string issue);
        string Get();
    }

    public class LastIssue : ILastIssue
    {
        private readonly string m_lastIssueFile;

        public LastIssue(string repositoryDirectory)
        {
            m_lastIssueFile = Path.Combine(repositoryDirectory, @".git\gitarmor\issuetracker\lastissue");
        }

        public void Save(string issue)
        {
            var directory = Path.GetDirectoryName(m_lastIssueFile);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (File.Exists(m_lastIssueFile))
                File.Delete(m_lastIssueFile);

            using (var stream = File.CreateText(m_lastIssueFile))
            {
                stream.WriteLine(issue);
            }
        }

        public string Get()
        {
            if (!File.Exists(m_lastIssueFile))
                return string.Empty;

            var issue = string.Empty;

            using (var stream = File.OpenText(m_lastIssueFile))
            {
                issue = stream.ReadLine();
            }

            return issue;
        }
    }
}