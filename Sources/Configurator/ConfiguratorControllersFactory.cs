using Configurator.Repository;
using Utilities.Git;

namespace Configurator
{
    public class ConfiguratorControllersFactory : IConfiguratorControllersFactory
    {
        public IRepositoryViewController CreateRepositoryViewController(IRepositoryView view, IGitRepository repository)
        {
            return new RepositoryViewController(view, repository);
        }
    }

    public interface IConfiguratorControllersFactory
    {
        IRepositoryViewController CreateRepositoryViewController(IRepositoryView view, IGitRepository repository);
    }
}
