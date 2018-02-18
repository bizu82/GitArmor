using Configurator.Repository.IssueTracker;
using Core.Git;
using FakeItEasy;
using NUnit.Framework;

namespace Configurator.Tests.Unit.Repository.IssueTracker
{
    [TestFixture]
    public class IssueTrackerConfigControllerTest
    {
        private IIssueTrackerConfigView m_view;
        private IssueTrackerConfigController m_controller;
        private IGitRepository m_repository;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_view = A.Fake<IIssueTrackerConfigView>();
            m_repository = A.Fake<IGitRepository>();
            m_controller = new IssueTrackerConfigController(m_view, m_repository);
        }

        #endregion

        #region Initialization

        [Test]
        public void ShouldInitViewStatus()
        {
            var controller = new IssueTrackerConfigController(m_view, m_repository);

            A.CallTo(() => m_view.SetController(controller)).MustHaveHappened();
        }

        #endregion

        #region OnShow

        [TestCase(false)]
        [TestCase(true)]
        public void WhenRepositoryIsNotInitialized_ShouldDisableAllControls(bool repoIsArmed)
        {
            A.CallTo(() => m_repository.IsArmed).Returns(repoIsArmed);

            m_controller.OnShow();

            A.CallTo(() => m_view.SetEnable(repoIsArmed)).MustHaveHappened();
        }

        #endregion
    }
}
