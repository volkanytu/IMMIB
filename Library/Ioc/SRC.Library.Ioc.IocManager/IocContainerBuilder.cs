using Autofac;
using SRC.Library.Common;
using SRC.Library.Data.ElasticDao;
using SRC.Library.Data.ElasticDao.Interfaces;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Entities.CustomEntities;
using SRC.Library.Ioc.Interceptor;
using SRC.Library.LogManager;
using SRC.Library.LogManager.Interfaces;
using SSRC.Library.Data.SqlDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Ioc.IocManager
{
    public static class IocContainerBuilder
    {
        public static ContainerBuilder RegisterDataAccess(ContainerBuilder builder)
        {
            builder.Register<ISqlAccess>(c => new SqlAccess(Globals.ConnectionString)).InstancePerLifetimeScope();
            builder.Register<IElasticAccess>(c => new ElasticAccess(Globals.ElasticUrl, Globals.ElasticIndexName)).InstancePerLifetimeScope();
            builder.Register<IMsCrmAccess>(c => new MsCrmAccess(Globals.CrmConnectionString)).InstancePerDependency();

            return builder;
        }

        public static ContainerBuilder RegisterLogManager(ContainerBuilder builder, string applicationName, LogEntity.LogClientType logClientType)
        {
            builder = RegisterDataAccess(builder);

            builder.Register<ILog>(c => new SqlLogDao(c.Resolve<ISqlAccess>(), applicationName)).Keyed<ILog>(LogEntity.LogClientType.SQL);
            builder.Register<ILog>(c => new SqlLogDao(c.Resolve<ISqlAccess>(), applicationName)).Keyed<ILog>(LogEntity.LogClientType.ELASTIC);
            builder.Register<ILog>(c => new FileLogger(Globals.FileLogPath)).Keyed<ILog>(LogEntity.LogClientType.FILE);

            builder.Register<ILogManager>(c => new Logger(c.ResolveKeyed<ILog>(logClientType))).InstancePerLifetimeScope();

            return builder;
        }

        public static ContainerBuilder RegisterInterceptors(ContainerBuilder builder)
        {
            builder.Register(c => new LogInterceptor(c.Resolve<ILogManager>()));
            builder.Register(c => new CustomExceptionInterceptor());

            return builder;
        }
    }
}
