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
using SRC.Library.Data.SqlDao.SRC.Library.Data.SqlDao;
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
            //IocContainerBuilder.RegisterInterceptors(builder);
            #endregion

            builder.Register<IBaseDao<EducationAttendance>>(c => new BaseSqlDao<EducationAttendance>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), EducationAttendenceQueries.GET_EDUCATION_ATTENDANCE_LIST, EducationAttendenceQueries.GET_EDUCATION_ATTENDANCE_LIST)).InstancePerDependency();
            builder.Register<IBaseBusiness<EducationAttendance>>(c => new BaseBusiness<EducationAttendance>(c.Resolve<IBaseDao<EducationAttendance>>())).InstancePerDependency();

            builder.Register<IEducationAttendanceDao>(c => new EducationAttendanceDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IEducationAttendanceBusiness>(c => new EducationAttendanceBusiness(c.Resolve<IEducationAttendanceDao>()
                , c.Resolve<IBaseDao<EducationAttendance>>())).InstancePerDependency();

            builder.Register<IBaseDao<Account>>(c => new BaseSqlDao<Account>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), AccountQueries.GET_ACCOUNT, AccountQueries.GET_ACCOUNT_LIST)).InstancePerDependency();
            builder.Register<IBaseBusiness<Account>>(c => new BaseBusiness<Account>(c.Resolve<IBaseDao<Account>>())).InstancePerDependency();

            builder.Register<IAccountDao>(c => new AccountDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IAccountBusiness>(c => new AccountBusiness(c.Resolve<IBaseDao<Account>>(), c.Resolve<IAccountDao>())).InstancePerDependency();

            builder.Register<IBaseDao<Association>>(c => new BaseSqlDao<Association>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), AssociationQueries.GET_ASSOCIATION, AssociationQueries.GET_ASSOCIATION_LIST)).InstancePerDependency();
            builder.Register<IBaseBusiness<Association>>(c => new BaseBusiness<Association>(c.Resolve<IBaseDao<Association>>())).InstancePerDependency();

            builder.Register<IAssociationDao>(c => new AssociationDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IAssociationBusiness>(c => new AssociationBusiness(c.Resolve<IBaseDao<Association>>(), c.Resolve<IAssociationDao>())).InstancePerDependency();

            builder.Register<BaseJob>(c => new PassiveUnPaidAttendance(c.Resolve<ILogManager>(), c.Resolve<IBaseBusiness<EducationAttendance>>(), c.Resolve<IEducationAttendanceBusiness>()))
                .Keyed<BaseJob>(JobType.PassiveUnPaidAttendance.ToString())
                .InstancePerLifetimeScope()
                .InterceptedBy(typeof(LogInterceptor));

            builder.Register<BaseJob>(c => new ImmibMemberIntegration(c.Resolve<ILogManager>() 
                                        ,c.Resolve<IBaseBusiness<Account>>(), c.Resolve<IAccountBusiness>()
                                        ,c.Resolve<IBaseBusiness<Association>>(), c.Resolve<IAssociationBusiness>()))
                .Keyed<BaseJob>(JobType.ImmibIntegration.ToString())
                .InstancePerLifetimeScope()
                .InterceptedBy(typeof(LogInterceptor));

            var container = builder.Build();

            return container;
        }
    }
}
