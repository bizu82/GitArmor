using Configurator.Repository.General;
using FakeItEasy;
using NUnit.Framework;
using Utilities.Git;

namespace Configurator.Tests.Unit.Repository.General
{
    [TestFixture]
    public class GeneralViewControllerTest
    {
        private IGeneralView m_view;
        private GeneralViewController m_controller;
        private IGitRepository m_repository;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_view = A.Fake<IGeneralView>();
            m_repository = A.Fake<IGitRepository>();
            m_controller = new GeneralViewController(m_view, m_repository);
        }

        #endregion

        #region Initialization

        [TestCase(false)]
        [TestCase(true)]
        public void ShouldInitViewStatus(bool initialized)
        {
            A.CallTo(() => m_repository.IsInitialized).Returns(initialized);
            var view = A.Fake<IGeneralView>();
            var controller = new GeneralViewController(view, m_repository);

            A.CallTo(() => view.SetController(controller)).MustHaveHappened();
            A.CallTo(() => view.SetRepositoryStatus(initialized)).MustHaveHappened();
        }

        #endregion
    }
}
