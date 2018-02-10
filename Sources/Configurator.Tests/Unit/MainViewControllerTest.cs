using FakeItEasy;
using NUnit.Framework;
using Utilities.Git;

namespace Configurator.Tests.Unit
{
    [TestFixture]
    public class MainViewControllerTest
    {
        private IMainView m_view;
        private MainViewController m_controller;
        private IGitRepositoryFactory m_repositoryFactory;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_view = A.Fake<IMainView>();
            m_repositoryFactory = A.Fake<IGitRepositoryFactory>();
            m_controller = new MainViewController(m_view, m_repositoryFactory);
        }

        #endregion

        [Test]
        public void ShouldSetControllerOnView()
        {
            A.CallTo(() => m_view.SetController(m_controller)).MustHaveHappened();
        }

        [Test]
        public void WhenUserCancelRepositorySelection_ShouldDoNothing()
        {
            A.CallTo(() => m_view.GetFolderFromDialog(A<string>.Ignored, false)).Returns(null);
            
            m_controller.OpenRepository();

            A.CallTo(() => m_view.GetFolderFromDialog(A<string>.Ignored, false)).MustHaveHappened();
            A.CallTo(() => m_repositoryFactory.Create(A<string>.Ignored)).MustNotHaveHappened();
        }

        [Test]
        public void WhenRepositoryIsNotValid_ShouldNotOpenRepository_AndShowMessage()
        {
            var repoFolder = @"C:\TestRepo";
            A.CallTo(() => m_view.GetFolderFromDialog(A<string>.Ignored, false)).Returns(repoFolder);
            A.CallTo(() => m_repositoryFactory.Create(repoFolder))
                .Throws(new InvalidRepositoryException(""));

            m_controller.OpenRepository();

            A.CallTo(() => m_view.GetFolderFromDialog(A<string>.Ignored, false)).MustHaveHappened();
            A.CallTo(() => m_view.ShowMessageBox("Selected folder is not a valid git repository")).MustHaveHappened();
        }
    }
}
