using System.IO;
using Core.Git;
using FakeItEasy;
using NUnit.Framework;
using Utilities.FileSystem;
using Utilities.Serialization;

namespace Core.Tests
{
    [TestFixture]
    public class GitRepositoryTests
    {
        private string m_repositoryFolder = @"C:\Repo";
        private IFileUtilities m_fs;
        private GitRepository m_repository;
        private IJsonSerializer m_serializer;
        private IDirectoryUtilities m_dirUtils;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_fs = A.Fake<IFileUtilities>();
            m_dirUtils = A.Fake<IDirectoryUtilities>();
            m_serializer = A.Fake<IJsonSerializer>();
            m_repository = new GitRepository(m_repositoryFolder, m_fs, m_serializer, m_dirUtils);
        }

        #endregion

        #region Arm

        [Test]
        public void Arm_WhenIsAlreadyArmed_ShouldDoNothing()
        {
            var configPath = Path.Combine(m_repositoryFolder, @".git\gitarmor\config");
            A.CallTo(() => m_fs.Exists(configPath)).Returns(true);

            m_repository.Arm();

            A.CallTo(() => m_serializer.Serialize(A<GitArmorRepositoryConfig>.Ignored))
                .MustNotHaveHappened();
        }

        [Test]
        public void Arm_WhenIsAlreadyArmed_ShouldArmIt()
        {
            var configPath = Path.Combine(m_repositoryFolder, @".git\gitarmor\config");
            A.CallTo(() => m_fs.Exists(configPath)).Returns(false);
            A.CallTo(() => m_dirUtils.Exists(Path.Combine(m_repositoryFolder, @".git\gitarmor"))).Returns(false);
            var tw = A.Fake<TextWriter>();
            A.CallTo(() => m_fs.CreateText(configPath)).Returns(tw);
            var json = "the serialized object";
            A.CallTo(() => m_serializer.Serialize(A<GitArmorRepositoryConfig>.Ignored)).Returns(json);

            m_repository.Arm();

            A.CallTo(() => m_dirUtils.CreateDirectory(Path.Combine(m_repositoryFolder, @".git\gitarmor")))
                .MustHaveHappened();
            A.CallTo(() => m_serializer.Serialize(A<GitArmorRepositoryConfig>.Ignored)).MustHaveHappened();
            A.CallTo(() => m_fs.CreateText(configPath)).MustHaveHappened();
            A.CallTo(() => tw.WriteLine(json)).MustHaveHappened();
        }

        #endregion
    }
}
