using Configurator.Repository;
using Core.Git;
using Core.Logging;
using FakeItEasy;
using NUnit.Framework;

namespace Configurator.Tests.Unit
{
    [TestFixture]
    public class MainViewControllerTest
    {
        private IMainView m_view;
        private MainViewController m_controller;
        private IGitRepositoryFactory m_repositoryFactory;
        private IConfiguratorControllersFactory m_controllersFactory;
        private ILogger m_logger;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_logger = A.Fake<ILogger>();
            m_view = A.Fake<IMainView>();
            m_controllersFactory = A.Fake<IConfiguratorControllersFactory>();
            m_repositoryFactory = A.Fake<IGitRepositoryFactory>();
            m_controller = new MainViewController(m_view, m_repositoryFactory, m_controllersFactory, m_logger);
        }

        #endregion

        [Test]
        public void ShouldSetControllerOnView()
        {
            A.CallTo(() => m_view.SetController(m_controller)).MustHaveHappened();
        }

        #region OpenRepository

        [Test]
        public void OpenRepository_WhenUserCancelRepositorySelection_ShouldDoNothing()
        {
            A.CallTo(() => m_view.GetFolderFromDialog(A<string>.Ignored, false)).Returns(null);
            
            m_controller.OpenRepository();

            A.CallTo(() => m_view.GetFolderFromDialog(A<string>.Ignored, false)).MustHaveHappened();
            A.CallTo(() => m_repositoryFactory.Create(A<string>.Ignored)).MustNotHaveHappened();
        }

        [Test]
        public void OpenRepository_WhenRepositoryIsNotValid_ShouldNotOpenRepository_AndShowMessage()
        {
            var repoFolder = @"C:\TestRepo";
            A.CallTo(() => m_view.GetFolderFromDialog(A<string>.Ignored, false)).Returns(repoFolder);
            A.CallTo(() => m_repositoryFactory.Create(repoFolder))
                .Throws(new InvalidRepositoryException(""));

            m_controller.OpenRepository();

            A.CallTo(() => m_view.GetFolderFromDialog(A<string>.Ignored, false)).MustHaveHappened();
            A.CallTo(() => m_view.ShowMessageBox("Selected folder is not a valid git repository")).MustHaveHappened();
        }

        [Test]
        public void OpenRepository_WhenRepositoryIsValid_ShouldOpenIt()
        {
            const string repoFolder = @"C:\TestRepo";
            A.CallTo(() => m_view.GetFolderFromDialog(A<string>.Ignored, false)).Returns(repoFolder);
            var repository = A.Fake<IGitRepository>();
            var repositoryView = A.Fake<IRepositoryView>();
            A.CallTo(() => m_view.ShowRepositoryMask()).Returns(repositoryView);
            A.CallTo(() => m_repositoryFactory.Create(repoFolder)).Returns(repository);

            m_controller.OpenRepository();

            A.CallTo(() => m_view.GetFolderFromDialog(A<string>.Ignored, false)).MustHaveHappened();
            A.CallTo(() => m_view.ShowRepositoryMask()).MustHaveHappened();
            A.CallTo(() => m_view.ShowMessageBox("Selected folder is not a valid git repository")).MustNotHaveHappened();
            A.CallTo(() => m_controllersFactory.CreateRepositoryViewController(repositoryView, repository))
                .MustHaveHappened();
        }

        #endregion
    }
}
