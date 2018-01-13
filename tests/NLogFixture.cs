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
            Assert.IsNotNull(_instance.ResolvedLogger);
            Assert.IsNotNull(_instance.StaticLogger);
        }

        [TestMethod]
        public void NLog_same_name()
        {
            Assert.AreSame(_instance.ResolvedLogger, _instance.StaticLogger);
        }

        public class LoggedType
        {
            public LoggedType(ILogger log)
            {
                ResolvedLogger = log;
                StaticLogger = LogManager.GetCurrentClassLogger();
            }

            public ILogger ResolvedLogger { get; }


            public ILogger StaticLogger { get; }
        }
    }
}
