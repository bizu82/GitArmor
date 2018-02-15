using System;
using Core.Git;
using Core.Logging;

namespace Configurator.Repository.General
{
    public class GeneralViewController : IGeneralViewController
    {
        private readonly IGeneralView m_view;
        private readonly IGitRepository m_repository;
        private readonly ILogger m_logger;

        public GeneralViewController(IGeneralView view, IGitRepository repository, ILogger logger)
        {
            m_view = view;
            m_repository = repository;
            m_logger = logger;
            m_view.SetController(this);
            m_view.SetRepositoryStatus(repository.IsArmed);
        }

        public void InitializeRepository()
        {
            try
            {
                if (m_repository.IsArmed)
                    return;

                m_repository.Arm();
                m_view.SetRepositoryStatus(true);
            }
            catch (Exception e)
            {
                m_logger.Error(e);
                throw;
            }
        }
    }

    public interface IGeneralViewController
    {
        void InitializeRepository();
    }
}
