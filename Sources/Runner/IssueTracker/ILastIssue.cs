using System.IO;
using Utilities.FileSystem;

namespace Runner.IssueTracker
{
    public interface ILastIssue
    {
        void Save(string issue);
        string Get();
    }

    public class LastIssue : ILastIssue
    {
        private readonly IFileUtilities m_fileUtilities;
        private readonly IDirectoryUtilities m_directoryUtilities;
        private readonly string m_lastIssueFile;

        public LastIssue(string repositoryDirectory, IFileUtilities fileUtilities, IDirectoryUtilities directoryUtilities)
        {
            m_fileUtilities = fileUtilities;
            m_directoryUtilities = directoryUtilities;
            m_lastIssueFile = Path.Combine(repositoryDirectory, @".git\gitarmor\issuetracker\lastissue");
        }

        public void Save(string issue)
        {
            var directory = Path.GetDirectoryName(m_lastIssueFile);

            if (!m_directoryUtilities.Exists(directory))
                m_directoryUtilities.CreateDirectory(directory);

            if (m_fileUtilities.Exists(m_lastIssueFile))
                m_fileUtilities.Delete(m_lastIssueFile);

            using (var stream = m_fileUtilities.CreateText(m_lastIssueFile))
            {
                stream.WriteLine(issue);
            }
        }

        public string Get()
        {
            if (!m_fileUtilities.Exists(m_lastIssueFile))
                return string.Empty;

            var issue = string.Empty;

            using (var stream = m_fileUtilities.OpenText(m_lastIssueFile))
            {
                issue = stream.ReadLine();
            }

            return issue;
        }
    }
}