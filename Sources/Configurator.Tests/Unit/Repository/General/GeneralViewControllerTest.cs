using Configurator.Repository.General;
using FakeItEasy;
using NUnit.Framework;

namespace Configurator.Tests.Unit.Repository.General
{
    [TestFixture]
    public class GeneralViewControllerTest
    {
        private IGeneralView m_view;
        private GeneralViewController m_controller;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_view = A.Fake<IGeneralView>();
            m_controller = new GeneralViewController(m_view);
        }

        #endregion

        [Test]
        public void ShouldSetControllerOnView()
        {
            A.CallTo(() => m_view.SetController(m_controller)).MustHaveHappened();
        }
    }
}
