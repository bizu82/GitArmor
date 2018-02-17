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
            catch (HooksAlreadyExistsException e)
            {
                m_logger.Error(e);
                m_view.ShowMessageBox("This repository cannot be armed because git hooks are already defined");
            }
            catch (Exception e)
            {
                m_logger.Error(e);
                m_view.ShowMessageBox("An error has occurred arming repository");
            }
        }
    }

    public interface IGeneralViewController
    {
        void InitializeRepository();
    }
}
