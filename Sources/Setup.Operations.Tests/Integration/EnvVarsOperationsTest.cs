using System;
using FluentAssertions;
using NUnit.Framework;

namespace Setup.Operations.Tests.Integration
{
    [TestFixture]
    public class EnvVarsOperationsTest
    {
        private EnvVarsOperations m_operations;
        private string m_originalPath;
        private EnvironmentVariableTarget m_targetEnv = EnvironmentVariableTarget.Machine;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_operations = new EnvVarsOperations();
            m_originalPath = Environment.GetEnvironmentVariable("PATH", m_targetEnv);
        }

        [TearDown]
        public void TearDown()
        {
            Environment.SetEnvironmentVariable("PATH", m_originalPath, m_targetEnv);
        }

        #endregion

        [Test]
        public void ShouldAddFolderToPath()
        {
            m_operations.AddFolderToPath(@"C:\MyTestPath");

            Environment.GetEnvironmentVariable("PATH", m_targetEnv).Should().EndWith(@"C:\MyTestPath");
        }
    }
}
