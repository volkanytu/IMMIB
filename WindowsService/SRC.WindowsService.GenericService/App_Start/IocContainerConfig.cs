using Autofac;
using SRC.Library.Ioc.IocManager;
using SRC.Library.Data.Interfaces;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Data.SqlDao;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Domain.Business;
using SRC.Library.Entities.CustomEntities;
using SRC.WindowsService.GenericService.ServiceLibs.Test.TestTasks;

namespace SRC.WindowsService.GenericService
{
    public class IocContainerConfig
    {
        public static string APPLICATION_NAME = "WindowsService";

        public static IContainer BuildIocContainer(string serviceName)
        {
            var builder = new ContainerBuilder();

            #region | IOC REGISTER |
            IocContainerBuilder.RegisterDataAccess(builder);
            IocContainerBuilder.RegisterLogManager(builder, string.Format("{0}.{1}", APPLICATION_NAME, serviceName), LogEntity.LogClientType.ELASTIC);
            IocContainerBuilder.RegisterPortal(builder);
            #endregion

            builder.Register<IEducationAttendanceDao>(c => new EducationAttendanceDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IEducationAttendanceBusiness>(c => new EducationAttendanceBusiness(c.Resolve<IEducationAttendanceDao>()
                , c.Resolve<IBaseDao<EducationAttendance>>())).InstancePerDependency();

            builder.Register<ITestTask>(c => new TestTask()).InstancePerDependency();

            var container = builder.Build();

            return container;
        }
    }
}
