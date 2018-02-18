using System.Collections.Generic;
using Configurator.Repository.General;
using Configurator.Repository.IssueTracker;
using Core;
using Core.Git;
using Core.Logging;
using Core.Tests;

namespace Configurator.Repository
{
    public class RepositoryViewController : UserControlController, IRepositoryViewController
    {
        private readonly Dictionary<NodeType, IUserControlController> m_nodToControllerMap = new Dictionary<NodeType, IUserControlController>();

        public RepositoryViewController(IRepositoryView view, IGitRepository repository, ILogger logger)
        {
            view.SetController(this);
            m_nodToControllerMap.Add(NodeType.General, new GeneralViewController(view.GeneralView, repository, logger));
            m_nodToControllerMap.Add(NodeType.IssueTracker, new IssueTrackerConfigController(view.IssueTrackerView, repository));
        }

        public void OnNodeChanged(NodeType nodeType)
        {
            if (m_nodToControllerMap.ContainsKey(nodeType))
                m_nodToControllerMap[nodeType].OnShow();
        }

        public override void OnShow()
        {
        }
    }

    public interface IRepositoryViewController
    {
        void OnNodeChanged(NodeType nodeType);
    }
}
