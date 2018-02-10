using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;

namespace Configurator.Tests.Unit
{
    [TestFixture]
    public class MainViewControllerTest
    {
        private IMainView m_view;
        private MainViewController m_controller;

        #region Setup And TearDown

        [SetUp]
        public void Setup()
        {
            m_view = A.Fake<IMainView>();
            m_controller = new MainViewController(m_view);
        }

        #endregion

        [Test]
        public void ShouldSetControllerOnView()
        {
            A.CallTo(() => m_view.SetController(m_controller)).MustHaveHappened();
        }
    }
}
