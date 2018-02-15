using Configurator.Repository;
using Core.Git;
using FakeItEasy;
using NUnit.Framework;

namespace Configurator.Tests.Unit.Repository
{
    [TestFixture]
    public class RepositoryViewControllerTest
    {
        private RepositoryViewController m_controller;
        private IRepositoryView m_view;
        private IGitRepository m_repository;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_view = A.Fake<IRepositoryView>();
            m_repository = A.Fake<IGitRepository>();
            m_controller = new RepositoryViewController(m_view, m_repository);
        }

        #endregion

        [Test]
        public void ShouldSetControllerOnView()
        {
            A.CallTo(() => m_view.SetController(m_controller)).MustHaveHappened();
        }
    }
}
