using BubbleGit.Runner.IssueTracker;
using FakeItEasy;
using NUnit.Framework;

namespace BubbleGit.Runner.Tests.Unit.IssueTracker
{
    [TestFixture]
    public class InsertIssueControllerTest
    {
        private InsertIssueController m_controller;
        private IInsertIssueView m_view;
        private ICommitTempMessage m_commitTempMessage;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_view = A.Fake<IInsertIssueView>();
            m_commitTempMessage = A.Fake<ICommitTempMessage>();
            m_controller = new InsertIssueController(m_view, m_commitTempMessage);
        }

        #endregion

        [Test]
        public void ShouldSetControllerOnView()
        {
            A.CallTo(() => m_view.SetController(m_controller)).MustHaveHappened();
        }

        [Test]
        public void Run_ShouldShowInsertIssueDialog()
        {
            m_controller.Run();

            A.CallTo(() => m_view.ShowDialog()).MustHaveHappened();
        }

        [Test]
        public void ConfirmSelection_ShouldOverwriteCommitMessage_AndClose()
        {
            A.CallTo(() => m_view.IssueText).Returns("1243");
            A.CallTo(() => m_commitTempMessage.Read()).Returns("The commit message");

            m_controller.ConfirmSelection();

            A.CallTo(() => m_commitTempMessage.Write($"[#1243] - The commit message")).MustHaveHappened();
            A.CallTo(() => m_view.Close()).MustHaveHappened();
        }
    }
}
