using System.IO;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Runner.IssueTracker;
using Utilities.FileSystem;

namespace Runner.Tests.Unit.IssueTracker
{
    [TestFixture]
    public class LastIssueTest
    {
        private readonly string m_repositoryDirectory = @"C:\RepoDir";
        private IFileUtilities m_file;
        private IDirectoryUtilities m_directory;
        private LastIssue m_lastIssue;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_file = A.Fake<IFileUtilities>();
            m_directory = A.Fake<IDirectoryUtilities>();
            m_lastIssue = new LastIssue(m_repositoryDirectory, m_file, m_directory);
        }

        #endregion

        #region Save

        [Test]
        public void Save_WhenLastIssueDirectoryDoesNotExist_ShouldCreateIt()
        {
            A.CallTo(() => m_directory.Exists($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker")).Returns(false);

            m_lastIssue.Save("123");

            A.CallTo(() => m_directory.CreateDirectory($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker"))
                .MustHaveHappened();
        }

        [Test]
        public void Save_WhenLastIssueDirectoryExists_ShouldNotCreateIt()
        {
            A.CallTo(() => m_directory.Exists($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker")).Returns(true);

            m_lastIssue.Save("123");

            A.CallTo(() => m_directory.CreateDirectory($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker"))
                .MustNotHaveHappened();
        }

        [Test]
        public void Save_WhenLastIssueFileExists_ShouldDeleteIt()
        {
            A.CallTo(() => m_file.Exists($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker\lastissue")).Returns(true);

            m_lastIssue.Save("123");

            A.CallTo(() => m_file.Delete($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker\lastissue"))
                .MustHaveHappened();
        }

        [Test]
        public void Save_WhenLastIssueFileDoesNotExists_ShouldNotDeleteIt()
        {
            A.CallTo(() => m_file.Exists($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker\lastissue")).Returns(false);

            m_lastIssue.Save("123");

            A.CallTo(() => m_file.Delete($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker\lastissue"))
                .MustNotHaveHappened();
        }

        [Test]
        public void Save_ShouldUpdateIssueIntoFile()
        {
            var streamWriter = A.Fake<TextWriter>();
            A.CallTo(() => m_file.CreateText($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker\lastissue")).Returns(streamWriter);

            m_lastIssue.Save("123");

            A.CallTo(() => streamWriter.WriteLine("123")).MustHaveHappened();
        }

        #endregion

        #region Get

        [Test]
        public void Get_WhenLastIssueFileDoesNotExist_ShouldReturnEmptyString()
        {
            A.CallTo(() => m_file.Exists($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker\lastissue")).Returns(false);

            m_lastIssue.Get().Should().Be("");
        }

        [Test]
        public void Get_WhenLastIssueFileExists_ShouldReadLastIssueFromIt()
        {
            A.CallTo(() => m_file.Exists($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker\lastissue")).Returns(true);
            var streamReader = A.Fake<TextReader>();
            A.CallTo(() => streamReader.ReadLine()).Returns("567");
            A.CallTo(() => m_file.OpenText($@"{m_repositoryDirectory}\.git\gitarmor\issuetracker\lastissue")).Returns(streamReader);

            m_lastIssue.Get().Should().Be("567");
        }

        #endregion
    }
}