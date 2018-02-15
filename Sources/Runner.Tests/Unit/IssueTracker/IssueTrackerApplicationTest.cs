using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Runner.IssueTracker;

namespace Runner.Tests.Unit.IssueTracker
{
    [TestFixture]
    public class IssueTrackerApplicationTest
    {
        private IControllersFactory m_controllersFactory;
        private IInsertIssueController m_controller;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_controllersFactory = A.Fake<IControllersFactory>();
            m_controller = A.Fake<IInsertIssueController>();
            A.CallTo(() => m_controllersFactory.CreateInsertIssueController(null))
                .WithAnyArguments()
                .Returns(m_controller);
        }

        #endregion

        #region Run

        [Test]
        public void Run_WhenNoParametersAreGiven_ShouldThrowInvalidApplicationArgumentException()
        {
            var app = new IssueTrackerApplication(new List<string>(), m_controllersFactory);

            app.Invoking(a => a.Run()).ShouldThrow<InvalidApplicationArgumentException>()
                .Where(e => e.Message == "Repository Directory");

            A.CallTo(() => m_controllersFactory.CreateInsertIssueController(null))
                .WithAnyArguments().MustNotHaveHappened();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Run_WhenRepositoryDirectoryArgumentIsNotValid_ShouldThrowInvalidApplicationArgumentException(string repositoryDirectoryParameter)
        {
            var app = new IssueTrackerApplication(new List<string> { repositoryDirectoryParameter }, m_controllersFactory);

            app.Invoking(a => a.Run()).ShouldThrow<InvalidApplicationArgumentException>()
                .Where(e => e.Message == "Repository Directory");

            A.CallTo(() => m_controllersFactory.CreateInsertIssueController(null))
                .WithAnyArguments().MustNotHaveHappened();
        }

        [Test]
        public void Run_WhenRepositoryDirectoryArgumentIsValid_ShouldRunController()
        {
            var app = new IssueTrackerApplication(new List<string> { @"C:\Repositories\RepoTest" }, m_controllersFactory);
            
            app.Run();

            A.CallTo(() => m_controller.Run()).MustHaveHappened();
        }

        #endregion
    }
}