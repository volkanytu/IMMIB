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

        public static IContainer BuildIocContainer(string jobName)
        {
            var builder = new ContainerBuilder();

            #region | IOC REGISTER |
            IocContainerBuilder.RegisterDataAccess(builder);
            IocContainerBuilder.RegisterLogManager(builder, string.Format("{0}.{1}", APPLICATION_NAME, jobName), LogEntity.LogClientType.ELASTIC);
            IocContainerBuilder.RegisterPortal(builder);
            //IocContainerBuilder.RegisterInterceptors(builder);
            #endregion

            builder.Register<IEducationAttendanceDao>(c => new EducationAttendanceDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IEducationAttendanceBusiness>(c => new EducationAttendanceBusiness(c.Resolve<IEducationAttendanceDao>()
                , c.Resolve<IBaseDao<EducationAttendance>>())).InstancePerDependency();

            builder.Register<BaseJob>(c => new PassiveUnPaidAttendance(c.Resolve<ILogManager>(), c.Resolve<IBaseBusiness<EducationAttendance>>(), c.Resolve<IEducationAttendanceBusiness>()))
                .Keyed<BaseJob>(JobType.PassiveUnPaidAttendance.ToString())
                .InstancePerLifetimeScope()
                .InterceptedBy(typeof(LogInterceptor));

            builder.Register<BaseJob>(c => new ImmibMemberIntegration(c.Resolve<ILogManager>()
                , c.Resolve<IBaseBusiness<Account>>()
                , c.Resolve<IAccountBusiness>()
                , c.Resolve<IBaseBusiness<Association>>()
                , c.Resolve<IAssociationBusiness>()))
                .Keyed<BaseJob>(JobType.ImmibIntegration.ToString())
                .InstancePerLifetimeScope()
                .InterceptedBy(typeof(LogInterceptor));

            builder.Register<BaseJob>(c => new MigrateCrmData(c.Resolve<ILogManager>(), c.ResolveNamed<ISqlAccess>("CRM4")
                , c.Resolve<IBaseBusiness<City>>()
                , c.Resolve<IBaseBusiness<Town>>()
                , c.Resolve<IBaseBusiness<EducationDefinition>>()
                , c.Resolve<IBaseBusiness<Association>>()
                , c.Resolve<IBaseBusiness<EducationLocation>>()
                , c.Resolve<IBaseBusiness<Account>>()
                , c.Resolve<IBaseBusiness<Contact>>()
                , c.Resolve<IBaseBusiness<Education>>()
                , c.Resolve<IBaseBusiness<EducationAttendance>>()
                , c.Resolve<IBaseBusiness<CreditCardLog>>()))
                .Keyed<BaseJob>(JobType.MigrateCrmData.ToString())
                .InstancePerLifetimeScope()
                .InterceptedBy(typeof(LogInterceptor));

            var container = builder.Build();

            return container;
        }
    }
}
