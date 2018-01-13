using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Unity.NLog;

namespace NLog.Tests
{
    [TestClass]
    public class NLogFixture
    {
        private static IUnityContainer _container;
        private LoggedType _instance;

        [TestInitialize]
        public void TestSetup()
        {
            _container = new UnityContainer();
            _container.AddNewExtension<NLogExtension>();
            _instance = _container.Resolve<LoggedType>();
        }

        [TestMethod]
        public void NLog_can_resolve_test_type()
        {
            Assert.IsNotNull(_instance);
            Assert.IsNotNull(_instance.Logger);
        }

        [TestMethod]
        public void NLog_same_name()
        {
            Assert.AreSame(LogManager.GetLogger(typeof(LoggedType).FullName), 
                           _instance.Logger);
        }

        public class LoggedType
        {
            public LoggedType(ILogger log)
            {
                Logger = log;
            }

            public ILogger Logger { get; }
        }
    }
}
