using Autofac;
using SRC.WindowsService.GenericService.ServiceLibs.Test.TestTasks;

namespace SRC.WindowsService.GenericService.ServiceLibs.Test
{
    [System.ComponentModel.Description("SRC Test Windows Servisi")]
    public class TestService : BaseService
    {
        private IContainer _container;

        public TestService()
        {
            _container = IocContainerConfig.BuildIocContainer(ServiceName);
            //TODO: Register IOC
        }

        protected override void OnStart(string[] args)
        {
            StartService(args);
        }

        protected override void OnStop()
        {
            StopService();
        }

        public void StartService(string[] args)
        {
            _container.Resolve<ITestTask>().Process();
            //TODO: Start Operations
        }

        public void StopService()
        {
            //TODO: Stop Operations
        }
    }
}
