using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;

namespace SRC.WindowsService.GenericService
{
    [RunInstaller(true)]
    public class ServiceDeploy : Installer
    {
        public ServiceDeploy()
        {
            var processInstaller = new ServiceProcessInstaller()
            {
                Account = ServiceAccount.User
            };
            this.Installers.Add(processInstaller);

            var serviceTypes = Assembly.GetExecutingAssembly().GetTypes().Where(c => c.BaseType == typeof(BaseService));

            foreach (var serviceType in serviceTypes)
            {
                string description = "SRC Default servis";

                var attr = Attribute.GetCustomAttribute(serviceType, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                    description = attr.Description;

                var serviceInstaller = new ServiceInstaller()
                {
                    DisplayName = string.Format("SRC - {0}", serviceType.Name),
                    StartType = ServiceStartMode.Automatic,
                    DelayedAutoStart = true,

                    Description = description,
                    ServiceName = serviceType.Name
                };
                this.Installers.Add(serviceInstaller);
            }
        }
    }
}
