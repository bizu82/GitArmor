using System.IO;
using Core.Git;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Utilities;
using Utilities.FileSystem;

namespace Core.Tests
{
    [TestFixture]
    public class GitRepositoryTests
    {
        private string m_repositoryFolder = @"C:\Repo";
        private IFileUtilities m_fs;
        private GitRepository m_repository;
        private IApplication m_app;
        private IGitArmorRepositoryConfigFactory m_repoConfigFactory;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_repoConfigFactory = A.Fake<IGitArmorRepositoryConfigFactory>();
            m_fs = A.Fake<IFileUtilities>();
            m_app = A.Fake<IApplication>();
            m_repository = new GitRepository(m_repositoryFolder, m_fs, m_app, m_repoConfigFactory);
        }

        #endregion

        #region Arm

        [Test]
        public void Arm_WhenIsAlreadyArmed_ShouldDoNothing()
        {
            var configPath = Path.Combine(m_repositoryFolder, @".git\gitarmor\config");
            A.CallTo(() => m_fs.Exists(configPath)).Returns(true);

            m_repository.Arm();

            A.CallTo(() => m_repoConfigFactory.LoadOrCreate(A<string>.Ignored))
                .MustNotHaveHappened();
        }

        [Test]
        public void Arm_WhenIsNotArmed_AndHooksAlreadyExists_ShouldThrowException()
        {
            var configPath = Path.Combine(m_repositoryFolder, @".git\gitarmor\config");
            var preCommitHookPath = Path.Combine(m_repositoryFolder, @".git\hooks\pre-commit");
            A.CallTo(() => m_fs.Exists(configPath)).Returns(false);
            A.CallTo(() => m_fs.Exists(preCommitHookPath)).Returns(true);

            m_repository.Invoking(r => r.Arm()).Should().Throw<HooksAlreadyExistsException>();
        }


        [Test]
        public void Arm_WhenIsNotArmed_ShouldArmIt()
        {
            var configPath = Path.Combine(m_repositoryFolder, @".git\gitarmor\config");
            var preCommitHookPath = Path.Combine(m_repositoryFolder, @".git\hooks\pre-commit");
            A.CallTo(() => m_fs.Exists(configPath)).Returns(false);
            A.CallTo(() => m_fs.Exists(preCommitHookPath)).Returns(false);
            A.CallTo(() => m_app.GetApplicationDirectory()).Returns(@"C:\AppPath");

            m_repository.Arm();

            A.CallTo(() => m_repoConfigFactory.LoadOrCreate(m_repositoryFolder)).MustHaveHappened();
            A.CallTo(() => m_fs.Copy(@"C:\AppPath\Hooks\pre-commit", preCommitHookPath, false)).MustHaveHappened();
        }

        #endregion
    }
}
