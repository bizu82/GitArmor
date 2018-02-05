﻿using System.Windows.Forms;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Runner.IssueTracker;
using Utilities.Forms;

namespace Runner.Tests.Unit.IssueTracker
{
    [TestFixture]
    public class InsertIssueControllerTest
    {
        private InsertIssueController m_controller;
        private IInsertIssueView m_view;
        private ICommitTempMessage m_commitTempMessage;
        private ILastIssue m_lastIssue;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_view = A.Fake<IInsertIssueView>();
            m_lastIssue = A.Fake<ILastIssue>();
            m_commitTempMessage = A.Fake<ICommitTempMessage>();
            m_controller = new InsertIssueController(m_view, m_commitTempMessage, m_lastIssue);
        }

        #endregion

        [Test]
        public void ShouldSetControllerOnView()
        {
            A.CallTo(() => m_view.SetController(m_controller)).MustHaveHappened();
        }

        [Test]
        public void Run_ShouldLoadLastIssue_AndShowInsertIssueDialog()
        {
            A.CallTo(() => m_lastIssue.Get()).Returns("1234");

            m_controller.Run();

            m_view.IssueText.Should().Be("1234");
            A.CallTo(() => m_view.ShowDialog()).MustHaveHappened();
        }

        [Test]
        public void ConfirmSelection_ShouldOverwriteCommitMessage_SaveLastIssue_AndClose()
        {
            A.CallTo(() => m_view.IssueText).Returns("1243");
            A.CallTo(() => m_commitTempMessage.Read()).Returns("The commit message");

            m_controller.ConfirmSelection();

            A.CallTo(() => m_commitTempMessage.Write("[#1243] - The commit message")).MustHaveHappened();
            A.CallTo(() => m_view.Close()).MustHaveHappened();
            A.CallTo(() => m_lastIssue.Save("1243")).MustHaveHappened();
        }

        [Test]
        public void OnClosing_ShouldSkipIfUserDoNotConfirm()
        {
            A.CallTo(() => m_view.ShowMessageBox(@"Are you sure you want to commit without an issue number?", @"WARNING",
                MessageBoxButtons.YesNo)).Returns(DialogResult.No);
            var e = A.Fake<IFormClosingEventArgs>();

            m_controller.OnClosing(e);

            A.CallTo(() => e.Cancel()).MustHaveHappened();
        }

        [Test]
        public void OnClosing_ShouldNotSkipIfUserConfirm()
        {
            A.CallTo(() => m_view.ShowMessageBox(@"Are you sure you want to commit without an issue number?", @"WARNING",
                MessageBoxButtons.YesNo)).Returns(DialogResult.Yes);
            var e = A.Fake<IFormClosingEventArgs>();

            m_controller.OnClosing(e);

            A.CallTo(() => e.Cancel()).MustNotHaveHappened();
        }

        [Test]
        public void OnClosing_WhenIssueIsNotBeInserted_ShouldShowConfirmation()
        {
            var e = A.Fake<IFormClosingEventArgs>();

            m_controller.OnClosing(e);

            A.CallTo(() => m_view.ShowMessageBox(@"Are you sure you want to commit without an issue number?",
                @"WARNING", MessageBoxButtons.YesNo)).MustHaveHappened();
        }


        [Test]
        public void OnClosing_WhenIssueHasBeenInserted_ShouldNotShowConfirmation()
        {
            m_controller.ConfirmSelection();
            var e = A.Fake<IFormClosingEventArgs>();

            m_controller.OnClosing(e);

            A.CallTo(() => m_view.ShowMessageBox(@"Are you sure you want to commit without an issue number?",
                @"WARNING", MessageBoxButtons.YesNo)).MustNotHaveHappened();
        }
    }
}
