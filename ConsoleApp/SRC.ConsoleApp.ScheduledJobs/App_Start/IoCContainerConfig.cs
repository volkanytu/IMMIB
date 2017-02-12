using System.Configuration;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using SRC.ConsoleApp.ScheduledJobs.Interfaces;
using SAHIBINDEN.ConsoleApp.ScheduledJobs.Jobs;
using SRC.ConsoleApp.ScheduledJobs.Jobs;
using SRC.Library.LogManager.Interfaces;
using SRC.Library.Ioc.Interceptor;
using SRC.Library.Ioc.IocManager;
using SRC.Library.Data.Interfaces;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Data.SqlDao;
using SRC.Library.Constants.SqlQueries;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Business.Interfaces;
using SRC.Library.Business;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Domain.Business;
using SRC.Library.Entities.CustomEntities;

namespace SRC.ConsoleApp.ScheduledJobs
{
    public class IocContainerConfig
    {
        public static string APPLICATION_NAME = "SCHEDULED_JOBS";

        public static IContainer BuildIocContainer()
        {
            var builder = new ContainerBuilder();

            #region | IOC REGISTER |
            IocContainerBuilder.RegisterDataAccess(builder);
            IocContainerBuilder.RegisterLogManager(builder, APPLICATION_NAME, LogEntity.LogClientType.ELASTIC);
            //IocContainerBuilder.RegisterInterceptors(builder);
            #endregion

            builder.Register<IBaseDao<EducationAttendance>>(c => new BaseSqlDao<EducationAttendance>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), EducationAttendenceQueries.GET_EDUCATION_ATTENDANCE_LIST, EducationAttendenceQueries.GET_EDUCATION_ATTENDANCE_LIST)).InstancePerDependency();
            builder.Register<IBaseBusiness<EducationAttendance>>(c => new BaseBusiness<EducationAttendance>(c.Resolve<IBaseDao<EducationAttendance>>())).InstancePerDependency();

            builder.Register<IEducationAttendanceDao>(c => new EducationAttendanceDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IEducationAttendanceBusiness>(c => new EducationAttendanceBusiness(c.Resolve<IEducationAttendanceDao>())).InstancePerDependency();

            builder.Register<BaseJob>(c => new TestJob(c.Resolve<ILogManager>(), c.Resolve<IBaseBusiness<EducationAttendance>>(), c.Resolve<IEducationAttendanceBusiness>()))
                .Keyed<BaseJob>(JobType.TestJob.ToString())
                .InstancePerLifetimeScope()
                .InterceptedBy(typeof(LogInterceptor));

            var container = builder.Build();

            return container;
        }
    }
}
