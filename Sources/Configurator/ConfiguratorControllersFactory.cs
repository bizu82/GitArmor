using Configurator.Repository;
using Core.Git;
using Core.Logging;

namespace Configurator
{
    public class ConfiguratorControllersFactory : IConfiguratorControllersFactory
    {
        private readonly ILogger m_logger;

        public ConfiguratorControllersFactory(ILogger logger)
        {
            m_logger = logger;
        }

        public IRepositoryViewController CreateRepositoryViewController(IRepositoryView view, IGitRepository repository)
        {
            return new RepositoryViewController(view, repository, m_logger);
        }
    }

    public interface IConfiguratorControllersFactory
    {
        IRepositoryViewController CreateRepositoryViewController(IRepositoryView view, IGitRepository repository);
    }
}
