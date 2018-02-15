using System;
using Newtonsoft.Json;

namespace Core
{
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
