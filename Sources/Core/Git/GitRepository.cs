using System;
using System.IO;
using Utilities.FileSystem;
using Utilities.Serialization;

namespace Core.Git
{
    public class GitRepository : IGitRepository
    {
        private readonly string m_repositoryFolder;
        private readonly IFileUtilities m_files;
        private readonly IJsonSerializer m_serializer;
        private readonly IDirectoryUtilities m_dirs;

        public ICommitTempMessage CommitTempMessage { get; }

        public bool IsArmed => m_files
            .Exists(Path.Combine(m_repositoryFolder, @".git\gitarmor\config"));

        public void Arm()
        {
            if (IsArmed)
                return;

            if (!m_dirs.Exists(Path.Combine(m_repositoryFolder, @".git\gitarmor")))
                m_dirs.CreateDirectory(Path.Combine(m_repositoryFolder, @".git\gitarmor"));

            var jsonConfig = m_serializer.Serialize(new GitArmorRepositoryConfig());
            using (var fw = m_files.CreateText(Path.Combine(m_repositoryFolder, @".git\gitarmor\config")))
            {
                fw.WriteLine(jsonConfig);
            }
        }

        public GitRepository(string repositoryFolder, 
            IFileUtilities files, 
            IJsonSerializer serializer,
            IDirectoryUtilities dirs)
        {
            m_repositoryFolder = repositoryFolder;
            m_files = files;
            m_serializer = serializer;
            m_dirs = dirs;
            CommitTempMessage = new CommitTempMessage(repositoryFolder);
        }
    }

    public interface IGitRepository
    {
        ICommitTempMessage CommitTempMessage { get; }
        bool IsArmed { get; }
        void Arm();
    }

    public interface IGitRepositoryFactory
    {
        IGitRepository Create(string repositoryFolder);
    }

    public class GitRepositoryFactory : IGitRepositoryFactory
    {
        public IGitRepository Create(string repositoryFolder)
        {
            if (!Directory.Exists(Path.Combine(repositoryFolder, ".git")))
                throw new InvalidRepositoryException(".git directory does not exists");

            return new GitRepository(repositoryFolder, new FileUtilities(), new JsonSerializer(), new DirectoryUtilities());
        }
    }

    public class InvalidRepositoryException : Exception
    {
        public InvalidRepositoryException(string message) : base(message)
        {
        }
    }
}
