using Configurator.Repository.General;
using Core.Git;
using Core.Logging;
using FakeItEasy;
using NUnit.Framework;

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
            m_controller = new GeneralViewController(m_view, m_repository, A.Fake<ILogger>());
        }

        #endregion

        #region Initialization

        [TestCase(false)]
        [TestCase(true)]
        public void ShouldInitViewStatus(bool initialized)
        {
            A.CallTo(() => m_repository.IsArmed).Returns(initialized);
            var view = A.Fake<IGeneralView>();
            var controller = new GeneralViewController(view, m_repository, A.Fake<ILogger>());

            A.CallTo(() => view.SetController(controller)).MustHaveHappened();
        }

        #endregion

        #region OnShow

        [TestCase(false)]
        [TestCase(true)]
        public void OnShow_ShouldInitViewStatus(bool initialized)
        {
            A.CallTo(() => m_repository.IsArmed).Returns(initialized);

            m_controller.OnShow();
            
            A.CallTo(() => m_view.SetRepositoryStatus(initialized)).MustHaveHappened();
        }

        #endregion

        #region InitializeRepository

        [Test]
        public void InitializeRepository_WhenRepositoryIsInitialized_ShouldDoNothing()
        {
            A.CallTo(() => m_repository.IsArmed).Returns(true);

            m_controller.InitializeRepository();

            A.CallTo(() => m_repository.Arm()).MustNotHaveHappened();
        }

        [Test]
        public void InitializeRepository_WhenRepositoryIsNotInitialized_ShouldInitializeIt()
        {
            A.CallTo(() => m_repository.IsArmed).Returns(false);

            m_controller.InitializeRepository();

            A.CallTo(() => m_repository.Arm()).MustHaveHappened();
            A.CallTo(() => m_view.SetRepositoryStatus(true)).MustHaveHappened();
        }

        #endregion
    }
}
