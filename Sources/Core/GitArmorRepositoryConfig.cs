using System;
using System.IO;
using Newtonsoft.Json;
using Utilities.FileSystem;
using Utilities.Serialization;

namespace Core
{

    public class GitArmorRepositoryConfigFactory : IGitArmorRepositoryConfigFactory
    {
        private readonly IJsonSerializer m_serializer;
        private readonly IFileUtilities m_files;
        private readonly IDirectoryUtilities m_dirs;

        public GitArmorRepositoryConfigFactory(IJsonSerializer serializer, IFileUtilities files, IDirectoryUtilities dirs)
        {
            m_serializer = serializer;
            m_files = files;
            m_dirs = dirs;
        }

        public GitArmorRepositoryConfig LoadOrCreate(string repositoryFolder)
        {
            var configFilePath = Path.Combine(repositoryFolder, @".git\gitarmor\config");
            if (!m_files.Exists(configFilePath))
            {
                if (!m_dirs.Exists(Path.Combine(repositoryFolder, @".git\gitarmor")))
                    m_dirs.CreateDirectory(Path.Combine(repositoryFolder, @".git\gitarmor"));

                var jsonConfig = m_serializer.Serialize(new GitArmorRepositoryConfig());
                using (var fw = m_files.CreateText(configFilePath))
                {
                    fw.WriteLine(jsonConfig);
                }
            }

            string serializedJson = null;
            using (var fr = m_files.OpenText(configFilePath))
            {
                serializedJson = fr.ReadToEnd();
            }

            return m_serializer.Deserialize<GitArmorRepositoryConfig>(serializedJson);
        }
    }

    public interface IGitArmorRepositoryConfigFactory
    {
        GitArmorRepositoryConfig LoadOrCreate(string repositoryFolder);
    }

    [Serializable]
    public class GitArmorRepositoryConfig
    {
        [JsonProperty(PropertyName = "issueTracker")]
        public IssueTrackerConfig IssueTracker { get; set; }

        public GitArmorRepositoryConfig()
        {
            IssueTracker = new IssueTrackerConfig();
        }
    }

    [Serializable]
    public class IssueTrackerConfig
    {
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }
    }
}
