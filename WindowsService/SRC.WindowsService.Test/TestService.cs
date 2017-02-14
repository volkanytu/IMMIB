using Autofac;
using SRC.Library.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;
using SRC.WindowsService.TestService;
using SRC.WindowsService.TestService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SRC.WindowsService.TestService
{
    public partial class TestService : ServiceBase
    {
        private readonly IContainer _container;
        private IServiceManager _serviceManager;
        //private IBaseBusiness<SmsEnt> _baseBusiness;
        //private SmsManager _smsManager;

        public TestService()
        {
            InitializeComponent();

            _container = IocContainerConfig.BuildIocContainer();
            //_baseBusiness = _container.Resolve<IBaseBusiness<SmsEnt>>();
            //_smsManager = new SmsManager();
            _serviceManager = _container.Resolve<IServiceManager>();
        }

        internal void DebugService(string[] args)
        {
            StartOperation();
        }

        protected override void OnStart(string[] args)
        {
            Task startedTask = Task.Factory.StartNew(() =>
            {
                StartOperation();
            });
        }

        protected override void OnStop()
        {
            StopOperation();
        }

        private void StartOperation()
        {
            //Task t = Task.Factory.StartNew(() =>
            //{
            _serviceManager.Start();
            //});

            //t.Wait();
        }

        private void StopOperation()
        {
            _serviceManager.Dispose();
        }
    }
}
